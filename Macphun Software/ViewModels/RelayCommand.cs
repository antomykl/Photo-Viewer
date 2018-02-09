using System;
using System.Windows.Input;

namespace Photoviewer.ViewModels
{
    public class RelayCommand : ICommand
    {       
        private readonly Action<object> execute;

        private readonly Predicate<object> canExecute;                
        
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this.canExecute = canExecute;
            this.execute = execute;
        }

        public RelayCommand(Action<object> execute) : this(execute, null) { }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) => canExecute == null ? true : canExecute(parameter);      

        public void Execute(object parameter)
        {
            if (!CanExecute(parameter))
                return;

            execute(parameter);      
        }        
    }
}
