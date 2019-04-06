using Lab5_Krysan.Tools;
using Lab5_Krysan.Tools.Managers;
using Lab5_Krysan.Tools.Navigation;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;


namespace Lab5_Krysan.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private RelayCommand _endTask;
        private RelayCommand _goToFile;
        private RelayCommand _details;

        public MainViewModel()
        {
        }

        public RelayCommand Details
        {
            get
            {
                return _details ?? (_details = new RelayCommand(
                           o => { NavigationManager.Instance.Navigate(ViewType.ProcessDetails); }));
            }
        }

        public RelayCommand GoToFile
        {
            get
            {
                return _goToFile ?? (_goToFile = new RelayCommand(
                           o => { }));
            }
        }

        public RelayCommand EndTask
        {
            get
            {
                return _details ?? (_details = new RelayCommand(
                           o => {
                               Process.GetProcessById(StationManager.CurrentProcess.Id).Kill();
                               StationManager.DataStorage.ProcessesList.Remove(StationManager.CurrentProcess);
                               StationManager.CurrentProcess = null;
                           }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
