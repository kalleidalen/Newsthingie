using System;
using NewsdeskWPFClient.AdminServiceReference;
using NewsdeskWPFClient.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;

namespace NewsdeskWPFClient.ViewModel
{
	public class ModifyArticleViewModel:BaseViewModel
	{
		private NewsdeskServiceClient client;
		public ArticleToClient SelectedArticle;
		public ObservableCollection<CategoryToClient> Categories { get; private set; }
		public ObservableCollection<AuthorToClient> Authors { get; private set; }
		public ObservableCollection<AuthorToClient> OldAuthorSelected { get; private set; }
		public ObservableCollection<CategoryToClient> OldCategorySelected { get; private set; }
		public ModifyArticleViewModel()
		{
			client = new NewsdeskServiceClient();
			SelectedArticle = new ArticleToClient();
			Categories = new ObservableCollection<CategoryToClient>(client.GetAllCategories());
			Authors = new ObservableCollection<AuthorToClient>(client.GetAllAuthors(false));
			OldAuthorSelected = new ObservableCollection<AuthorToClient>();
			OldCategorySelected = new ObservableCollection<CategoryToClient>();
		}


		
		
		public List<CategoryToClient> SelectedCategory
		{
			get { return Categories.Where(o => o.IsSelected).ToList(); }
		
		}
		public List<AuthorToClient> SelectedAuthor
		{
			get { return Authors.Where(o => o.IsSelected).ToList(); }
			
		}
		public void SetSelectedArticle(ArticleToClient article)
		{
			SelectedArticle = article;
			Title = article.Title;
			Preamble = article.Preamble;
			ArticleBody = article.ArticleBody;
			SetSelectedAuthorWhenEditingExistingArticle(article);
			SetSelectedCategoryWhenEditingExistingArticle(article);
			
		}

		private void SetSelectedAuthorWhenEditingExistingArticle(ArticleToClient article)
		{
			OldAuthorSelected = new ObservableCollection<AuthorToClient>(client.GetAllAuthorsForArticleToClient(article.Id).ToList());

			foreach (var item in Authors)
			{
				foreach (var it in OldAuthorSelected)
				{
					if (it.Id == item.Id)
					{
						item.IsSelected = true;
					}
				}
			}
			NotifyPropertyChanged("Authors");
		}
		private void SetSelectedCategoryWhenEditingExistingArticle(ArticleToClient article)
		{
			OldCategorySelected = new ObservableCollection<CategoryToClient>(client.GetAllCategoriesForArticleToClient(article.Id).ToList());

			foreach (var item in Categories)
			{
				foreach (var it in OldCategorySelected)
				{
					if (it.Id == item.Id)
					{
						item.IsSelected = true;
					}
				}
			}
			NotifyPropertyChanged("Categories");
		}
		#region Fields
		private string title;

		public string Title
		{
			get { return title; }
			set {
				title = value;
				NotifyPropertyChanged("Title");
			}
		}
		private string preamble;

		public string Preamble
		{
			get { return preamble; }
			set { 
				preamble = value;
				NotifyPropertyChanged("Preamble");
			}
		}

		private string articleBody;

		public string ArticleBody
		{
			get { return articleBody; }
			set { 
				articleBody = value;
				NotifyPropertyChanged("ArticleBody");
				}
		}
		#endregion
		#region Commands
		
		public void CreateArticle()
		{
			var authorList = SelectedAuthor.Select(a => new Author{Id = a.Id}).ToList();
			var categoriesList = SelectedCategory.Select(c => new Category{Id = c.Id,Name = c.Name}).ToList();

			Article newArticle = new Article()
			{
				Title = Title,
				Preamble = Preamble,
				ArticleBody = ArticleBody,
				Categories = categoriesList.ToArray(),
				Authors = authorList.ToArray(),
				CreatedDate = DateTime.Now,
				UpdatedDate = DateTime.Now
			};
			client.CreateArticle(newArticle);
			
		}
		public void UpdateArticle(int id)
		{
			var authorList = SelectedAuthor.Select(a => new Author { Id = a.Id }).ToList();
			var categoriesList = SelectedCategory.Select(c => new Category { Id = c.Id, Name = c.Name }).ToList();

			Article newArticle = new Article()
			{
				Id =id,
				Title = Title,
				Preamble = Preamble,
				ArticleBody = ArticleBody,
				Categories = categoriesList.ToArray(),
				Authors = authorList.ToArray(),
				UpdatedDate = DateTime.Now
			};
			client.UpdateArticle(newArticle);

		}
		#endregion

		private RelayCommand updateApprovedAuthors { get; set; }

		public ICommand UpdateApprovedAuthors
		{
			get
			{
				if (updateApprovedAuthors == null)
				{
					updateApprovedAuthors = new RelayCommand(OnUpdateApprovedAuthors);
				}
				return updateApprovedAuthors;
			}
			set
			{
				if (updateApprovedAuthors == null)
				{
					updateApprovedAuthors = new RelayCommand(OnUpdateApprovedAuthors);
				}
			}
		}

		private void OnUpdateApprovedAuthors(object param)
		{
			
		}

		//private void OnChangeState(object param)
		//{
		//	CheckBox control = new CheckBox();
		//	control = param as CheckBox;
		//	if (control != null)
		//	{
		//		bool isApproved = control.IsChecked.Value;
		//		if (isApproved)
		//		{
		//			int id = int.Parse(control.Tag.ToString());
		//			client.SetArticleIsApproved(id);
		//			NotApprovedArticleList = new ObservableCollection<ArticleToClient>(client.GetAllArticles(true));
		//			NotifyPropertyChanged("NotApprovedArticleList");
		//		}
		//	}
		//}

		
		
		
		
	}
}
