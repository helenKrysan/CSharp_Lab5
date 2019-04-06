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
    class ProcessListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ProcessModel> _processes;
        private Thread _workingThread;
        private CancellationToken _token;
        private CancellationTokenSource _tokenSource;

        public ObservableCollection<ProcessModel> Processes
        {
            get => _processes;
            private set
            {
                _processes = value;
                OnPropertyChanged();
            }
        }
        private string _selectedProcess;
        public string SelectedProcess
        {
            get => _selectedProcess;
            set
            {
                    _selectedProcess = value;
                    OnPropertyChanged();
            }
        }

        internal ProcessListViewModel()
        {
            var processes = Process.GetProcesses();
            foreach (var p in processes)
            {
                StationManager.DataStorage.AddProcess(new ProcessModel(p));
            }
            _processes = new ObservableCollection<ProcessModel>(StationManager.DataStorage.ProcessesList);
            _tokenSource = new CancellationTokenSource();
            _token = _tokenSource.Token;
            StartWorkingThread();
            StationManager.StopThreads += StopWorkingThread;
        }

        private void StartWorkingThread()
        {
            _workingThread = new Thread(WorkingThreadProcess);
            _workingThread.Start();
        }

        private void WorkingThreadProcess()
        {
            int i = 0;
            while (!_token.IsCancellationRequested)
            {
                StationManager.DataStorage.Update();
                string sp = null;
                if (SelectedProcess != null)
                {
                    sp = SelectedProcess;
                }
                LoaderManager.Instance.ShowLoader();
                Processes = new ObservableCollection<ProcessModel>(StationManager.DataStorage.ProcessesList);
                if (_token.IsCancellationRequested)
                    break;
                LoaderManager.Instance.HideLoader();
                SelectedProcess = sp;
                StationManager.CurrentProcess = StationManager.DataStorage.GetProcessByName(sp);
                for (int j = 0; j < 10; j++)
                {
                    Thread.Sleep(500);
                    if (_token.IsCancellationRequested)
                        break;
                }
                if (_token.IsCancellationRequested)
                    break;
                i++;
            }

        }

        internal void StopWorkingThread()
        {
            _tokenSource.Cancel();
            _workingThread.Join(2000);
            _workingThread.Abort();
            _workingThread = null;
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
