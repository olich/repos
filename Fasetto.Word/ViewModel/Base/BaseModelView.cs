

using System.ComponentModel;

namespace Fasetto.Word
{
    /// <summary>
    /// a base classs for view model 
    /// </summary>
    public class BaseModelView : INotifyPropertyChanged
    {

        /// <summary>
        /// The property that is fired when any child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged =(sender, e) => {};

        /// <summary>
        ///  Call this to fire a <see cref="PropertyChangedEventHandler "/> event
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
