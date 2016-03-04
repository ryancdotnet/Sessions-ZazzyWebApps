using Atlas.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Atlas.Model
{
    public class Process : INotifyPropertyChanged
    {
        #region Properties

        private int _ProcessId = -1;
        public int ProcessId
        {
            get
            {
                return _ProcessId;
            }
            set
            {
                if (_ProcessId != value)
                {
                    _ProcessId = value;
                    OnPropertyChanged("ProcessId");
                }
            }
        }

        private ProcessStatus _ProcessStatus = ProcessStatus.Pending;
        public ProcessStatus ProcessStatus
        {
            get
            {
                return _ProcessStatus;
            }
            set
            {
                if (_ProcessStatus != value)
                {
                    _ProcessStatus = value;
                    OnPropertyChanged("ProcessStatus");
                }
            }
        }

        private DateTime? _StartDate = null;
        public DateTime? StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                if (_StartDate != value)
                {
                    _StartDate = value;
                    OnPropertyChanged("StartDate");
                }
            }
        }

        private DateTime? _EndDate = null;
        public DateTime? EndDate
        {
            get
            {
                return _EndDate;
            }
            set
            {
                if (_EndDate != value)
                {
                    _EndDate = value;
                    OnPropertyChanged("EndDate");
                }
            }
        }

        #endregion Properties

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
