using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental.Model
{
    class Video : INotifyPropertyChanged
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

        string _Title;
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                if (_Title != value)
                {
                    _Title = value;
                    RaisePropertyChanged("Title");
                }
            }
        }

        string _Director;
        public string Director
        {
            get
            {
                return _Director;
            }
            set
            {
                if (_Director != value)
                {
                    _Director = value;
                    RaisePropertyChanged("Director");
                }
            }
        }

        int _Year;
        public int Year
        {
            get
            {
                return _Year;
            }
            set
            {
                if (_Year != value)
                {
                    _Year = value;
                    RaisePropertyChanged("ReleaseYear");
                }
            }
        }

        string _Genre;
        public string Genre
        {
            get
            {
                return _Genre;
            }
            set
            {
                if (_Genre != value)
                {
                    _Genre = value;
                    RaisePropertyChanged("Genre");
                }
            }
        }

        string _Medium;
        public string Medium
        {
            get
            {
                return _Medium;
            }
            set
            {
                if (_Medium != value)
                {
                    _Medium = value;
                    RaisePropertyChanged("Medium");
                }
            }
        }

        bool _Available;
        public bool Available
        {
            get
            {
                return _Available;
            }
            set
            {
                if(_Available != value)
                {
                    _Available = value;
                    RaisePropertyChanged("Available");
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
