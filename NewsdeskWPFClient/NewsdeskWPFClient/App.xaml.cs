using NewsdeskWPFClient.AdminServiceReference;
using NewsdeskWPFClient.View;
using NewsdeskWPFClient.ViewModel;
using NewsdeskWPFClient.WYSIWYG.XAML;
using System.Text.RegularExpressions;
using System.Windows;

namespace NewsdeskWPFClient
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private static LoginView loginView;
		private static RegistrationView regView;
		private static MainViewModel mvm;
		private static WebEditor editor;
		public static AuthorToClient CurrentAuthor;


		private void Application_Startup(object sender, StartupEventArgs e)
		{
			loginView = new LoginView();
			LoginViewModel loginViewModel = new LoginViewModel();
			
			loginView.DataContext = loginViewModel;
			loginView.Show();
		}
		public static void OpenMainAfterLogin()
		{
			loginView.Hide();
			mvm = new MainViewModel();
			MainView view = new MainView();
			view.DataContext = mvm;
			view.ShowDialog();
		
		}
		public static void UpdateAuthorListAfterApprove()
		{
			mvm.UpdateNotApprovedAuthorList();
		}

		public static void OpenRegister()
		{
			loginView.Hide();
			RegistrationViewModel rvm = new RegistrationViewModel();
			regView = new RegistrationView();
			regView.DataContext = rvm;
			regView.ShowDialog();
		}
		public static void OpenEditor()
		{
			editor = new WebEditor();
			editor.Show();
		}

		public static void OpenEditor(ArticleToClient SelectedArticle)
		{
			editor = new WebEditor();
			editor.SelectedArticle = SelectedArticle;
			editor.Show();
			
		}
		public static void CloseEditor()
		{
			editor.Close();
			mvm.UpdateArticleList();
		}
		public static void OpenLoginFromRegister()
		{
			loginView.Show();
			regView.Close();
		}

		public static void ShowMessage(string message, string caption)
		{
			
			MessageBoxButton buttons = MessageBoxButton.OK;
			MessageBoxImage icon = MessageBoxImage.Information;
			MessageBox.Show(message, caption, buttons, icon);
		}
		public static string StripHTML(string input)
		{
			string temp =Regex.Replace(input, "<.*?>", string.Empty);
			return temp.Replace("new\r\n\r\n\np {\nmargin-bottom: 0;\nmargin-top: 0;\n}\n\r\n\r\n\r\n", "");


		}
		public static void CloseApp()
		{
			System.Environment.Exit(0);
		}
	}
}