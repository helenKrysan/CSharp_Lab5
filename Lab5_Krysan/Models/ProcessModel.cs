using Lab5_Krysan.Tools.Managers;
using System;
using System.Diagnostics;
using System.Threading;
using System.Management;
using System.IO;

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

        private DateTime _lastTime;
        private TimeSpan _lastTotalProcessorTime;
        private DateTime _curTime;
        private TimeSpan _curTotalProcessorTime;

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
            _memory = (process.PagedSystemMemorySize64/(1024*1024)).ToString();
            _threadsNumber = process.Threads.Count;
            try
            {
                _curTotalProcessorTime = process.TotalProcessorTime;
                _curTime = DateTime.Now;
                _user = GetProcessOwner(_id);
               _filePath = process.MainModule.FileName;
           
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
            _memory = (process.PagedSystemMemorySize64 / (1024)).ToString() + "KB";
            _threadsNumber = process.Threads.Count;
           
            try
            {
                _lastTime = _curTime;
                _lastTotalProcessorTime = _curTotalProcessorTime;
                _curTotalProcessorTime = process.TotalProcessorTime;
                _curTime = DateTime.Now;
                double CPUUsage = (_curTotalProcessorTime.TotalMilliseconds - _lastTotalProcessorTime.TotalMilliseconds) / _curTime.Subtract(_lastTime).Milliseconds;

                _cpu = (CPUUsage ) + "%";

                _started = process.StartTime;

            }
            catch (Exception e)
            {
            }
            _threads = process.Threads;
        }

        public string GetProcessOwner(int processId)
        {
            string query = "Select * From Win32_Process Where ProcessID = " + processId;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection processList = searcher.Get();

            foreach (ManagementObject obj in processList)
            {
                string[] argList = new string[] { string.Empty, string.Empty };
                int returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", argList));
                if (returnVal == 0)
                {
                    // return DOMAIN\user
                    return argList[1] + "\\" + argList[0];
                }
            }

            return "NO OWNER";
        }


    }
}

