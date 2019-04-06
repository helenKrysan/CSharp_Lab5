using System.Collections.Generic;
using Lab5_Krysan.Models;

namespace Lab5_Krysan.Tools.DataStorage
{
    internal interface IDataStorage
    {
        bool ProcessExists(string name);

        ProcessModel GetProcessByName(string name);

        void AddProcess(ProcessModel process);

        void Update();

        void Delete(string name);

        List<ProcessModel> ProcessesList { get; }
    }
}
