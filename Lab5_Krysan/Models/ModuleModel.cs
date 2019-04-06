using System;
using System.Diagnostics;

namespace Lab5_Krysan.Models
{
    class ModuleModel
    {
        private Guid _guid;
        private string _name;
        private string _filePath;

        public string FilePath
        {
            get
            {
                return _filePath;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public ModuleModel(ProcessModule processModule)
        {
            _name = processModule.ModuleName;
            _filePath = processModule.FileName;
        }

    }
}
