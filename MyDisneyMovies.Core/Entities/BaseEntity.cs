using System.ComponentModel;

namespace MyDisneyMovies.Core.Entities
{
    /// <summary>
    /// Base entity that has the ability to be notified of property changes
    /// </summary>
    public class BaseEntity : INotifyPropertyChanged
    {
        #region Public Events

        /// <summary>
        /// Event to fire when a property is changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        #endregion

        #region Public Methods

        /// <summary>
        /// Method to use to fire the property changed event
        /// </summary>
        /// <param name="name">Name of the property to update</param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
