using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5_Krysan.Models;

namespace Lab5_Krysan.Tools.DataStorage
{
    class LocalDataStorage : IDataStorage
    {

        internal LocalDataStorage()
        {
                _processes = new List<ProcessModel>();
            
        }

        private readonly List<ProcessModel> _processes;

        public List<ProcessModel> ProcessesList
        {
            get { return _processes.ToList(); }
        }

        public void Update()
        {
            foreach(var p in _processes)
            {
                p.Update();
            }
        }


        public void AddProcess(ProcessModel process)
        {
            _processes.Add(process);
        }

        public ProcessModel GetProcessByName(string name)
        {
            return _processes.FirstOrDefault(u => u.Name == name);
        }

        public bool ProcessExists(string name)
        {
            return _processes.Exists(u => u.Name == name);
        }
    }
}
