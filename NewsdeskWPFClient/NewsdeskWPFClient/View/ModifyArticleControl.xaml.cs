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
using System.Windows.Navigation;
using System.Windows.Shapes;
using NewsdeskWPFClient.ViewModel;

namespace NewsdeskWPFClient.View
{
	/// <summary>
	/// Interaction logic for ModifyArticleControl.xaml
	/// </summary>
	public partial class ModifyArticleControl : UserControl
	{
		public ModifyArticleViewModel vm;
		public ModifyArticleControl()
		{
			InitializeComponent();
			vm = new ModifyArticleViewModel();
			DataContext = vm;
		}
	}
}
