using mshtml;
using NewsdeskWPFClient.WYSIWYG.Models;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace NewsdeskWPFClient.WYSIWYG.XAML
{
	/// <summary>
	/// Interaction logic for WPFWebBrowser.xaml
	/// </summary>
	public partial class WPFWebBrowser : UserControl
	{
		public HTMLDocument doc;
		public WebBrowser webBrowser;
		private string text;

		public WPFWebBrowser()
		{
			InitializeComponent();
		}

		public void newWb(string url)
		{
			if (!string.IsNullOrWhiteSpace(url))
			{
				text = url;
				url = string.Empty;
			}
			
			if (webBrowser != null)
			{
				webBrowser.LoadCompleted -= completed;

				webBrowser.Dispose();
				gridwebBrowser.Children.Remove(webBrowser);
			}

			if (doc != null)
			{
				doc.clear();
			}

			webBrowser = new WebBrowser();
			webBrowser.LoadCompleted += completed;
			gridwebBrowser.Children.Add(webBrowser);

			Script.HideScriptErrors(webBrowser, true);

			if (url == "")
			{
				webBrowser.NavigateToString(Properties.Resources.New);
				doc = webBrowser.Document as HTMLDocument;
				doc.designMode = "On";
				Format.doc = doc;

				return;
			}
			doc = webBrowser.Document as HTMLDocument;
			Format.doc = doc;
		}

		private void completed(object sender, NavigationEventArgs e)
		{
			doc = webBrowser.Document as HTMLDocument;
			doc.designMode = "On";
			var body = doc.body;
			body.innerHTML = text;
		}
	}
}