using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Lab5_Krysan.ViewModels;

namespace Lab5_Krysan.Views
{
    /// <summary>
    /// Interaction logic for ProcessThreadListView.xaml
    /// </summary>
    public partial class ProcessThreadListView : UserControl
    {
        public ProcessThreadListView()
        {
            InitializeComponent();
            DataContext = new ProcessThreadListViewModel();
        }
    }
}
