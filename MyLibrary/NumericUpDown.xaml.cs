using System.Windows;

namespace MyLibrary
{
    /// <summary>
    /// Interaction logic for NumericUpDown.xaml
    /// </summary>
    public partial class NumericUpDown
    {


        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(NumericUpDown), new PropertyMetadata(0));



        public NumericUpDown()
        {
            InitializeComponent();
        }
    }
}
