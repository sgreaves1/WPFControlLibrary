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

        /// <summary>
        /// Dependency property for the fast forward buttons click command
        /// </summary>
        public static readonly DependencyProperty FastForwardClickCommandProperty =
            DependencyProperty.Register("FastForwardClickCommand",
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

        /// <summary>
        /// Dependency property for showing the play time
        /// </summary>
        public static readonly DependencyProperty IsPlayTimeShownProperty =
            DependencyProperty.Register("IsPlayTimeShown", 
                typeof(bool), 
                typeof(MediaControl), 
                new PropertyMetadata(true));

        /// <summary>
        /// Dependency property for the stop buttons tool tip message
        /// </summary>
        public static readonly DependencyProperty StopToolTipMessageProperty =
            DependencyProperty.Register("StopToolTipMessage",
                typeof(string), typeof(MediaControl),
                new PropertyMetadata("Stops the media."));

        /// <summary>
        /// Dependency property for the rewind buttons tool tip message
        /// </summary>
        public static readonly DependencyProperty RewindToolTipMessageProperty =
            DependencyProperty.Register("RewindToolTipMessage",
                typeof(string), typeof(MediaControl),
                new PropertyMetadata("Rewinds the media."));

        /// <summary>
        /// Dependency property for the play buttons tool tip message
        /// </summary>
        public static readonly DependencyProperty PlayToolTipMessageProperty =
            DependencyProperty.Register("PlayToolTipMessage",
                typeof(string), typeof(MediaControl),
                new PropertyMetadata("Plays the media."));

        /// <summary>
        /// Dependency property for the forward buttons tool tip message
        /// </summary>
        public static readonly DependencyProperty ForwardToolTipMessageProperty =
            DependencyProperty.Register("ForwardToolTipMessage",
                typeof(string), typeof(MediaControl),
                new PropertyMetadata("Fast Forwards the media."));

        /// <summary>
        /// Dependency property for the eject buttons tool tip message
        /// </summary>
        public static readonly DependencyProperty EjectToolTipMessageProperty =
            DependencyProperty.Register("EjectToolTipMessage",
                typeof(string), typeof(MediaControl),
                new PropertyMetadata("Ejects the media."));

        /// <summary>
        /// Dependency property for the full screen buttons tool tip message
        /// </summary>
        public static readonly DependencyProperty FullScreenToolTipMessageProperty =
            DependencyProperty.Register("FullScreenToolTipMessage",
                typeof(string), typeof(MediaControl),
                new PropertyMetadata("Puts the media into full screen mode."));



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
        
        /// <summary>
        /// Command binding for the fast forward button
        /// </summary>
        public ICommand FastForwardClickCommand
        {
            get { return (ICommand)GetValue(FastForwardClickCommandProperty); }
            set { SetValue(FastForwardClickCommandProperty, value); }
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

        /// <summary>
        /// Hides or shows the play time of the video
        /// </summary>
        public bool IsPlayTimeShown
        {
            get { return (bool)GetValue(IsPlayTimeShownProperty); }
            set { SetValue(IsPlayTimeShownProperty, value); }
        }

        /// <summary>
        /// Message to be displayed on the stop buttons tool tip
        /// </summary>
        public string StopToolTipMessage
        {
            get { return (string)GetValue(StopToolTipMessageProperty); }
            set { SetValue(StopToolTipMessageProperty, value); }
        }

        /// <summary>
        /// Message to be displayed on the Rewind buttons tool tip
        /// </summary>
        public string RewindToolTipMessage
        {
            get { return (string)GetValue(RewindToolTipMessageProperty); }
            set { SetValue(RewindToolTipMessageProperty, value); }
        }

        /// <summary>
        /// Message to be displayed on the play buttons tool tip
        /// </summary>
        public string PlayToolTipMessage
        {
            get { return (string)GetValue(PlayToolTipMessageProperty); }
            set { SetValue(PlayToolTipMessageProperty, value); }
        }

        /// <summary>
        /// Message to be displayed on the forward buttons tool tip
        /// </summary>
        public string ForwardToolTipMessage
        {
            get { return (string)GetValue(ForwardToolTipMessageProperty); }
            set { SetValue(ForwardToolTipMessageProperty, value); }
        }

        /// <summary>
        /// Message to be displayed on the eject buttons tool tip
        /// </summary>
        public string EjectToolTipMessage
        {
            get { return (string)GetValue(EjectToolTipMessageProperty); }
            set { SetValue(EjectToolTipMessageProperty, value); }
        }

        /// <summary>
        /// Message to be displayed on the full screen buttons tool tip
        /// </summary>
        public string FullScreenToolTipMessage
        {
            get { return (string)GetValue(FullScreenToolTipMessageProperty); }
            set { SetValue(FullScreenToolTipMessageProperty, value); }
        }

    }
}
