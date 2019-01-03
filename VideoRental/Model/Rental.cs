using System;
using System.ComponentModel;

namespace VideoRental.Model
{
    class Rental : INotifyPropertyChanged
    {
        int _Id;
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    _Id = value;
                    RaisePropertyChanged("Id");
                }
            }
        }

        int _ClientId;
        public int ClientId
        {
            get
            {
                return _ClientId;
            }
            set
            {
                if (_ClientId != value)
                {
                    _ClientId = value;
                    RaisePropertyChanged("ClientId");
                }
            }
        }

        int _VideoId;
        public int VideoId
        {
            get
            {
                return _VideoId;
            }
            set
            {
                if (_VideoId != value)
                {
                    _VideoId = value;
                    RaisePropertyChanged("VideoId");
                }
            }
        }

        DateTime _RentDate;
        public DateTime RentDate
        {
            get
            {
                return _RentDate;
            }
            set
            {
                if (_RentDate != value)
                {
                    _RentDate = value;
                    RaisePropertyChanged("RentDate");
                }
            }
        }

        DateTime _DueDate;
        public DateTime DueDate
        {
            get
            {
                return _DueDate;
            }
            set
            {
                if (_DueDate != value)
                {
                    _DueDate = value;
                    RaisePropertyChanged("DueDate");
                }
            }
        }

        bool _Returned;
        public bool Returned
        {
            get
            {
                return _Returned;
            }
            set
            {
                if (_Returned != value)
                {
                    _Returned = value;
                    RaisePropertyChanged("Returned");
                }
            }
        }

        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
