using System.Windows;
using System.Windows.Controls;

namespace NewsdeskWPFPaperClient.Utility
{
	public static class WebBrowserUtility
	{
		public static readonly DependencyProperty BindableSourceProperty =
			DependencyProperty.RegisterAttached("BindableSource", typeof(string), typeof(WebBrowserUtility), new UIPropertyMetadata(null, BindableSourcePropertyChanged));

		public static string GetBindableSource(DependencyObject obj)
		{
			return (string)obj.GetValue(BindableSourceProperty);
		}

		public static void SetBindableSource(DependencyObject obj, string value)
		{
			obj.SetValue(BindableSourceProperty, value);
		}

		public static void BindableSourcePropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{

			
			string startText = @"<!DOCTYPE html><html lang=""sv"" xmlns=""http://www.w3.org/1999/xhtml""><head><meta charset=""utf-8"" /><title></title>";
			string afterJavaTag="</head><body>";
			string docText = e.NewValue as string;
			string endText ="</body></html>";
			WebBrowser browser = o as WebBrowser;
			if (browser != null)
				browser.NavigateToString(startText+afterJavaTag+docText+endText);
			
		}
	}
}