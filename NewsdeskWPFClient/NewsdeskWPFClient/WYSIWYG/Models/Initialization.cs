using NewsdeskWPFClient.WYSIWYG.XAML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;


namespace NewsdeskWPFClient.WYSIWYG.Models
{
	public static class Initialization
	{
		public static WebEditor webeditor;

		public static void RibbonBoxFontsInitialization()
		{
			webeditor.RibbonComboboxFonts.ItemsSource = Fonts.SystemFontFamilies;
			webeditor.RibbonComboboxFonts.Text = "Times New Roman";
		}

		public static void RibbonBoxFormatInitialization()
		{
			webeditor.RibbonComboboxFormat.ItemsSource = Gui.RibbonBoxFormatInit();
			webeditor.RibbonComboboxFormat.SelectedIndex = 0;
		}

		public static void RibbonBoxFontSizeInitialization()
		{
			webeditor.RibbonComboboxFontHeight.ItemsSource = Gui.RibbonBoxFontSizeInit();
			webeditor.RibbonComboboxFontHeight.Text = "3";
		}
	}
}
