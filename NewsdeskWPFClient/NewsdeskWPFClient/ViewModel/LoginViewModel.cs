using NewsdeskWPFClient.AdminServiceReference;
using NewsdeskWPFClient.Command;
using NewsdeskWPFClient.View;
using System;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace NewsdeskWPFClient.ViewModel
{
	public class LoginViewModel : BaseViewModel
	{
		public RelayCommand LoginCommand { get; set; }
		public RelayCommand LogoutCommand { get; set; }
		public string ErrorMessage { get; set; }
		private NewsdeskServiceClient client;
		
		public LoginViewModel()
		{
			client = new NewsdeskServiceClient();
			LoginCommand = new RelayCommand(OnLogin, CanLogin);
			LogoutCommand = new RelayCommand(OnLogout, CanLogout);
			
		}

		private bool CanLogin(object param)
		{
			bool isEmail, infoCorrect=false;
			if (!string.IsNullOrWhiteSpace(txtEmail))
			{
				isEmail = Regex.IsMatch(TxtEmail, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
				infoCorrect = isEmail & !string.IsNullOrWhiteSpace(TxtPassword);

				if (!infoCorrect)
				{
					ErrorMessage = "Informationen du har angivit är felaktig.";

				}
				
			}
			return infoCorrect;
		}

		private void OnLogin(object param)
		{
			Authenticate();
		}

		private bool CanLogout(object param)
		{
			return App.CurrentAuthor!=null;
		}

		private void OnLogout(object param)
		{
			App.CurrentAuthor = null;
		}

		private string txtEmail;

		public string TxtEmail
		{
			get { return txtEmail; }
			set
			{
				txtEmail = value;
				NotifyPropertyChanged("TxtEmail");
			}
		}

		private string txtPassword;

		public string TxtPassword
		{
			get { return txtPassword; }
			set
			{
				txtPassword = value;
				NotifyPropertyChanged("TxtPassword");
			}
		}
		#region Commands
		private RelayCommand openCommand;
		public ICommand Register
		{
			get
			{
				if (openCommand == null)
				{
					openCommand = new RelayCommand(OnOpenLink);
				}
				return openCommand;
			}
		}

		private void OnOpenLink(object param)
		{
			App.OpenRegister();
		}
	
		
		public void Authenticate()
		{
			ErrorMessage = string.Empty;

			App.CurrentAuthor = client.ValidateAuthorLogin(TxtEmail, TxtPassword);
			if (App.CurrentAuthor != null)
			{	client.SendNotDeliveredMail();
				App.OpenMainAfterLogin();

			}
			else
			{
				ErrorMessage = "Inloggningen misslyckades. Det kan bero på fel uppgifter\neller att ditt konto inte blivit godkänt.";
				NotifyPropertyChanged("ErrorMessage");
			}
		}

		#endregion
		
	}
}