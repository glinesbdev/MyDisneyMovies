using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyDisneyMovies.UI.ViewModels
{
    /// <summary>
    /// Base view model that has the ability to be notified of property changes
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
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
        /// <param name="name"></param>
        public void OnProprtyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
