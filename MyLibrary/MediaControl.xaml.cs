using System.Windows;
using System.Windows.Input;

namespace MyLibrary
{
    /// <summary>
    /// Interaction logic for MediaControl.xaml
    /// </summary>
    public partial class MediaControl
    {
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
        
        public MediaControl()
        {
            InitializeComponent();
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
    }
}
