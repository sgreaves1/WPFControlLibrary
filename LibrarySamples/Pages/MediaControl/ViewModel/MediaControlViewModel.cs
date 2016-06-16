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

        // Event handlers to be fired by the view model to update the media element
        public event EventHandler StopRequested;
        public event EventHandler PlayRequested;

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
            StopCommand = new DelegateCommand(ExecuteStopCommand, CanExecuteStopCommand);
            PlayCommand = new DelegateCommand(ExecutePlayCommand, CanExecutePlayCommand);
            EjectCommand = new DelegateCommand(ExecuteEjectCommand, CanExecuteEjectCommand);
        }

        public ICommand StopCommand { get; private set; }
        public ICommand PlayCommand { get; private set; }
        public ICommand EjectCommand { get; private set; }

        public bool CanExecuteStopCommand(object parameter)
        {
            return true;
        }

        public void ExecuteStopCommand(object parameter)
        {
            StopRequested?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecutePlayCommand(object parameter)
        {
            return true;
        }

        public void ExecutePlayCommand(object parameter)
        {
            PlayRequested?.Invoke(this, EventArgs.Empty);
        }

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
