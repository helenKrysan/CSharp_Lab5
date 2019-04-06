using Lab5_Krysan.Tools;
using Lab5_Krysan.Tools.Managers;
using Lab5_Krysan.Tools.Navigation;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Lab5_Krysan.ViewModels
{
    class DetailsViewModel
    {
        private RelayCommand _return;

        public DetailsViewModel()
        {
        }

        public RelayCommand Return
        {
            get
            {
                return _return ?? (_return = new RelayCommand(
                           o => { NavigationManager.Instance.Navigate(ViewType.Main); }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
