using mshtml;
using NewsdeskWPFClient.WYSIWYG.XAML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NewsdeskWPFClient.WYSIWYG.Models
{
	public static class Gui
	{
		public static WPFWebBrowser webBrowser;
		public static HtmlEditor htmlEditor;

		public static List<Item> RibbonBoxFormatInit()
		{
			List<Item> list = new List<Item>();
			list.Add(new Item("<p>", "Paragraph"));
			list.Add(new Item("<h1>", "Heading 1"));
			list.Add(new Item("<h2>", "Heading 2"));
			list.Add(new Item("<h3>", "Heading 3"));
			list.Add(new Item("<h4>", "Heading 4"));
			list.Add(new Item("<h5>", "Heading 5"));
			list.Add(new Item("<h6>", "Heading 6"));
			list.Add(new Item("<address>", "Address"));
			list.Add(new Item("<pre>", "Preformat"));
			return list;
		}

		public static List<string> RibbonBoxFontSizeInit()
		{
			List<string> items = new List<string>();

			for (int x = 1; x <= 7; x++)
			{
				items.Add(x.ToString());
			}
			return items;
		}

		public static void SettingsFontColor()
		{
			webBrowser.doc = webBrowser.webBrowser.Document as HTMLDocument;
			if (webBrowser.doc != null)
			{
				System.Windows.Media.Color col = DialogBox.Pick();
				string color = string.Format("#{0:X2}{1:X2}{2:X2}", col.R, col.G, col.B);
				webBrowser.doc.execCommand("ForeColor", false, color);
			}
		}

		public static void SettingsAddImage()
		{
			using (WYSIWYG.XAML.Image image = new WYSIWYG.XAML.Image(webBrowser.doc))
			{
				image.ShowDialog();
			}

		}

		public static string GetDocText()
		{
			dynamic doc = webBrowser.doc;
			var htmlText = doc.documentElement.InnerHtml;
			return Convert.ToString(htmlText);

		}

		
		public static void RibbonBoxFonts(ComboBox RibbonBoxFonts)
		{
			var doc = webBrowser.webBrowser.Document as HTMLDocument;
			if (doc != null)
			{
				doc.execCommand("FontName", false, RibbonBoxFonts.SelectedItem.ToString());
			}
		}

		public static void RibbonBoxFontHeight(ComboBox RibbonBoxFontHeight)
		{
			IHTMLDocument2 doc = webBrowser.webBrowser.Document as IHTMLDocument2;
			if (doc != null)
			{
				doc.execCommand("FontSize", false, RibbonBoxFontHeight.SelectedItem);
			}
		}

		public static void RibbonBoxFormat(ComboBox RibbonBoxFormat)
		{
			string ID = ((Item)(RibbonBoxFormat.SelectedItem)).Value;

			webBrowser.doc = webBrowser.webBrowser.Document as HTMLDocument;
			if (webBrowser.doc != null)
			{
				webBrowser.doc.execCommand("FormatBlock", false, ID);
			}
		}

		public static void NewDocument(string text)
		{
			webBrowser.newWb(text);
		}

}
	}
