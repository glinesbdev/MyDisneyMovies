using MyDisneyMovies.UI.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MyDisneyMovies.UI.ViewModels
{
    /// <summary>
    /// View model for the main window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// The window this view model controls
        /// </summary>
        private Window _window;

        /// <summary>
        /// Outer margin size for the window
        /// </summary>
        private int _outerMarginSize = 5;

        /// <summary>
        /// The radius for the edge of the window
        /// </summary>
        private int _windowRadius = 5;

        #endregion

        #region Public Members

        /// <summary>
        /// The smallest width for the window
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 400;

        /// <summary>
        /// The smallest height for the window
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 400;

        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public int ResizeBorder { get; set; } = 6;

        /// <summary>
        /// The thickness of the resize border around the window
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

        /// <summary>
        /// The padding for the innter content of the window
        /// </summary>
        public Thickness InnerContentPadding { get; set; } = new Thickness(0);

        /// <summary>
        /// The outer margin of the window - allows for drop shadow around the window
        /// </summary>
        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get => _outerMarginSize;
            set => _outerMarginSize = value;
        }

        /// <summary>
        /// The radius for the edges of the window
        /// </summary>
        public int WindowRadius
        {
            get => _windowRadius;
            set => _windowRadius = value;
        }

        /// <summary>
        /// The corner radius of the window
        /// </summary>
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        /// <summary>
        /// The height of the title bar / caption of the window
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        /// <summary>
        /// The height of the title bar / caption of the window
        /// </summary>
        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }


        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.MoviesList;

        #endregion

        #region Commands

        /// <summary>
        /// Command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// Command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// Command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// Command to get system menu
        /// </summary>
        public ICommand MenuCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public WindowViewModel(Window window)
        {
            _window = window;

            // Listen for changes in the window state
            _window.StateChanged += (sender, e) => 
            {
                WindowResized();
            };

            // Create window commands
            MinimizeCommand = new RelayCommand(() => _window.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => _window.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => _window.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(_window, GetMousePosition()));
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Get the position of the mouse relative to the window
        /// </summary>
        /// <returns></returns>
        private Point GetMousePosition()
        {
            Point position = Mouse.GetPosition(_window);
            return new Point(position.X + _window.Left, position.Y + _window.Top);
        }

        /// <summary>
        /// Fire property changed events when the window resizes
        /// </summary>
        private void WindowResized()
        {
            OnPropertyChanged(nameof(ResizeBorderThickness));
            OnPropertyChanged(nameof(OuterMarginSize));
            OnPropertyChanged(nameof(OuterMarginSizeThickness));
            OnPropertyChanged(nameof(WindowRadius));
            OnPropertyChanged(nameof(WindowCornerRadius));
        }

        #endregion
    }
}
