using Lab5_Krysan.Tools.Managers;
using System;
using System.Diagnostics;
using System.Threading;

namespace Lab5_Krysan.Models
{
    class ProcessThreadModel
    {
        private Guid _guid;
        private int _id;
        private string _status;
        private DateTime _started;
        

        public ProcessThreadModel(ProcessThread processThread)
        {

            _id = processThread.Id;
            _status = processThread.ThreadState.ToString();         
            try
            {
                _started =  processThread.StartTime;

            }
            catch (Exception e)
            {
            }
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


        public DateTime Started
        {
            get
            {
                return _started;
            }
        }
    

    }
}

