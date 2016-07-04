using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using MyLibrary.Annotations;
using MyLibrary.Command;

namespace MyLibrary
{
    /// <summary>
    /// Interaction logic for NumericUpDown.xaml
    /// </summary>
    public partial class NumericUpDown : INotifyPropertyChanged
    {
        /// <summary>
        /// Dependency Property for the Minimum of the control
        /// </summary>
        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum",
                typeof(int),
                typeof(NumericUpDown),
                new PropertyMetadata(0));

        /// <summary>
        /// Dependency Property for the Value of the control
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", 
                typeof(int), 
                typeof(NumericUpDown), 
                new PropertyMetadata(0));

        /// <summary>
        /// Dependency Property for the Maximum of the control
        /// </summary>
        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum",
                typeof(int),
                typeof(NumericUpDown),
                new PropertyMetadata(100000));

        /// <summary>
        /// Constructor
        /// </summary>
        public NumericUpDown()
        {
            InitializeComponent();

            InitCommands();
        }

        /// <summary>
        /// The minimum value the control can be at
        /// </summary>
        public int Minimum
        {
            get { return (int)GetValue(MinimumProperty); }
            set
            {
                SetValue(MinimumProperty, value);
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The value to be displayed in the control
        /// </summary>
        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set
            {
                SetValue(ValueProperty, value);
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The maximum value the control can be at
        /// </summary>
        public int Maximum
        {
            get { return (int)GetValue(MaximumProperty); }
            set
            {
                SetValue(MaximumProperty, value);
                OnPropertyChanged();
            }
        }


        public ICommand IncreaseCommand { get; set; }
        public ICommand DecreaseCommand { get; set; }

        private void InitCommands()
        {
            IncreaseCommand = new RelayCommand(ExecuteIncreaseCommand, CanExecuteIncreaseCommand);
            DecreaseCommand = new RelayCommand(ExecuteDecreaseCommand, CanExecuteDecreaseCommand);
        }

        public bool CanExecuteIncreaseCommand()
        {
            if (Value < Maximum)
                return true;

            return false;
        }

        public void ExecuteIncreaseCommand()
        {
            Value++;
        }

        public bool CanExecuteDecreaseCommand()
        {
            if (Value > Minimum)
                return true;

            return false;
        }

        public void ExecuteDecreaseCommand()
        {
            Value--;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
