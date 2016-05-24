using System.Windows;
using System.Windows.Input;

namespace MyLibrary
{
    /// <summary>
    /// Interaction logic for MediaControl.xaml
    /// </summary>
    public partial class MediaControl
    {


        public ICommand EjectClickCommand
        {
            get { return (ICommand)GetValue(EjectClickCommandProperty); }
            set { SetValue(EjectClickCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EjectClickCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EjectClickCommandProperty =
            DependencyProperty.Register("EjectClickCommand", typeof(ICommand), typeof(MediaControl), new PropertyMetadata(null));



        public MediaControl()
        {
            InitializeComponent();
        }
    }
}
