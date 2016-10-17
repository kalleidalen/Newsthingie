using NewsdeskWPFClient.AdminServiceReference;
using NewsdeskWPFClient.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace NewsdeskWPFClient.ViewModel
{
	public class AcceptAuthorViewModel: BaseViewModel
	{
		private NewsdeskServiceClient client;
		public ObservableCollection<AuthorToClient> AuthorList { get; set; }

		public AcceptAuthorViewModel()
		{
			client = new NewsdeskServiceClient();
			AuthorList = new ObservableCollection<AuthorToClient>(client.GetAllAuthors(true));
		
		}
		private bool isSelected;

		public bool IsSelected
		{
			get { return isSelected; }
			set { isSelected = value; }
		}
		
		private RelayCommand changeState { get; set; }

		public ICommand ChangeState
		{
			get
			{
				if (changeState == null)
				{
					changeState = new RelayCommand(OnChangeState);
				}
				return changeState;
			}
			set
			{
				if (changeState == null)
				{
					changeState = new RelayCommand(OnChangeState);
				}
				
			}
		}
		private void OnChangeState(object param)
		{
			CheckBox control = new CheckBox();
			control = param as CheckBox;
			if (control!=null)
			{
				bool isApproved = control.IsChecked.Value;
				if (isApproved)
				{
					client.AuthorIsApproved(int.Parse(control.Tag.ToString()));
					AuthorList = new ObservableCollection<AuthorToClient>(client.GetAllAuthors(true));
					NotifyPropertyChanged("AuthorList");
					App.UpdateAuthorListAfterApprove();

				}
			}
		}
	}
}
