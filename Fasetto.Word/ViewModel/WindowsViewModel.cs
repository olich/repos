using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;

namespace Fasetto.Word
{
    /// <summary>
    /// View model for the custom flat window 
    /// </summary>
    public class WindowsViewModel : BaseModelView 
    {
        #region private members 
        Window mWindow;

        /// <summary>
        ///  the margin around the window to allow a drop shadow
        /// </summary>
        private int mOuterMarginSize = 10;
        
        /// <summary>
        /// the radius of the edges of the windows
        /// </summary>
        private int mWindowRadius = 10;

        #endregion

        #region Public properties

        /// <summary>
        ///  the smallest width the window can go to
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 400;
        /// <summary>
        /// The smalled height the windows can go to
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 400;
        /// <summary>
        ///  the size of the resize border aroung the window
        /// </summary>
        public int ResizeBorder { get; set; } = 6; 

        /// <summary>
        /// The size of the rsize border around the window, takin into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness  { get { return new Thickness(ResizeBorder + OuterMarginSize ); } }

        /// <summary>
        /// The paddind of inner content of the main window
        /// </summary>
        public Thickness InnerContentPadding { get { return new Thickness(ResizeBorder  ); } }


        
        public int  OuterMarginSize { get { return mWindow.WindowState == WindowState.Maximized ? 0:  mOuterMarginSize; }
            set { mOuterMarginSize = value; }
        }

        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }
         
        public int WindowRadius
        {
            get { return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius ; }
            set { mWindowRadius = value; }
        }


        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        /// <summary>
        /// The height of the title bar / caption of the window
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight+ ResizeBorder); } }

        #endregion

        #region Commands

        /// <summary>
        ///  the command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        ///  the command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        ///  the command to maxcloseimize the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

    /// <summary>
    ///  the command to maximize the window
    /// </summary>
    public ICommand MenuCommand { get; set; }

    #endregion

    #region Contructor

    /// <summary>
    ///  default contructor 
    /// </summary>
    /// <param name="window"></param>
    public WindowsViewModel(Window window)
        {
            mWindow = window;
            //Listen out for the window resizing
            mWindow.StateChanged += (sender, e) =>    
            {
                //Fire off all events for all properties that are affected by a resize
                //OnPropertyChanged(nameof(ResizeBorder));
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            // create commands
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));

            // fix windows resize issue
            var resizer = new WindowResizer(mWindow);

        }
        #endregion

        #region Helper methods

        /// <summary>
        /// get the current mouse position on the screen
        /// </summary>
        /// <returns></returns>
        private Point GetMousePosition()
        {
            // position of the mouse relative to the window
            var position = Mouse.GetPosition(mWindow);
            return new Point(position.X + mWindow.Left, position.Y+ mWindow.Top);
        }
        #endregion
    }
}
