using Lab5_Krysan.Models;
using Lab5_Krysan.Tools.Managers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace Lab5_Krysan.ViewModels
{
    class ModuleListViewModel
    {
        private ObservableCollection<ModuleModel> _processes;

        public ObservableCollection<ModuleModel> ProcessesModules
        {
            get => _processes;
            private set
            {
                _processes = value;
                OnPropertyChanged();
            }
        }

        internal ModuleListViewModel()
        {
            var processThreads = Process.GetProcessById(StationManager.CurrentProcess.Id).Modules;
            List<ModuleModel> processModulesList = new List<ModuleModel>();
            foreach (var t in processThreads)
            {
                processModulesList.Add(new ModuleModel((ProcessModule)t));
            }
            _processes = new ObservableCollection<ModuleModel>(processModulesList);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

