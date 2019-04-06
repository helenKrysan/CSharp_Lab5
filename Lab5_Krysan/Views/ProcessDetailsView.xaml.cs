﻿using Lab5_Krysan.Tools.Navigation;
using Lab5_Krysan.ViewModels;
using System.Windows.Controls;

namespace Lab5_Krysan.Views
{
    /// <summary>
    /// Interaction logic for ProcessDetailsView.xaml
    /// </summary>
    public partial class ProcessDetailsView : UserControl, INavigatable
    {
        public ProcessDetailsView()
        {
            InitializeComponent();
            DataContext = new DetailsViewModel();
        }
    }
}
