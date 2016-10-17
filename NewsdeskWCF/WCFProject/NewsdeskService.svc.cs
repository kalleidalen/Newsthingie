using DataLayer;
using DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;

namespace WCFProject
{
	public class NewsdeskService : INewsdeskService
	{
		private DBNewsdeskModel context;
		private static string SMTPSERVER = "smtp.gmail.com";
		private static int PORTNO = 587;

		public NewsdeskService()
		{
			context = new DBNewsdeskModel();
		}
		[DllImport("wininet.dll")]
		private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

		public static bool IsConnectedToInternet()
		{
			try
			{
				int Desc;
				return InternetGetConnectedState(out Desc, 0);
			}
			catch
			{
				return false;
			}
		}

		private void SaveMail(string[] emailToAddress, string subject, string body, bool isBodyHtml)
		{
			string[] email = new string[0];
			if (emailToAddress!=null){email = new string[emailToAddress.Count()];}

			var authorList = new List<Author>();

			foreach (var item in emailToAddress)
			{
				var author = context.Authors.FirstOrDefault(a => a.Email.ToLower().Contains(item.ToLower()));
				if (author!=null)
				{
					authorList.Add(author);
				}
			}

			context.NotDeliveredMail.Add(new Mail
			{
			
				Emails = authorList,				
				Subject = subject,
				Body = body,
				isBodyHtml=isBodyHtml

			});
			context.SaveChanges();
		}

		public void SendNotDeliveredMail()
		{
			var email = new List<string>();
			string[] CcMailTo = new string[0];
			List<Mail> mailList = new List<Mail>(context.NotDeliveredMail.ToList());
			if (mailList.Count > 0 && IsConnectedToInternet())
			{
				foreach (var list in mailList)
				{	
					foreach (var item in list.Emails)
					{
						email.Add(item.Email);
					}
				}
				mailList.ForEach(i => SendEmail("", "", email.ToArray(), CcMailTo, i.Subject, i.Body, i.isBodyHtml));
				mailList.ForEach(i => context.NotDeliveredMail.Remove(i));
				context.SaveChanges();

			}

		}


		private string SendEmail(string mailUserName, string mailUserPassword,
		   string[] emailToAddress, string[] ccemailTo, string subject, string body, bool isBodyHtml)
		{
			
			
			if (string.IsNullOrWhiteSpace(mailUserName))
			{
				mailUserName = "testnyheter3@gmail.com";
				//return "Användarnamnet får inte vara tomt";
			}
			if (string.IsNullOrWhiteSpace(mailUserPassword))
			{
				mailUserPassword = "123456781";
				//return "Lösenordet får inte vara tomt";
			}
			if (emailToAddress == null || emailToAddress.Length == 0)
			{
				return "Mottagaradressen får inte vara tomt";
			}
			if (emailToAddress[0] == null)
			{
			
				return "Mottagaradressen får inte vara tomt";
			}
			bool isConnected =IsConnectedToInternet();
			if (!isConnected)
			{
				SaveMail(emailToAddress, subject, body, isBodyHtml);
				return "Mejlet kunde inte skickas just nu.";
			}
			List<string> tempFiles = new List<string>();

			SmtpClient smtpClient = new SmtpClient(SMTPSERVER, PORTNO);
			smtpClient.EnableSsl = true;
			smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
			smtpClient.UseDefaultCredentials = false;
			smtpClient.Credentials = new NetworkCredential(mailUserName, mailUserPassword);
			using (MailMessage message = new MailMessage())
			{
				message.From = new MailAddress(mailUserName);
				message.Subject = subject == null ? "" : subject;
				message.Body = body == null ? "" : body;
				message.IsBodyHtml = isBodyHtml;

				foreach (string email in emailToAddress)
				{
					message.To.Add(email);
				}
				if (ccemailTo != null && ccemailTo.Length > 0)
				{
					foreach (string emailCc in ccemailTo)
					{
						message.CC.Add(emailCc);
					}
				}
				try
				{
					smtpClient.Send(message);
					return "Mejlet skickades";
				}
				catch
				{
					return "Det gick inte att skicka mejlet";
				}
			}
		}

		public string SendEmailAccountCreated(int id)
		{
			var author = context.Authors.Find(id);
			var addresses = new string[1];
			addresses[0] = author.Email;
			if (addresses[0]!=null)
			{
				return SendEmail("", "", addresses, null, "Dag & Natt Redaktionen: Ditt konto har skapats.", "Hej "+ author.FirstName + " " + author.LastName +
					".\nDitt konto har skapats och måste godkännas.\n\nMånga hälsningar\nDag & Natt Redaktionen", false);
			}
			else
			{
				return "Inga meljadresser att skicka till.";
			}
		}

		private string SendEmailNewArticle(int id)
		{
			var articleCategories = new List<Category>(context.Articles.Find(id).Categories);
			var allSubscribers = new List<Subscriber>();
			foreach (var item in articleCategories)
			{
				foreach (var it in item.Subscribers)
				{
					allSubscribers.Add(it);
				}
			}
			if (allSubscribers.Count > 0)
			{
				string[] addresses = new string[allSubscribers.Count];

				for (int i = 0; i < allSubscribers.Count; i++)
				{
					addresses[i] = allSubscribers[i].Email;
				}


				return SendEmail("", "", addresses, null, "Dag & Natt Redaktionen: En ny artikel har skapats i kategorin som du prenumererar på.", "Hej!\nEn ny artikel har skapats i kategorin " +
					"som du prenumererar på.\nArtikeln har rubriken \"" + context.Articles.Find(id).Title + "\" gå gärna in i vår app och läs artikeln." +
				"\n\nMånga hälsningar\nDag & Natt Redaktionen", false);
			}
			else
			{
				return "Inga meljadresser att skicka till.";
			}
		}

		private string SendEmailAccountApproved(int id)
		{
			var author = context.Authors.Find(id);
			var addresses = new string[1];
			addresses[0] = author.Email;
			if (addresses[0] != null)
			{
				return SendEmail("", "", addresses, null, "Dag & Natt Redaktionen: Ditt konto har blivit godkänt.", "Hej! " + author.FirstName + " " + author.LastName +"\n"+
					"\nDitt konto har blivit godkänt.\nDu kan nu logga in i vår app.\n\nMånga hälsningar\nDag & Natt Redaktionen", false);
			}
			else
			{
				return "Inga meljadresser att skicka till.";
			}
		}
		public string SendEmailToEditorNewAccountCreated()
		{
			var author = context.Authors.FirstOrDefault(a=>a.IsEditor==true);
			var addresses = new string[1];
			addresses[0] = author.Email;
			if (addresses[0] != null)
			{
				return SendEmail("", "", addresses, null, "Dag & Natt Redaktionen: Ett nytt konto har skapats.", "Hej!"+
					"\nEtt nytt konto har skapats och behöver godkännas.\n\nMånga hälsningar\nDag & Natt Redaktionen", false);
			}
			else
			{
				return "Inga meljadresser att skicka till.";
			}
		}

		public List<CategoryToClient> GetAllCategories()
		{
			List<CategoryToClient> listCategory = context.Categories.Select(c => new CategoryToClient
			{
				Id = c.Id,
				Name = c.Name,
			}).ToList();
			return listCategory;
		}

		public CategoryToClient AddCategory(string NewCategoryName)
		{
			CategoryToClient newCategory = new CategoryToClient { Name = NewCategoryName };
			context.Categories.Add(new Category { Name = NewCategoryName });
			context.SaveChanges();

			return newCategory;
		}

		public CategoryToClient EditCategory(CategoryToClient oldCategory, string newName)
		{
			Category category = context.Categories.Find(oldCategory.Id);
			category.Name = newName;
			context.SaveChanges();
			CategoryToClient categoryToClient = new CategoryToClient();
			categoryToClient.Id = oldCategory.Id;
			categoryToClient.Name = newName;
			return categoryToClient;
		}

		public void DeleteCategory(int id)
		{
			Category category = context.Categories.Find(id);
			context.Categories.Remove(category);
			context.SaveChanges();
		}

		public List<ArticleToClient> GetAllArticles(bool onlyNotApproved)
		{
			var articles = context.Articles.Select(a => new ArticleToClient

			{
				Id = a.Id,
				Title = a.Title,
				Preamble = a.Preamble,
				ArticleBody = a.ArticleBody,
				CreatedDate = a.CreatedDate,
				UpdatedDate = a.UpdatedDate,
				IsApproved = a.IsApproved
			}).ToList();

			if (onlyNotApproved)
			{
				articles = articles.Where(a => a.IsApproved == false).ToList();
			}
			return articles;
		}

		public List<Category> GetAllCategoriesInArticle(Article article)
		{
			List<Category> categoryList = new List<Category>();
			foreach (var item in article.Categories)
			{
				Category category = context.Categories.FirstOrDefault(a => a.Id == item.Id);
				categoryList.Add(category);
			}

			return categoryList;
		}
		public List<CategoryToClient> GetAllCategoriesForArticleToClient(int id)
		{
			Article article = context.Articles.FirstOrDefault(a => a.Id == id);

			List<CategoryToClient> list = new List<CategoryToClient>();
			foreach (var item in article.Categories)
			{
				Category category = context.Categories.FirstOrDefault(a => a.Id == item.Id);
				list.Add(new CategoryToClient
				{
					Id = category.Id,
					Name=category.Name,
					});
			}

			return list;
		}
		public Article CreateArticle(Article article)
		{
			Article newArticle = new Article
			{
				Id = article.Id,
				Title = article.Title,
				Preamble = article.Preamble,
				ArticleBody = article.ArticleBody,
				Categories = GetAllCategoriesInArticle(article),
				Authors = GetAllAuthorsForArticle(article),
				CreatedDate = DateTime.Now,
				UpdatedDate = DateTime.Now,
			};

			context.Articles.Add(newArticle);
			context.SaveChanges();
			article.Id = newArticle.Id;
			
			return article;
		}

		public List<Author> GetAllAuthorsForArticle(Article article)
		{
			List<Author> authorList = new List<Author>();
			foreach (var item in article.Authors)
			{
				Author author = context.Authors.FirstOrDefault(a => a.Id == item.Id);
				authorList.Add(author);
			}

			return authorList;
		}

		public List<AuthorToClient> GetAllAuthorsForArticleToClient(int id)
		{
			Article article = context.Articles.FirstOrDefault(a => a.Id == id);

			List<AuthorToClient> authorList = new List<AuthorToClient>();
			foreach (var item in article.Authors)
			{
				Author author = context.Authors.FirstOrDefault(a => a.Id == item.Id);
				authorList.Add(new AuthorToClient
				{
					Id = author.Id,
					FirstName = author.FirstName,
					LastName = author.LastName,
					Email = author.Email,
					IsApproved = author.IsApproved,
					IsEditor = author.IsEditor,
				});
			}

			return authorList;
		}

		public Article GetArticle(int id)
		{
			{
				Article theArticle = context.Articles.FirstOrDefault(a => a.Id == id);

				return new Article
				{
					Id = theArticle.Id,
					Title = theArticle.Title,
					Preamble = theArticle.Preamble,
					ArticleBody = theArticle.ArticleBody,
					CreatedDate = theArticle.CreatedDate,
					UpdatedDate = theArticle.UpdatedDate,
					Categories = GetAllCategoriesInArticle(theArticle),
					Authors = GetAllAuthorsForArticle(theArticle),
				};
			}
		}

		public void UpdateArticle(Article article)
		{
			Article updatedArticle = context.Articles.Find(article.Id);
			updatedArticle.Title = article.Title;
			updatedArticle.Preamble = article.Preamble;
			updatedArticle.ArticleBody = article.ArticleBody;
			updatedArticle.UpdatedDate = article.UpdatedDate;
			updatedArticle.Categories = GetAllCategoriesInArticle(updatedArticle);
			updatedArticle.Authors = GetAllAuthorsForArticle(updatedArticle);

			context.SaveChanges();
			
		}

		public void DeleteArticle(int id)
		{
			Article article = context.Articles.Find(id);
			context.Articles.Remove(article);
			context.SaveChanges();
		}

		public void SetArticleIsApproved(int articleId)
		{
			Article article = context.Articles.Find(articleId);
			article.IsApproved = true;
			SendEmailNewArticle(articleId);
			context.SaveChanges();
		}

		public void SetArticleIsNotApproved(int articleId)
		{
			Article article = context.Articles.Find(articleId);
			article.IsApproved = false;
			context.SaveChanges();
		}

		public List<AuthorToClient> GetAllAuthors(bool onlyNotApproved)
		{
			List<AuthorToClient> authorList = context.Authors.Select(a => new AuthorToClient

		   {
			   Id = a.Id,
			   FirstName = a.FirstName,
			   LastName = a.LastName,
			   IsEditor = a.IsEditor,
			   Email = a.Email,
			   IsApproved = a.IsApproved
		   }).ToList();
			if (onlyNotApproved)
			{
				authorList = authorList.Where(a => a.IsApproved == false).ToList();
			}
			return authorList;
		}

		public List<Article> GetAllArticlesForAnAuthor(Author author)
		{
			List<Article> articleList = new List<Article>();
			foreach (var item in author.Articles)
			{
				Article article = context.Articles.FirstOrDefault(a => a.Id == item.Id);
				articleList.Add(article);
			}

			return articleList;
		}

		public int CreateAuthor(Author author)
		{
			string password = Common.CreateCryptoPasswordFromString(author.Password);
			Author newAuthor = new Author();
			newAuthor.FirstName = author.FirstName;
			newAuthor.LastName = author.LastName;
			newAuthor.Password = password;
			newAuthor.IsEditor = author.IsEditor;
			newAuthor.Email = author.Email;
			context.Authors.Add(newAuthor);
			context.SaveChanges();
			return newAuthor.Id;
		}

		public Author EditAuthor(Author author)
		{
			Author updatedAuthor = context.Authors.Find(author.Id);
			updatedAuthor.FirstName = author.FirstName;
			updatedAuthor.LastName = author.LastName;
			updatedAuthor.IsEditor = author.IsEditor;
			updatedAuthor.Email = author.Email;
			updatedAuthor.Articles = GetAllArticlesForAnAuthor(author);

			context.SaveChanges();
			return updatedAuthor;
		}

		public void DeleteAuthor(int id)
		{
			Author author = context.Authors.Find(id);
			context.Authors.Remove(author);
			context.SaveChanges();
		}

		public void AuthorIsApproved(int id)
		{
			Author author = context.Authors.Find(id);
			author.IsApproved = true;
			SendEmailAccountApproved(id);
			context.SaveChanges();
		}

		public void SetAuthorToEditor(int id)
		{
			Author author = context.Authors.Find(id);
			author.IsEditor = true;
			context.SaveChanges();
		}

		public void SetAuthorNotToEditor(int id)
		{
			Author author = context.Authors.Find(id);
			author.IsEditor = false;
			context.SaveChanges();
		}

		public void SetAcceptAuthor(int authorId)
		{
			Author author = context.Authors.Find(authorId);
			author.IsApproved = true;
			context.SaveChanges();
		}

		public void SetNotAcceptAuthor(int authorId)
		{
			Author author = context.Authors.Find(authorId);
			author.IsApproved = false;
			context.SaveChanges();
		}

		public AuthorToClient ValidateAuthorLogin(string email, string password)
		{
			string cryptedPassword = Common.CreateCryptoPasswordFromString(password);
			try
			{
				Author currentUser = context.Authors.FirstOrDefault(a => a.Email.ToLower() == email.ToLower()
				&& a.Password == cryptedPassword);
				if (currentUser != null)
				{
					AuthorToClient currentUserToClient = new AuthorToClient
					{
						Id = currentUser.Id,
						FirstName = currentUser.FirstName,
						LastName = currentUser.LastName,
						Email = currentUser.Email,
						IsEditor = currentUser.IsEditor,
						IsApproved = currentUser.IsApproved
					};
					return currentUserToClient;
				}
				else
				{
					return null;
				}
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}