using NewsdeskWPFPaperClient.View;
using NewsdeskWPFPaperClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NewsdeskWPFPaperClient
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private static MainView mainView;
		private void Application_Startup(object sender, StartupEventArgs e)
		{
			mainView = new MainView();
			MainViewModel mainViewModel = new MainViewModel();

			mainView.DataContext = mainViewModel;
			mainView.Show();
		}

		public static void ShowMessage(string message, string caption)
		{

			MessageBoxButton buttons = MessageBoxButton.OK;
			MessageBoxImage icon = MessageBoxImage.Information;
			MessageBox.Show(message, caption, buttons, icon);
		}
	}
}
