using Lab5_Krysan.Models;
using Lab5_Krysan.Tools.Managers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
namespace Lab5_Krysan.ViewModels
{
    class ProcessThreadListViewModel
    {
        private ObservableCollection<ProcessThreadModel> _processes;
        private Thread _workingThread;
        private CancellationToken _token;
        private CancellationTokenSource _tokenSource;

        public ObservableCollection<ProcessThreadModel> ProcessesThreads
        {
            get => _processes;
            private set
            {
                _processes = value;
                OnPropertyChanged();
            }
        }
    
        internal ProcessThreadListViewModel()
        {
            var processThreads = Process.GetProcessById(StationManager.CurrentProcess.Id).Threads;
            List<ProcessThreadModel> processThreadsList = new List<ProcessThreadModel>();
            foreach (var t in processThreads)
            {
                processThreadsList.Add(new ProcessThreadModel((ProcessThread) t));
            }
            _processes = new ObservableCollection<ProcessThreadModel>(processThreadsList);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
