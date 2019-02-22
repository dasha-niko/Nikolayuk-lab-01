using System;

using System.Windows.Input;

namespace Nikolayuk01
{
    public class RelayCommand<T> : ICommand
    {
        #region Fields
        readonly Action<T> _execute;
        readonly Predicate<T> _canExecute;
        #endregion
        #region Constructors
 
        /// Initializes a new instance/>.
        
        /// <param name="execute">Delegate to execute when Execute is called on the command.  This can be null to just hook up a CanExecute delegate.</param>
        /// <remarks><seealso cref="CanExecute"/> will always return true.</remarks>
        public RelayCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        /// Creates a new command.
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }
        #endregion
        #region ICommand Members
        ///Defines the method that determines whether the command can execute in its current state.
        ///<param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        ///true if this command can be executed; otherwise, false.
    
        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke((T)parameter) ?? true;
        }

        ///Occurs when changes occur that affect whether or not the command should execute.
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        ///Defines the method to be called when the command is invoked.
        ///<param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        #endregion
    }
}
