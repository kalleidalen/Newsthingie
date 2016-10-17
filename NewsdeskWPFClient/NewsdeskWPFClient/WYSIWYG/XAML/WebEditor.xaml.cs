using NewsdeskWPFClient.WYSIWYG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Web;
using NewsdeskWPFClient.AdminServiceReference;

namespace NewsdeskWPFClient.WYSIWYG.XAML
{
	public partial class WebEditor : Window
	{
		public  ArticleToClient SelectedArticle;

		public WebEditor()
		{
			InitializeComponent();
		}

		
		private void SettingsBold_Click(object sender, RoutedEventArgs e)
		{
			Format.bold();
		}

		private void SettingsItalic_Click(object sender, RoutedEventArgs e)
		{
			Format.Italic();
		}

		private void SettingsUnderLine_Click(object sender, RoutedEventArgs e)
		{
			Format.Underline();
		}

		private void SettingsRightAlign_Click(object sender, RoutedEventArgs e)
		{
			Format.Underline();
		}

		private void SettingsLeftAlign_Click(object sender, RoutedEventArgs e)
		{
			Format.JustifyLeft();
		}

		private void SettingsCenter2_Click(object sender, RoutedEventArgs e)
		{
			Format.JustifyCenter();
		}

		private void SettingsJustifyRight_Click(object sender, RoutedEventArgs e)
		{
			Format.JustifyRight();
		}

		private void SettingsJustifyFull_Click(object sender, RoutedEventArgs e)
		{
			Format.JustifyFull();
		}

		private void SettingsInsertOrderedList_Click(object sender, RoutedEventArgs e)
		{
			Format.InsertOrderedList();
		}

		private void SettingsBullets_Click(object sender, RoutedEventArgs e)
		{
			Format.InsertUnorderedList();
		}

		private void SettingsOutIdent_Click(object sender, RoutedEventArgs e)
		{
			Format.Outdent();
		}

		private void SettingsIdent_Click(object sender, RoutedEventArgs e)
		{
			Format.Indent();
		}

		private void SettingsFontColor_Click(object sender, RoutedEventArgs e)
		{
			Gui.SettingsFontColor();
		}
						
		private void SettingsAddImage_Click(object sender, RoutedEventArgs e)
		{
			Gui.SettingsAddImage();
		}

		private void RibbonButtonSave_Click(object sender, RoutedEventArgs e)
		{
			bool foundError = false;
			string text = Gui.GetDocText();
		

			ArticleControl.vm.ArticleBody = text;
			string encodedText = App.StripHTML(text);
			int start=0, stop=0;
			if (text.IndexOf("<BODY>") != -1){start = text.IndexOf("<BODY>")+6;}
			if (text.IndexOf("</BODY>") != -1){	stop = text.IndexOf("</BODY>");}
			if (start>0 && stop >0){text = text.Substring(start,stop-start);}
			ArticleControl.vm.ArticleBody = text;
			StringBuilder error = new StringBuilder("Kan inte spara, för följande information saknas: ");
			if (string.IsNullOrWhiteSpace(ArticleControl.vm.Title))
			{
				foundError = true;
				error.Append("Titel, ");
			}
			if (string.IsNullOrWhiteSpace(ArticleControl.vm.Preamble))
			{
				foundError = true;
				error.Append("Ingress, ");
			}
			if (ArticleControl.vm.SelectedAuthor.Count<1)
			{
				foundError = true;
				error.Append("Författare, ");
			}
			if (ArticleControl.vm.SelectedCategory.Count<1)
			{
				foundError = true;
				error.Append("Kategori, ");
			}
			if (string.IsNullOrWhiteSpace(encodedText))
			{
				foundError = true;
				error.Append("Artikel text, ");
			}
			if (!foundError){
				if (SelectedArticle==null)
				{
					ArticleControl.vm.CreateArticle();
				}
				else
				{
					ArticleControl.vm.UpdateArticle(SelectedArticle.Id);
				}
					
				App.CloseEditor();
			}
			else
			{
				string errorText = error.ToString().Substring(0, error.ToString().Length-2) +".";
				App.ShowMessage(errorText, "Information saknas");
			}
		
		}

		private void RibbonComboboxFonts_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Gui.RibbonBoxFonts(RibbonComboboxFonts);
		}

		private void RibbonComboboxFontHeight_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Gui.RibbonBoxFontHeight(RibbonComboboxFontHeight);
		}

		private void RibbonComboboxFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Gui.RibbonBoxFormat(RibbonComboboxFormat);
		}

		
		
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			Gui.webBrowser = webBrowserEditor;
			Gui.htmlEditor = HtmlEditor1;
			Initialization.webeditor = this;
			;
			if (SelectedArticle!=null)
			{
				ArticleControl.vm.SetSelectedArticle(SelectedArticle);
				Gui.NewDocument(SelectedArticle.ArticleBody);
			}
			else
			{
				Gui.NewDocument("");
			}
			Initialization.RibbonBoxFontsInitialization();
			Initialization.RibbonBoxFontSizeInitialization();
			Initialization.RibbonBoxFormatInitialization();
		}

		private void RibbonTabHeader()
		{
			webBrowserEditor.Visibility = Visibility.Collapsed;
			HtmlEditor1.Visibility = Visibility.Collapsed;
			Header.Visibility = Visibility.Visible;
		}

		private void RibbonTabDec()
		{
			webBrowserEditor.Visibility = Visibility.Visible;
			HtmlEditor1.Visibility = Visibility.Collapsed;
			Header.Visibility = Visibility.Collapsed;
		}

		private void RibbonSelectedChange(object sender, SelectionChangedEventArgs e)
		{
			Ribbon control = sender as Ribbon;
			var tab = control.SelectedItem as RibbonTab;
			if (tab.Header.Equals("Rubrik och ingress"))
			{
				RibbonTabHeader();
			}
			if (tab.Header.Equals("Brödtext"))
			{
				RibbonTabDec();
			}
			
		}
	}
}