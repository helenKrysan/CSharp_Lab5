using Lab5_Krysan.Tools.Managers;
using System;
using System.Diagnostics;
using System.Threading;

namespace Lab5_Krysan.Models
{
    class ProcessModel
    {
        private Guid _guid;
        private string _name;
        private int _id;
        private string _status;
        private string _cpu;
        private string _memory;
        private string _user;
        private int _threadsNumber;
        private string _filePath;
        private DateTime _started;

        private ProcessThreadCollection _threads;

        public ProcessModel(Process process)
        {

            _name = process.ProcessName;
            _id = process.Id;
            if (!process.Responding)
            {
                _status = "Not Respond";
            }
            else
            {
                _status = "Running";
            }
            _cpu = "0%";
            _memory = process.PagedSystemMemorySize64.ToString();
            _threadsNumber = process.Threads.Count;
            _user = process.StartInfo.UserName;
            _filePath = process.StartInfo.FileName;
            try
            {
                _started = process.StartTime;

            }
            catch (Exception e)
            {
            }
            _threads = process.Threads;
        }


        public Guid Guid
        {
            get
            {
                return _guid;
            }
            private set
            {
                _guid = value;
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


        public int Id
        {
            get
            {
                return _id;
            }
            private set
            {

                _id = value;
            }
        }

        public string Status
        {
            get
            {
                return _status;
            }
            private set
            {
                _status = value;
            }
        }

        public string CPU
        {
            get
            {
                return _cpu;
            }

        }

        public string Memory
        {
            get
            {
                return _memory;
            }
        }

        public string User
        {
            get
            {
                return _user;
            }
        }

        public int ThreadsNumber
        {
            get
            {
                return _threadsNumber;
            }
        }

        public string FilePath
        {
            get
            {
                return _filePath;
            }
        }

        public DateTime Started
        {
            get
            {
                return _started;
            }
        }

        public void Update()
        {
            Process process = null;
            try
            {
                process = Process.GetProcessById(_id);
            }
            catch(Exception e)
            {
                StationManager.DataStorage.ProcessesList.Remove(this);
                return;
            }

            if (!process.Responding)
            {
                _status = "Not Respond";
            }
            else
            {
                _status = "Running";
            }
            _cpu = "0%";
            _memory = process.PagedSystemMemorySize64.ToString();
            _threadsNumber = process.Threads.Count;
            _user = process.StartInfo.UserName;
            _filePath = process.StartInfo.FileName;
            try
            {
                _started = process.StartTime;

            }
            catch (Exception e)
            {
            }
            _threads = process.Threads;
        }


    }
}

