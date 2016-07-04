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
        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set
            {
                SetValue(ValueProperty, value);
                OnPropertyChanged();
            }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(NumericUpDown), new PropertyMetadata(0));
        
        public NumericUpDown()
        {
            InitializeComponent();

            InitCommands();
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
            return true;
        }

        public void ExecuteIncreaseCommand()
        {
            Value++;
        }

        public bool CanExecuteDecreaseCommand()
        {
            return true;
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
