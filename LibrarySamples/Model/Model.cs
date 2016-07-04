using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security;
using MyLibrary.Annotations;
using MyLibrary.SelectPanel;

namespace LibrarySamples.Model
{
    public class Model : IPanelItem, INotifyPropertyChanged
    {
        private bool _isSelected;

        public Model(string name)
        {
            Name = name;
            IsSelected = false;
        }

        public string Name { get; set; }

        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
