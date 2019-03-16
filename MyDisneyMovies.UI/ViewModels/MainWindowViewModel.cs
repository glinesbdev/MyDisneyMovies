using MyDisneyMovies.Core;
using MyDisneyMovies.Core.Entities;
using MyDisneyMovies.Core.Enums;
using MyDisneyMovies.Core.Factories;
using MyDisneyMovies.Core.IoC;
using MyDisneyMovies.Core.Utils;
using System.Windows;
using System.Windows.Input;

namespace MyDisneyMovies.UI.ViewModels
{
    /// <summary>
    /// View model for the main window
    /// </summary>
    public class MainWindowViewModel : BaseEntity
    {
        #region Private Members

        private Window _window;

        private int _outerMarginSize = 10;

        #endregion

        #region Public Members

        /// <summary>
        /// Minimum height of the window
        /// </summary>
        public int MinimumWindowHeight { get; set; } = 500;

        /// <summary>
        /// Minimum width of the window
        /// </summary>
        public int MinimumWindowWidth { get; set; } = 800;

        /// <summary>
        /// Height of the window title
        /// </summary>
        public int WindowTitleGridHeight { get; set; } = 42;

        /// <summary>
        /// Title of the window
        /// </summary>
        public string WindowCaption { get; set; } = "My Disney Movies";

        /// <summary>
        /// Caption height of the window
        /// </summary>
        public int WindowCaptionHeight { get; set; } = 36;

        /// <summary>
        /// Height of the title bar / caption of the window
        /// </summary>
        public GridLength WindowTitleGridLength => new GridLength(WindowCaptionHeight + ResizeBorderSize);

        /// <summary>
        /// Determine if the window is maximized
        /// </summary>
        public bool Borderless => _window.WindowState == WindowState.Maximized;

        /// <summary>
        /// Amount to determine the resizable border of the window
        /// </summary>
        public int ResizeBorderSize => Borderless ? 0 : 5;

        /// <summary>
        /// Determines the thickness around the window to grab the lines to resize
        /// </summary>
        public Thickness ResizeBorderThickness => new Thickness(ResizeBorderSize + OuterMarginSize);

        /// <summary>
        /// Get the current application entity
        /// </summary>
        public ApplicationEntity Application => IoC.Container.Get<ApplicationEntity>();

        /// <summary>
        /// Margin offset of the system button in full screen mode
        /// </summary>
        public Thickness SystemButtonOffset => Borderless ? new Thickness(10.0, 5.0, 0, 0) : new Thickness(0);

        /// <summary>
        /// Margin offset of the window close button in full screen mode
        /// </summary>
        public Thickness WindowCloseButtonsOffset => Borderless ? new Thickness(0, 0, 7.0, 0) : new Thickness(0);

        /// <summary>
        /// The outer margin size of the window for the outer drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get => Borderless ? 0 : _outerMarginSize;
            set => _outerMarginSize = value;
        }

        /// <summary>
        /// The margin around the window that allows for drop shadows
        /// </summary>
        public Thickness OuterMarginSizeThickness => new Thickness(OuterMarginSize);

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor without a <see cref="Window"/> object.
        /// Used for design time.
        /// </summary>
        public MainWindowViewModel() { }

        /// <summary>
        /// Default constructor that takes a <see cref="Window"/> object
        /// </summary>
        public MainWindowViewModel(Window window)
        {
            _window = window;

            // When the window resizes...
            _window.StateChanged += (sender, e) =>
            {
                // Update properties
                WindowResized();
            };

            // Create commands
            MinimizeWindow = new RelayCommand(() => window.WindowState = WindowState.Minimized);
            MaximizeWindow = new RelayCommand(() => window.WindowState ^= WindowState.Maximized);
            CloseWindow = new RelayCommand(() => window.Close());
            WindowSystemMenu = new RelayCommand(() => SystemCommands.ShowSystemMenu(_window, GetMousePosition()));
        }

        #endregion

        #region Commands

        public ICommand MinimizeWindow { get; set; }

        public ICommand MaximizeWindow { get; set; }

        public ICommand CloseWindow { get; set; }

        public ICommand WindowSystemMenu { get; set; }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Gets the position of the mouse on the screen
        /// </summary>
        /// <returns></returns>
        private Point GetMousePosition()
        {
            var position = Mouse.GetPosition(_window);

            return new Point(position.X + _window.Left, position.Y + _window.Top);
        }

        /// <summary>
        /// Updates all the requied window properties upon a window resize
        /// </summary>
        private void WindowResized()
        {
            OnPropertyChanged(nameof(Borderless));
            OnPropertyChanged(nameof(ResizeBorderSize));
            OnPropertyChanged(nameof(ResizeBorderThickness));
            OnPropertyChanged(nameof(OuterMarginSize));
            OnPropertyChanged(nameof(OuterMarginSizeThickness));
            OnPropertyChanged(nameof(SystemButtonOffset));
            OnPropertyChanged(nameof(WindowCloseButtonsOffset));
        }

        #endregion
    }
}
