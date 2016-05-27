using System.Windows;
using System.Windows.Input;

namespace MyLibrary
{
    /// <summary>
    /// Interaction logic for MediaControl.xaml
    /// </summary>
    public partial class MediaControl
    {
        // Using a DependencyProperty as the backing store for FileName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FileNameProperty =
            DependencyProperty.Register("FileName", 
                typeof(string), 
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

        public MediaControl()
        {
            InitializeComponent();
        }

        public string FileName
        {
            get { return (string)GetValue(FileNameProperty); }
            set { SetValue(FileNameProperty, value); }
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

        public bool IsFullScreenEnabled
        {
            get { return (bool)GetValue(IsFullScreenEnabledProperty); }
            set { SetValue(IsFullScreenEnabledProperty, value); }
        }
    }
}
