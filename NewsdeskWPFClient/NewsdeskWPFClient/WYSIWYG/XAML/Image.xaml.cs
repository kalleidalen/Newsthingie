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
using mshtml;
using System.Windows.Forms;
using System.IO;

namespace NewsdeskWPFClient.WYSIWYG.XAML
{
	/// <summary>
	/// Interaction logic for Image.xaml
	/// </summary>
	public partial class Image : Window, IDisposable
	{
		public HTMLDocument doc;

		public Image(HTMLDocument Doc)
		{
			InitializeComponent();
			doc = Doc;
		}

		private void Window_Initialized(object sender, EventArgs e)
		{
			description.Focus();
		}

		private void ButtonOK_Click(object sender, RoutedEventArgs e)
		{
			if (doc != null)
			{
				dynamic r = doc.selection.createRange();
				r.pasteHTML(string.Format(@"<img alt=""{1}"" src=""{0}"">", link.Text, description.Text));
				this.Hide();
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var appDir = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\ArticleImages\\";

			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.InitialDirectory = @"C:\";
				openFileDialog.Filter = "jpg files (*.jpg)|*.jpg|All files (*.png.*)|*.png|All files (*.gif)|*.gif|All files (*.*)|*.*";
				openFileDialog.RestoreDirectory = true;

				DialogResult result = openFileDialog.ShowDialog();
				if (result == System.Windows.Forms.DialogResult.OK)
				{
					string filename = System.IO.Path.GetFileName(openFileDialog.FileName);
					File.Copy(openFileDialog.FileName, appDir + filename, true);
					link.Text = appDir + filename;
				}
			}
		}

		private void ButtonCancel_Click(object sender, RoutedEventArgs e)
		{
			this.Hide();
			Dispose();
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
	}
}