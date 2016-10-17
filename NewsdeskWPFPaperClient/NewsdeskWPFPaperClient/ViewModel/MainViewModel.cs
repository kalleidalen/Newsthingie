using NewsdeskWPFPaperClient.Command;
using NewsdeskWPFPaperClient.NewsDeskPaperServiceReference;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace NewsdeskWPFPaperClient.ViewModel
{
	public class MainViewModel : BaseViewModel
	{
		private NewsdeskPaperServiceClient client;

		public ObservableCollection<CategoryToClient> CategoryList { get; set; }

		public ObservableCollection<ArticleToClient> ArticleList { get; set; }

		public ObservableCollection<ArticleToClient> ArticleListTopFive { get; set; }

		public MainViewModel()
		{
			client = new NewsdeskPaperServiceClient();
			CategoryList = new ObservableCollection<CategoryToClient>(client.GetAllCategories());
			ArticleList = new ObservableCollection<ArticleToClient>(client.GetAllArticles());
			ArticleListTopFive = new ObservableCollection<ArticleToClient>(client.GetAllArticlesTopFive());
			ArticleListVisibility = true;
		}

		public List<CategoryToClient> SelectedCategoryForSubscriber
		{
			get { return CategoryList.Where(o => o.IsSelected).ToList(); }
		}

		private CategoryToClient selectedCategory;

		public CategoryToClient SelectedCategory
		{
			get { return selectedCategory; }
			set
			{
				selectedCategory = value;
				NotifyPropertyChanged("SelectedCategory");
				OnCategoryClick(value);
			}
		}

		private void OnCategoryClick(CategoryToClient category)
		{
			ArticleList = new ObservableCollection<ArticleToClient>(client.GetAllArticlesInCategory(category.Id));
			NotifyPropertyChanged("ArticleList");
			ArticleListVisibility = true;
			NotifyPropertyChanged("ArticleListVisibility");
			ArticleVisibility = false;
			NotifyPropertyChanged("ArticleVisibility");
		}

		private ArticleToClient selectedArticle;

		public ArticleToClient SelectedArticle
		{
			get { return selectedArticle; }
			set
			{
				selectedArticle = value;
				NotifyPropertyChanged("SelectedArticle");
				OnArticleClick(value);
			}
		}

		public bool ArticleListVisibility { get; set; }

		public bool ArticleVisibility { get; set; }

		private void OnArticleClick(ArticleToClient article)
		{
			ArticleListVisibility = false;
			NotifyPropertyChanged("ArticleListVisibility");
			ArticleVisibility = true;
			NotifyPropertyChanged("ArticleVisibility");
		}

		private RelayCommand registerAsSubscriber { get; set; }

		public ICommand RegisterAsSubscriber
		{
			get
			{
				if (registerAsSubscriber == null)
				{
					registerAsSubscriber = new RelayCommand(OnRegisterAsSubscriber, CanRegisterAsSubscriber);
				}
				return registerAsSubscriber;
			}
		}

		private RelayCommand unRegisterAsSubscriber { get; set; }

		public ICommand UnRegisterAsSubscriber
		{
			get
			{
				if (unRegisterAsSubscriber == null)
				{
					unRegisterAsSubscriber = new RelayCommand(OnUnRegisterAsSubscriber, CanUnRegisterAsSubscriber);
				}
				return unRegisterAsSubscriber;
			}
		}

		private void OnUnRegisterAsSubscriber(object param)
		{
			bool findEmail = client.UnRegisterSubscriber(email);
			if (!findEmail)
			{
				App.ShowMessage("Kunde inte hitta adressen du angav i vårt system.", "Hittade inte adressen");
			}
			else
			{
				client.SendEmailHasUnRegister(email);
			}
			Email = string.Empty;
			NotifyPropertyChanged("Email");
		}

		private bool CanUnRegisterAsSubscriber(object param)
		{
			bool isEmail = false;
			if (email != null)
			{
				isEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
			} return isEmail;
		}

		private string email;

		public string Email
		{
			get { return email; }
			set { email = value; }
		}

		private bool CanRegisterAsSubscriber(object param)
		{
			bool isEmail = false;
			if (!string.IsNullOrWhiteSpace(email))
			{
				isEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
			}
			return isEmail && SelectedCategoryForSubscriber.Count > 0;
		}

		private void OnRegisterAsSubscriber(object param)
		{
			if (SelectedCategoryForSubscriber.Count > 0)
			{
				int[] categoryIds = new int[SelectedCategoryForSubscriber.Count];
				for (int i = 0; i < SelectedCategoryForSubscriber.Count; i++)
				{
					categoryIds[i] = SelectedCategoryForSubscriber[i].Id;
				}

				int id = client.RegisterSubscriber(email, categoryIds);
				client.SendEmailHasRegister(id);
				foreach (var item in CategoryList)
				{
					item.IsSelected = false;
				}
				CategoryList = new ObservableCollection<CategoryToClient>(client.GetAllCategories());
				NotifyPropertyChanged("CategoryList");
				Email = string.Empty;
				NotifyPropertyChanged("Email");

				App.ShowMessage("Din prenumeration är nu registrerad,\ndu kommer få ett mejl som bekräftelse inom kort.", "Registreringen genomförd");
			}
		}

		private bool isSelected;

		public bool IsSelected
		{
			get { return isSelected; }
			set { isSelected = value; }
		}

		private RelayCommand changeState { get; set; }

		public ICommand ChangeState
		{
			get
			{
				if (changeState == null)
				{
					changeState = new RelayCommand(OnChangeState);
				}
				return changeState;
			}
			set
			{
				if (changeState == null)
				{
					changeState = new RelayCommand(OnChangeState);
				}
			}
		}

		private void OnChangeState(object param)
		{
			CheckBox control = new CheckBox();
			control = param as CheckBox;
			if (control != null)
			{
				bool isChecked = control.IsChecked.Value;

				int id = int.Parse(control.Tag.ToString());
				CategoryList.Where(c => c.Id == id).FirstOrDefault(cc => cc.IsSelected = isChecked);
				NotifyPropertyChanged("CategoryList");
			}
		}

		private RelayCommand menuButtonDown { get; set; }

		public ICommand MenuButtonDown
		{
			get
			{
				if (menuButtonDown == null)
				{
					menuButtonDown = new RelayCommand(OnMenuButtonDown, CanMenuButtonDown);
				}
				return menuButtonDown;
			}
		}

		private bool CanMenuButtonDown(object param)
		{
			return ArticleVisibility;
		}

		private void OnMenuButtonDown(object param)
		{
			var item = param as ListBox;
			var category = item.SelectedItem as CategoryToClient;
			if (category != null)
			{
				OnCategoryClick(category);
			}
		}

		private RelayCommand topFiveMenuButtonDown { get; set; }

		public ICommand TopFiveMenuButtonDown
		{
			get
			{
				if (topFiveMenuButtonDown == null)
				{
					topFiveMenuButtonDown = new RelayCommand(OnTopFiveMenuButtonDown);
				}
				return topFiveMenuButtonDown;
			}
		}

		private void OnTopFiveMenuButtonDown(object param)
		{
			var item = param as ListBox;
			var article = item.SelectedItem as ArticleToClient;
			if (article != null)
			{
				OnArticleClick(article);
			}
		}
	}
}