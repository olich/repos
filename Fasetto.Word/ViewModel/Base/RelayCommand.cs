using System;
using System.Windows.Input;

namespace Fasetto.Word 
{
    /// <summary>
    /// A basic comamand that run an action 
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Private Member

        /// <summary>
        /// The action to run 
        /// </summary>
        Action mAction;
        #endregion

        #region Public Event
        /// <summary>
        /// The event that fires when the <see cref="CanExecute(object)"/> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e)=>{ };

        #endregion

        /// <summary>
        /// Default constructor 
        /// </summary>
        #region Contructor
        public RelayCommand(Action  action)
        {
            mAction = action;
         }

        #endregion

        #region Command methods
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Execute the command Action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            mAction();
        }

        #endregion
    }
}
