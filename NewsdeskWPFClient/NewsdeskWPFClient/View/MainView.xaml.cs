using NewsdeskWPFClient.WYSIWYG.XAML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace NewsdeskWPFClient.View
{
	/// <summary>
	/// Interaction logic for main.xaml
	/// </summary>
	public partial class MainView : Window
	{
		public MainView()
		{
			InitializeComponent();
			
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			App.CloseApp();
		}

	}
}
