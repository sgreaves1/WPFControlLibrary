using System;
using System.Windows;
using System.Windows.Input;

namespace MyLibrary
{
    /// <summary>
    /// Interaction logic for MediaControl.xaml
    /// </summary>
    public partial class MediaControl
    {
        /// <summary>
        /// Dependency property for the title.
        /// </summary>
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", 
                typeof(string), 
                typeof(MediaControl), 
                new PropertyMetadata(null));

        /// <summary>
        /// Dependency property for the play time.
        /// </summary>
        public static readonly DependencyProperty PlayTimeProperty =
            DependencyProperty.Register("PlayTime", 
                typeof(TimeSpan), 
                typeof(MediaControl), 
                new PropertyMetadata(null));

        // Using a DependencyProperty as the backing store for StopClickCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StopClickCommandProperty =
            DependencyProperty.Register("StopClickCommand",
                typeof(ICommand),
                typeof(MediaControl),
                new PropertyMetadata(null));

        // Using a DependencyProperty as the backing store for PlayClickCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlayClickCommandProperty =
            DependencyProperty.Register("PlayClickCommand", 
                typeof(ICommand), 
                typeof(MediaControl), 
                new PropertyMetadata(null));

        // Using a DependencyProperty as the backing store for EjectClickCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EjectClickCommandProperty =
            DependencyProperty.Register("EjectClickCommand",
                typeof(ICommand),
                typeof(MediaControl),
                new PropertyMetadata(null));

        // Using a DependencyProperty as the backing store for IsEjectEnabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsEjectEnabledProperty =
            DependencyProperty.Register("IsEjectEnabled",
                typeof(bool),
                typeof(MediaControl),
                new PropertyMetadata(true));

        // Using a DependencyProperty as the backing store for FullScreenClickCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FullScreenClickCommandProperty =
            DependencyProperty.Register("FullScreenClickCommand", 
                typeof(ICommand), 
                typeof(MediaControl), 
                new PropertyMetadata(null));

        // Using a DependencyProperty as the backing store for IsFullScreenEnabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsFullScreenEnabledProperty =
            DependencyProperty.Register("IsFullScreenEnabled", 
                typeof(bool), 
                typeof(MediaControl), 
                new PropertyMetadata(true));
        
        /// <summary>
        /// Dependency property for showing the title
        /// </summary>
        public static readonly DependencyProperty IsTitleShownProperty =
            DependencyProperty.Register("IsTitleShown", 
                typeof(bool), 
                typeof(MediaControl), 
                new PropertyMetadata(true));

        public MediaControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The title to be displayed on the control
        /// </summary>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        /// <summary>
        /// The play time to be displayed on the control
        /// </summary>
        public TimeSpan PlayTime
        {
            get { return (TimeSpan)GetValue(PlayTimeProperty); }
            set { SetValue(PlayTimeProperty, value); }
        }

        public ICommand StopClickCommand
        {
            get { return (ICommand)GetValue(StopClickCommandProperty); }
            set { SetValue(StopClickCommandProperty, value); }
        }

        public ICommand PlayClickCommand
        {
            get { return (ICommand)GetValue(PlayClickCommandProperty); }
            set { SetValue(PlayClickCommandProperty, value); }
        }

        public ICommand EjectClickCommand
        {
            get { return (ICommand)GetValue(EjectClickCommandProperty); }
            set { SetValue(EjectClickCommandProperty, value); }
        }

        /// <summary>
        /// Sets if the Eject button can be seen in the view
        /// </summary>
        public bool IsEjectEnabled
        {
            get { return (bool)GetValue(IsEjectEnabledProperty); }
            set { SetValue(IsEjectEnabledProperty, value); }
        }

        public ICommand FullScreenClickCommand
        {
            get { return (ICommand)GetValue(FullScreenClickCommandProperty); }
            set { SetValue(FullScreenClickCommandProperty, value); }
        }

        /// <summary>
        /// Sets if the FullScreen button can be seen in the view
        /// </summary>
        public bool IsFullScreenEnabled
        {
            get { return (bool)GetValue(IsFullScreenEnabledProperty); }
            set { SetValue(IsFullScreenEnabledProperty, value); }
        }

        /// <summary>
        /// Hides or shows the title text
        /// </summary>
        public bool IsTitleShown
        {
            get { return (bool)GetValue(IsTitleShownProperty); }
            set { SetValue(IsTitleShownProperty, value); }
        }
    }
}
