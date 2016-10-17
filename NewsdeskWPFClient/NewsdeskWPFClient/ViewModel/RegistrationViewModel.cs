using NewsdeskWPFClient.AdminServiceReference;
using NewsdeskWPFClient.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NewsdeskWPFClient.ViewModel
{
	public class RegistrationViewModel: BaseViewModel
	{
		private NewsdeskServiceClient client;
		public RegistrationViewModel()
		{
			client = new NewsdeskServiceClient();
		}
		#region Fields
		private string firstName;

		public string FirstName
		{
			get { return firstName; }
			set 
			{ 
				firstName = value;
				NotifyPropertyChanged("FirstName");
			}
		}
		private string lastName;

		public string LastName
		{
			get { return lastName; }
			set
			{
				lastName = value;
				NotifyPropertyChanged("LastName");
			}
		}
		private string email;

		public string Email
		{
			get { return email; }
			set 
			{ 
				email = value;
				NotifyPropertyChanged("Email");
			}
		}
		private string password;

		public string Password
		{
			get { return password; }
			set 
			{
				password = value;
				NotifyPropertyChanged("Password");
			}
		}
		private string confirmPassword;

		public string ConfirmPassword
		{
			get { return confirmPassword; }
			set 
			{ 
				confirmPassword = value;
				NotifyPropertyChanged("ConfirmPassword");
			}
		}
		
		
		#endregion
		#region Commands
		private RelayCommand openCommand;
		public ICommand OpenLink
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
			App.OpenLoginFromRegister();
		}
	
		private RelayCommand createCommand;
		
		public ICommand Submit
		{
			get
			{
				if (createCommand == null)
				{
					createCommand = new RelayCommand(OnCreateAuthor, CanAuthorBeCreated);
				}
				return createCommand;
			}
		}
		private bool CanAuthorBeCreated(object param)
		{
			ErrorMessage = string.Empty;
			NotifyPropertyChanged("ErrorMessage");
			bool isEmail, infoCorrect = false;
			if (!string.IsNullOrWhiteSpace(Email))
			{
				isEmail = Regex.IsMatch(Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
				infoCorrect = isEmail && !string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName); ;

			}
			if (!string.IsNullOrWhiteSpace(Email) && !infoCorrect)
			{
				ErrorMessage = "Informationen du har angivit är felaktig.";
				NotifyPropertyChanged("ErrorMessage");
				

			}
			return infoCorrect;	
			
		}
		private string errorMessage;
		public string ErrorMessage
		{
			get
			{
				return errorMessage;
			}
			set
			{
				if (value != null)
				{
					errorMessage = value;
					NotifyPropertyChanged("ErrorMessage");
				}
			}
		}

		private void OnCreateAuthor(object param)
		{
			Author newAuthor = new Author()
			{
				FirstName=FirstName,
				LastName=LastName,
				Email=Email,
				IsApproved=false,
				Password=Password,
				
			};
			int id =client.CreateAuthor(newAuthor);
			client.SendEmailAccountCreated(id);
			client.SendEmailToEditorNewAccountCreated();
			App.ShowMessage("Du är nu registerad.\nDu får ett mejl när ditt konto är godkänt.", "Kontot är skapat");
			
				App.CloseApp();
		}

		#endregion



	
	}
}
