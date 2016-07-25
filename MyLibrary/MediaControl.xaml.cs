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

        /// <summary>
        /// Dependency property used to back the <see cref="IsEjectEnabled"/> property
        /// </summary>
        public static readonly DependencyProperty IsEjectEnabledProperty =
            DependencyProperty.Register("IsEjectEnabled",
                typeof(bool),
                typeof(MediaControl),
                new PropertyMetadata(true));

        /// <summary>
        /// Dependency property used to back the <see cref="FullScreenClickCommand"/> property
        /// </summary>
        public static readonly DependencyProperty FullScreenClickCommandProperty =
            DependencyProperty.Register("FullScreenClickCommand", 
                typeof(ICommand), 
                typeof(MediaControl), 
                new PropertyMetadata(null));

        /// <summary>
        /// Dependency property used to back the <see cref="SoundClickCommand"/> property
        /// </summary>
        public static readonly DependencyProperty SoundClickCommandProperty =
            DependencyProperty.Register("SoundClickCommand",
                typeof(ICommand),
                typeof(MediaControl),
                new PropertyMetadata(null));

        /// <summary>
        /// Dependency property used to back the <see cref="IsSoundEnabled"/> property
        /// </summary>
        public static readonly DependencyProperty IsSoundEnabledProperty =
            DependencyProperty.Register("IsSoundEnabled",
                typeof(bool),
                typeof(MediaControl),
                new PropertyMetadata(true));

        /// <summary>
        /// Dependency property used to back the <see cref="IsFullScreenEnabled"/> property
        /// </summary>
        public static readonly DependencyProperty IsFullScreenEnabledProperty =
            DependencyProperty.Register("IsFullScreenEnabled", 
                typeof(bool), 
                typeof(MediaControl), 
                new PropertyMetadata(true));

        /// <summary>
        /// Dependency property used to back the <see cref="CanPlay"/> property
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
        /// Dependency property for the sound buttons tool tip message
        /// </summary>
        public static readonly DependencyProperty SoundToolTipMessageProperty =
            DependencyProperty.Register("SoundToolTipMessage",
                typeof(string), typeof(MediaControl),
                new PropertyMetadata("Allows media sound level to be altered."));

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
            DependencyProperty.Register("FastForwardData",
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
            DependencyProperty.Register("FullScreenData",
                typeof(string), typeof(MediaControl),
                new PropertyMetadata("F1 M24,24z M0,0z M7,14L5,14 5,19 10,19 10,17 7,17 7,14z M5,10L7,10 7,7 10,7 10,5 5,5 5,10z M17,17L14,17 14,19 19,19 19,14 17,14 17,17z M14,5L14,7 17,7 17,10 19,10 19,5 14,5z"));

        public static readonly DependencyProperty SoundDataProperty =
            DependencyProperty.Register("SoundData",
                typeof(string), typeof(MediaControl),
                new PropertyMetadata("M12,12A3,3 0 0,0 9,15A3,3 0 0,0 12,18A3,3 0 0,0 15,15A3,3 0 0,0 12,12M12,20A5,5 0 0,1 7,15A5,5 0 0,1 12,10A5,5 0 0,1 17,15A5,5 0 0,1 12,20M12,4A2,2 0 0,1 14,6A2,2 0 0,1 12,8C10.89,8 10,7.1 10,6C10,4.89 10.89,4 12,4M17,2H7C5.89,2 5,2.89 5,4V20A2,2 0 0,0 7,22H17A2,2 0 0,0 19,20V4C19,2.89 18.1,2 17,2Z"));

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

        public ICommand SoundClickCommand
        {
            get { return (ICommand)GetValue(SoundClickCommandProperty); }
            set { SetValue(SoundClickCommandProperty, value); }
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
        /// Sets if the Sound button can be seen in the view
        /// </summary>
        public bool IsSoundEnabled
        {
            get { return (bool)GetValue(IsSoundEnabledProperty); }
            set { SetValue(IsSoundEnabledProperty, value); }
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
        /// Message to be displayed on the full screen buttons tool tip
        /// </summary>
        public string SoundToolTipMessage
        {
            get { return (string)GetValue(SoundToolTipMessageProperty); }
            set { SetValue(SoundToolTipMessageProperty, value); }
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
        /// Canvas geometry data for the sound buttons image
        /// </summary>
        public string SoundData
        {
            get { return (string)GetValue(SoundDataProperty); }
            set { SetValue(SoundDataProperty, value); }
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
