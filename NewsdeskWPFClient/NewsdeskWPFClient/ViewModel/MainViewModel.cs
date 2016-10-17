using NewsdeskWPFClient.AdminServiceReference;
using NewsdeskWPFClient.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace NewsdeskWPFClient.ViewModel
{
	public class MainViewModel : BaseViewModel
	{
		private NewsdeskServiceClient client;

		public ObservableCollection<CategoryToClient> CategoryList { get; set; }

		public ObservableCollection<ArticleToClient> ArticleList { get; set; }

		public ObservableCollection<AuthorToClient> AuthorListAll { get; set; }

		public string NewCategoryName { get; set; }

		public bool IsEditor { get; set; }

		public int GridColumnEditor { get; set; }

		public int GridRowEditor { get; set; }

		public MainViewModel()
		{
			client = new NewsdeskServiceClient();
			CategoryList = new ObservableCollection<CategoryToClient>(client.GetAllCategories());
			CreateCategory = new RelayCommand(OnCategoryCreated, CanCategoryBeCreated);
			ArticleList = new ObservableCollection<ArticleToClient>(client.GetAllArticles(false));
			AuthorListAll = new ObservableCollection<AuthorToClient>(client.GetAllAuthors(false));
			NotApprovedArticleList = new ObservableCollection<ArticleToClient>(client.GetAllArticles(true));
			SetupGUIBasedOnApprovedAccess();
		}

		private void SetupGUIBasedOnApprovedAccess()
		{
			IsEditor = App.CurrentAuthor.IsEditor;
			NotifyPropertyChanged("IsEditor");
			if (!IsEditor)
			{
				GridColumnEditor = 0;
				GridRowEditor = 0;
			}
			else
			{
				GridColumnEditor = 1;
				GridRowEditor = 1;
			}
			NotifyPropertyChanged("GridColumnEditor");
			NotifyPropertyChanged("GridRowEditor");
		}

		#region Category

		private bool CanCategoryBeCreated(object obj)
		{
			if (string.IsNullOrEmpty(NewCategoryName))
			{
				return false;
			}
			return true;
		}

		private void OnCategoryCreated(object obj)
		{
			CategoryList.Add(client.AddCategory(NewCategoryName));
			NewCategoryName = string.Empty;
			NotifyPropertyChanged("NewCategoryName");
		}

		public RelayCommand CreateCategory { get; set; }

		private RelayCommand deleteCategory { get; set; }

		public ICommand DeleteCategory
		{
			get
			{
				if (deleteCategory == null)
				{
					deleteCategory = new RelayCommand(OnDeleteCategory, CanCategoryBeDeleted);
				}
				return deleteCategory;
			}
		}

		private void OnDeleteCategory(object sender)
		{
			CategoryList.Remove(SelectedCategory);
			NewCategoryName = string.Empty;
			client.DeleteCategory(SelectedCategory.Id);
			NewCategoryName = string.Empty;
			NotifyPropertyChanged("NewCategoryName");
		}

		private bool CanCategoryBeDeleted(object sender)
		{
			if (SelectedCategory == null)
			{
				return false;
			}
			return true;
		}

		private RelayCommand editCategory { get; set; }

		public ICommand EditCategory
		{
			get
			{
				if (editCategory == null)
				{
					editCategory = new RelayCommand(OnEditCategory, CanCategoryBeEdited);
				}
				return editCategory;
			}
		}

		private void OnEditCategory(object sender)
		{
			client.EditCategory(SelectedCategory, NewCategoryName);
			CategoryList = new ObservableCollection<CategoryToClient>(client.GetAllCategories());
			NotifyPropertyChanged("CategoryList");
		}

		private bool CanCategoryBeEdited(object sender)
		{
			if (SelectedCategory == null)
			{
				return false;
			}
			return true;
		}

		private CategoryToClient selectedCategory;

		public CategoryToClient SelectedCategory
		{
			get
			{
				return selectedCategory;
			}
			set
			{
				if (value != null)
				{
					selectedCategory = value;
					NewCategoryName = value.Name;
					NotifyPropertyChanged("NewCategoryName");
				}
			}
		}

		#endregion Category

		#region Article

		public List<ArticleToClient> SelectedArticle
		{
			get
			{
				return ArticleList.Where(o => o.IsSelected).ToList();
			}
		}

		private RelayCommand openEdit { get; set; }

		public ICommand OpenEdit
		{
			get
			{
				if (openEdit == null)
				{
					openEdit = new RelayCommand(OnOpenEdit);
				}
				return openEdit;
			}
		}

		private void OnOpenEdit(object param)
		{
			App.OpenEditor();
		}

		private RelayCommand openEditWithDoc { get; set; }

		public ICommand OpenEditWithDoc
		{
			get
			{
				if (openEditWithDoc == null)
				{
					openEditWithDoc = new RelayCommand(OnOpenEditWithDoc, CanOpenWithDoc);
				}
				return openEditWithDoc;
			}
		}

		private bool CanOpenWithDoc(object param)
		{
			return SelectedArticle.Count > 0;
		}

		private void OnOpenEditWithDoc(object param)
		{
			App.OpenEditor(SelectedArticle[0]);
		}

		private RelayCommand deleteArticle { get; set; }

		public ICommand DeleteArticle
		{
			get
			{
				if (deleteArticle == null)
				{
					deleteArticle = new RelayCommand(OnDeleteArticle, CanDeleteArticle);
				}
				return deleteArticle;
			}
		}

		private void OnDeleteArticle(object param)
		{
			client.DeleteArticle(SelectedArticle[0].Id);
			ArticleList = new ObservableCollection<ArticleToClient>(client.GetAllArticles(false));
			NotifyPropertyChanged("ArticleList");
		}

		private bool CanDeleteArticle(object param)
		{
			return SelectedArticle.Count > 0 && App.CurrentAuthor.IsEditor;
		}

		public void UpdateArticleList()
		{
			ArticleList = new ObservableCollection<ArticleToClient>(client.GetAllArticles(false));
			NotifyPropertyChanged("ArticleList");
		}

		#endregion Article

		#region NotApprovedArticle

		public ObservableCollection<ArticleToClient> NotApprovedArticleList { get; set; }

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
				bool isApproved = control.IsChecked.Value;
				if (isApproved)
				{
					int id = int.Parse(control.Tag.ToString());
					client.SetArticleIsApproved(id);
					NotApprovedArticleList = new ObservableCollection<ArticleToClient>(client.GetAllArticles(true));
					NotifyPropertyChanged("NotApprovedArticleList");
					
				}
			}
		}
		public void UpdateNotApprovedAuthorList()
		{
			AuthorListAll = null;
			AuthorListAll = new ObservableCollection<AuthorToClient>(client.GetAllAuthors(false));
			NotifyPropertyChanged("AuthorListAll");
		}
		#endregion NotApprovedArticle

		#region "Change Admin Status"

		private RelayCommand changeEdit { get; set; }

		public ICommand ChangeEdit
		{
			get
			{
				if (changeEdit == null)
				{
					changeEdit = new RelayCommand(OnChangeEdit);
				}
				return changeEdit;
			}
			set
			{
				if (changeEdit == null)
				{
					changeEdit = new RelayCommand(OnChangeEdit);
				}
			}
		}

		private void OnChangeEdit(object param)
		{
			CheckBox control = new CheckBox();
			control = param as CheckBox;
			if (control != null)
			{
				bool isApproved = control.IsChecked.Value;
				if (isApproved)
				{
					client.SetAuthorToEditor(int.Parse(control.Tag.ToString()));
				}
				else
				{
					client.SetAuthorNotToEditor(int.Parse(control.Tag.ToString()));
				}
				
			}
		}

		#endregion "Change Admin Status"
	}
}