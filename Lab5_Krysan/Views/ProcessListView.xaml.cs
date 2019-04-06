using Lab5_Krysan.ViewModels;
using System.Windows.Controls;

namespace Lab5_Krysan.Views
{
    /// <summary>
    /// Interaction logic for PersonListViewModel.xaml
    /// </summary>
    public partial class ProcessListView : UserControl
    {
        public ProcessListView()
        {
            InitializeComponent();
            DataContext = new ProcessListViewModel();
        }

        private void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {

        }
    }
}
