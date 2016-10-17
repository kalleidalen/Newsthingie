using DataLayer;
using DomainClasses;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;

namespace NewsdeskWCFPaper
{
	public class NewsdeskPaperService : INewsdeskPaperService
	{
		private DBNewsdeskModel context;

		private static string SMTPSERVER = "smtp.gmail.com";
		private static int PORTNO = 587;

		public NewsdeskPaperService()
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
			if (emailToAddress != null) { email = new string[emailToAddress.Count()]; }

			var authorList = new List<Author>();

			foreach (var item in emailToAddress)
			{
				var author = context.Authors.FirstOrDefault(a => a.Email.ToLower().Contains(item.ToLower()));
				if (author != null)
				{
					authorList.Add(author);
				}
			}

			context.NotDeliveredMail.Add(new Mail
			{

				Emails = authorList,
				Subject = subject,
				Body = body,
				isBodyHtml = isBodyHtml

			});
			context.SaveChanges();
		}

		private string SendEmail(string mailUserName, string mailUserPassword,
		   string[] emailToAddress, string[] ccemailTo, string subject, string body, bool isBodyHtml)
		{
			if (string.IsNullOrWhiteSpace(mailUserName))
			{
				mailUserName = "mikael@charleston.se";
				//return "Användarnamnet får inte vara tomt";
			}
			if (string.IsNullOrWhiteSpace(mailUserPassword))
			{
				mailUserPassword = "4425509";
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
			bool isConnected = IsConnectedToInternet();
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

		public string SendEmailHasRegister(int id)
		{
			string[] addresses = new string[1];
			Subscriber subscriber = context.Subscribers.Find(id);
			var categoryList = new List<Category>(subscriber.Categories);
			string categoryNames = string.Empty;
			categoryList.ForEach(i => categoryNames += i.Name + "\n");

			addresses[0] = subscriber.Email;
			return SendEmail("", "", addresses, null, "Nu prenumererar du på Dags & Natt nyheter",
				"Hej!\nVi har mottagit din prenumeration av våra nyheter.\nNär nyheter publiceras i nedanstående kategorier kommer du att få ett mejl.\n\n" +
				categoryNames + "\nMånga hälsningar\nDag & Natt Redaktionen", false);
		}

		public string SendEmailHasUnRegister(string mail)
		{
			string[] addresses = new string[1];
			addresses[0] = mail;
			return SendEmail("", "", addresses, null, "Avslutar din prenumeration på Dags & Natt nyheter",
				"Hej!\nVi har mottagit din begärna om att avsluta prenumerationen av våra nyheter.\n"+
				"\nMånga hälsningar\nDag & Natt Redaktionen\n", false);
		}


		public List<CategoryToClient> GetAllCategories()
		{
			var listCategory = context.Categories.Select(c => new CategoryToClient
			{
				Id = c.Id,
				Name = c.Name,
			}).ToList();
			return listCategory;
		}

		public List<ArticleToClient> GetAllArticlesTopFive()
		{
			var articles = context.Articles.Where(a => a.IsApproved == true).Select(a => new ArticleToClient

			{
				Id = a.Id,
				Title = a.Title,
				Preamble = a.Preamble,
				ArticleBody = a.ArticleBody,
				CreatedDate = a.CreatedDate,
				UpdatedDate = a.UpdatedDate,
			}).OrderByDescending(a => a.UpdatedDate).Take(5).ToList();

			return articles;
		}

		public List<ArticleToClient> GetAllArticles()
		{
			var articles = context.Articles.Where(a => a.IsApproved == true).Select(a => new ArticleToClient

			{
				Id = a.Id,
				Title = a.Title,
				Preamble = a.Preamble,
				ArticleBody = a.ArticleBody,
				CreatedDate = a.CreatedDate,
				UpdatedDate = a.UpdatedDate,
			}).OrderByDescending(a => a.UpdatedDate).ToList();

			return articles;
		}

		public List<ArticleToClient> GetAllArticlesInCategory(int categoryId)
		{
			if (categoryId < 2) { return GetAllArticles(); }
			var articles = context.Categories.Find(categoryId).Articles.Where(a => a.IsApproved == true).Select(a => new ArticleToClient

			{
				Id = a.Id,
				Title = a.Title,
				Preamble = a.Preamble,
				ArticleBody = a.ArticleBody,
				CreatedDate = a.CreatedDate,
				UpdatedDate = a.UpdatedDate,
			}).OrderByDescending(a => a.UpdatedDate).ToList();

			return articles;
		}

		public int RegisterSubscriber(string email, List<int> categoryIds)
		{
			var categoryList = new List<Category>();

			foreach (var item in categoryIds)
			{
				var category = context.Categories.FirstOrDefault(c => c.Id == item);
				categoryList.Add(category);
			}
			var newSubscriber = new Subscriber
			{
				Email = email,
				Categories = categoryList
			};

			context.Subscribers.Add(newSubscriber);
			context.SaveChanges();
			return newSubscriber.Id;
		}



		public bool UnRegisterSubscriber(string email)
		{
			var subscribers =context.Subscribers.FirstOrDefault(s => s.Email.ToLower().Contains(email));
			if (subscribers!=null)
			{
				context.Subscribers.Remove(subscribers);
				context.SaveChanges();

				return true;
			}
			return false;

		}


		
	}
}