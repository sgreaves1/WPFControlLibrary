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

        /// <summary>
        /// Dependency property for the rewind buttons click command
        /// </summary>
        public static readonly DependencyProperty RewindClickCommandProperty =
            DependencyProperty.Register("RewindClickCommand",
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
        /// Dependency property for pause button command
        /// </summary>
        public static readonly DependencyProperty PauseClickCommandProperty =
            DependencyProperty.Register("PauseClickCommand",
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
        /// Dependency property for showing play or pause button
        /// </summary>
        public static readonly DependencyProperty CanPlayProperty =
            DependencyProperty.Register("CanPlay",
                typeof(bool),
                typeof(MediaControl),
                new PropertyMetadata(false));

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
        /// Dependency property for the pause buttons tool tip message
        /// </summary>
        public static readonly DependencyProperty PauseToolTipMessageProperty =
            DependencyProperty.Register("PauseToolTipMessage",
                typeof(string), typeof(MediaControl),
                new PropertyMetadata("Pauses the media."));

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

        /// <summary>
        /// Dependency property for the stop buttons image data
        /// </summary>
        public static readonly DependencyProperty StopDataProperty =
            DependencyProperty.Register("StopData",
                typeof(string), typeof(MediaControl),
                new PropertyMetadata("F1 M24,24z M0,0z M6,6L18,6 18,18 6,18z"));

        /// <summary>
        /// Dependency property for the rewind buttons image data
        /// </summary>
        public static readonly DependencyProperty RewindDataProperty =
            DependencyProperty.Register("RewindData",
                typeof(string), typeof(MediaControl),
                new PropertyMetadata("F1 M24,24z M0,0z M11,18L11,6 2.5,12 11,18z M11.5,12L20,18 20,6 11.5,12z"));

        /// <summary>
        /// Dependency property for the play buttons image data
        /// </summary>
        public static readonly DependencyProperty PlayDataProperty =
            DependencyProperty.Register("PlayData",
                typeof(string), typeof(MediaControl),
                new PropertyMetadata("F1 M24,24z M0,0z M8,5L8,19 19,12z"));

        /// <summary>
        /// Dependency property for the pause buttons image data
        /// </summary>
        public static readonly DependencyProperty PauseDataProperty =
            DependencyProperty.Register("PauseData",
                typeof(string), typeof(MediaControl),
                new PropertyMetadata("F1 M24,24z M0,0z M6,19L10,19 10,5 6,5 6,19z M14,5L14,19 18,19 18,5 14,5z"));

        /// <summary>
        /// Dependency property for the fast forward buttons image data
        /// </summary>
        public static readonly DependencyProperty FastForwardDataProperty =
            DependencyProperty.Register("FastForward",
                typeof(string), typeof(MediaControl),
                new PropertyMetadata("F1 M24,24z M0,0z M4,18L12.5,12 4,6 4,18z M13,6L13,18 21.5,12 13,6z"));

        /// <summary>
        /// Dependency property for the eject buttons image data
        /// </summary>
        public static readonly DependencyProperty EjectDataProperty =
            DependencyProperty.Register("EjectData",
                typeof(string), typeof(MediaControl),
                new PropertyMetadata("F1 M24,24z M0,0z M5,17L19,17 19,19 5,19z M12,5L5.33,15 18.67,15z"));

        /// <summary>
        /// Dependency property for the full screen buttons image data
        /// </summary>
        public static readonly DependencyProperty FullScreenDataProperty =
            DependencyProperty.Register("FullScreen",
                typeof(string), typeof(MediaControl),
                new PropertyMetadata("F1 M24,24z M0,0z M7,14L5,14 5,19 10,19 10,17 7,17 7,14z M5,10L7,10 7,7 10,7 10,5 5,5 5,10z M17,17L14,17 14,19 19,19 19,14 17,14 17,17z M14,5L14,7 17,7 17,10 19,10 19,5 14,5z"));

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

        /// <summary>
        /// Command binding for the rewind button
        /// </summary>
        public ICommand RewindClickCommand
        {
            get { return (ICommand)GetValue(RewindClickCommandProperty); }
            set { SetValue(RewindClickCommandProperty, value); }
        }

        /// <summary>
        /// Command binding for the play button
        /// </summary>
        public ICommand PlayClickCommand
        {
            get { return (ICommand)GetValue(PlayClickCommandProperty); }
            set { SetValue(PlayClickCommandProperty, value); }
        }

        /// <summary>
        /// Command binding for the pause button
        /// </summary>
        public ICommand PauseClickCommand
        {
            get { return (ICommand)GetValue(PauseClickCommandProperty); }
            set { SetValue(PauseClickCommandProperty, value); }
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
        /// Sets weather the play or pause button is shown
        /// </summary>
        public bool CanPlay
        {
            get { return (bool) GetValue(CanPlayProperty); }
            set {  SetValue(CanPlayProperty, value); }
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
        /// Message to be displayed on the pause buttons tool tip
        /// </summary>
        public string PauseToolTipMessage
        {
            get { return (string)GetValue(PauseToolTipMessageProperty); }
            set { SetValue(PauseToolTipMessageProperty, value); }
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

        /// <summary>
        /// Canvas geometry data for the stop buttons image
        /// </summary>
        public string StopData
        {
            get { return (string)GetValue(StopDataProperty); }
            set { SetValue(StopDataProperty, value); }
        }

        /// <summary>
        /// Canvas geometry data for the rewind buttons image
        /// </summary>
        public string RewindData
        {
            get { return (string)GetValue(RewindDataProperty); }
            set { SetValue(RewindDataProperty, value); }
        }

        /// <summary>
        /// Canvas geometry data for the play buttons image
        /// </summary>
        public string PlayData
        {
            get { return (string)GetValue(PlayDataProperty); }
            set { SetValue(PlayDataProperty, value); }
        }

        /// <summary>
        /// Canvas geometry data for the pause buttons image
        /// </summary>
        public string PauseData
        {
            get { return (string)GetValue(PauseDataProperty); }
            set { SetValue(PauseDataProperty, value); }
        }

        /// <summary>
        /// Canvas geometry data for the fast forward buttons image
        /// </summary>
        public string FastForwardData
        {
            get { return (string)GetValue(FastForwardDataProperty); }
            set { SetValue(FastForwardDataProperty, value); }
        }

        /// <summary>
        /// Canvas geometry data for the eject buttons image
        /// </summary>
        public string EjectData
        {
            get { return (string)GetValue(EjectDataProperty); }
            set { SetValue(EjectDataProperty, value); }
        }

        /// <summary>
        /// Canvas geometry data for the full screen buttons image
        /// </summary>
        public string FullScreenData
        {
            get { return (string)GetValue(FullScreenDataProperty); }
            set { SetValue(FullScreenDataProperty, value); }
        }

    }
}
