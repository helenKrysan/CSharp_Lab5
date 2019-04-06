using Lab5_Krysan.ViewModels;

using System.Windows.Controls;


namespace Lab5_Krysan.Views
{
    /// <summary>
    /// Interaction logic for ModuleListView.xaml
    /// </summary>
    public partial class ModuleListView : UserControl
    {
        public ModuleListView()
        {
            InitializeComponent();
            DataContext = new ModuleListViewModel();
        }
    }
}
