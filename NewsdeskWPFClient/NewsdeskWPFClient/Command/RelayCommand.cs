using System;
using System.Windows.Input;

namespace NewsdeskWPFClient.Command
{
	public class RelayCommand : ICommand
	{
		private Action<object> execute;
		private Func<object, bool> canExecute;

		public RelayCommand(Action<object> execute)
			: this(execute, null)
		{
		}

		public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
		{
			this.canExecute = canExecute;
			this.execute = execute;
		}

		public bool CanExecute(object parameter)
		{
			if (canExecute != null)
			{
				return canExecute(parameter);
			}
			return true;
		}

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public void Execute(object parameter)
		{
			//users.remove(selected);
			execute(parameter);
		}
	}
}