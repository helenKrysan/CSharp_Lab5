using Lab5_Krysan.Tools.Navigation;
using System.Windows.Controls;
using Lab5_Krysan.ViewModels;


namespace Lab5_Krysan.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl, INavigatable
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
