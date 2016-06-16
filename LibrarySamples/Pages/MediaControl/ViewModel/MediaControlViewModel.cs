using System;
using System.Windows.Input;
using LibrarySamples.Command;
using LibrarySamples.ViewModel;
using Microsoft.Win32;

namespace LibrarySamples.Pages.MediaControl.ViewModel
{
    public class MediaControlViewModel : BaseViewModel
    {
        private string _filename;

        public MediaControlViewModel()
        {
            InitCommands();
            FileName = "No Video";
        }

        public string FileName
        {
            get { return _filename; }
            set
            {
                _filename = value;
                OnPropertyChanged();
            }
        }

        #region commands
        public void InitCommands()
        {
            EjectCommand = new DelegateCommand(ExecuteEjectCommand, CanExecuteEjectCommand);
        }

        public ICommand EjectCommand { get; private set; }

        public bool CanExecuteEjectCommand(object parameter)
        {
            return true;
        }

        public void ExecuteEjectCommand(object parameter)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".mp4";
            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                FileName = dlg.FileName;
            }
        }
        #endregion
    }
}
