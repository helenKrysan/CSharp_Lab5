using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Lab5_Krysan.Tools.Managers;
using Lab5_Krysan.Tools.Navigation;
using Lab5_Krysan.ViewModels;
using Lab5_Krysan.Tools.DataStorage;
using System.ComponentModel;
using Lab5_Krysan.Models;
namespace Lab5_Krysan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IContentOwner
    {
        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            InitializeApplication();
        }

        private void InitializeApplication()
        {
            StationManager.Initialize(new LocalDataStorage());

            NavigationManager.Instance.Initialize(new ViewProcessDetailsNavigationModel(this));
            NavigationManager.Instance.Navigate(ViewType.Main);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            StationManager.CloseApp();
        }
    }
}
