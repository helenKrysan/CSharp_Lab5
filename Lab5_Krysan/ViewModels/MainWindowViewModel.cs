using Lab5_Krysan.Tools;
using Lab5_Krysan.Tools.Managers;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Lab5_Krysan.ViewModels
{
    class MainWindowViewModel : ILoaderOwner
    {
        private Visibility _loaderVisibility = Visibility.Hidden;
        private bool _isControlEnabled = true;

        public Visibility LoaderVisibility
        {
            get { return _loaderVisibility; }
            set
            {
                _loaderVisibility = value;
                OnPropertyChanged();
            }
        }

        public bool IsControlEnabled
        {
            get { return _isControlEnabled; }
            set
            {
                _isControlEnabled = value;
                OnPropertyChanged();
            }
        }

        internal MainWindowViewModel()
        {
            LoaderManager.Instance.Initialize(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
