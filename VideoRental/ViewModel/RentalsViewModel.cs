using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using VideoRental.Model;
using VideoRentalData;
using VideoRentalLogic;

namespace VideoRental.ViewModel
{
    class RentalsViewModel : BaseViewModel
    {
        public ObservableCollection<Rental> Rentals { get; set; }
        object _SelectedRental;
        DataClassesDataContext db = new DataClassesDataContext();
        public object SelectedRental
        {
            get
            {
                return _SelectedRental;
            }
            set
            {
                if (_SelectedRental != value)
                {
                    _SelectedRental = value;
                    RaisePropertyChanged("SelectedRental");
                }
            }
        }

        string _TextProperty1;
        public string TextProperty1
        {
            get
            {
                return _TextProperty1;
            }
            set
            {
                if (_TextProperty1 != value)
                {
                    _TextProperty1 = value;
                    RaisePropertyChanged("TextProperty1");
                }
            }
        }

        string _TextProperty2;
        public string TextProperty2
        {
            get
            {
                return _TextProperty2;
            }
            set
            {
                if (_TextProperty2 != value)
                {
                    _TextProperty2 = value;
                    RaisePropertyChanged("TextProperty2");
                }
            }
        }


        string _TextProperty3;
        public string TextProperty3
        {
            get
            {
                return _TextProperty3;
            }
            set
            {
                if (_TextProperty3 != value)
                {
                    _TextProperty3 = value;
                    RaisePropertyChanged("TextProperty3");
                }
            }
        }

        string _TextProperty4;
        public string TextProperty4
        {
            get
            {
                return _TextProperty4;
            }
            set
            {
                if (_TextProperty4 != value)
                {
                    _TextProperty4 = value;
                    RaisePropertyChanged("TextProperty4");
                }
            }
        }

        public RelayCommand AddRentalCommand { get; set; }
        public RelayCommand CompleteRentalCommand { get; set; }

        public Logic logic;


        public RentalsViewModel()
        {
            var maxId = (from r in db.rental
                            select r.id).Max();
            var minId = (from r in db.rental
                            select r.id).Min();
            var q = from r in db.rental
                    select r.id;
            List<int> availableIds = q.ToList();

            Rentals = new ObservableCollection<Rental>();
            for (int i = minId; i <= maxId; i++)
            {
                if (availableIds.Contains(i))
                {
                    Rentals.Add((from r in db.rental
                                where r.id == i && r.dueDate != null
                                select new Rental { Id = r.id, ClientId = r.clientId, VideoId = r.videoId, RentDate = r.rentDate, DueDate = r.dueDate, Returned = r.returned }).FirstOrDefault());
                }
            }

            TextProperty1 = null;
            TextProperty2 = null;
            TextProperty3 = null;
            TextProperty4 = null;

            logic = new Logic();
            AddRentalCommand = new RelayCommand(AddRental);
            CompleteRentalCommand = new RelayCommand(CompleteRental);
        }

        void AddRental(object parameter)
        {
            if (TextProperty1 == null || TextProperty2 == null || TextProperty3 == null || TextProperty4 == null)
            {
                return;
            }
            else
            {
                rental r = new rental();
                int cId = 0;
                int vId = 0;
                bool canBorrow = true;
                bool inDebt = false;

                IQueryable<client> q1 = from c in db.client
                         where c.firstName == TextProperty1 && c.lastName == TextProperty2
                         select c;
                IQueryable<video> q2 = from v in db.video
                         where v.title == TextProperty3 && v.medium == TextProperty4
                         select v;

                foreach (var c in q1)
                {
                    cId = c.id;
                    if (c.debt != 0)
                    {
                        inDebt = true;
                    }
                }
                
                foreach (var v in q2)
                {
                    vId = v.id;
                }
                
                foreach (video v in q2)
                {
                    if (v.available == true)
                    {
                        canBorrow = true;
                        v.available = false;
                    }
                }
                if (inDebt)
                {
                    throw new Exception("Client is in debt");
                }
                else
                {
                    if (canBorrow)
                    {
                        r = new rental { clientId = cId, videoId = vId, rentDate = DateTime.Today, dueDate = DateTime.Today.AddDays(30), returned = false };
                        db.rental.InsertOnSubmit(r);
                        db.SubmitChanges();
                        Rentals.Add(new Rental { ClientId = cId, VideoId = vId, RentDate = DateTime.Today, DueDate = DateTime.Today.AddDays(30), Returned = false });
                        RaisePropertyChanged("Rentals");
                        TextProperty1 = null;
                        TextProperty2 = null;
                        TextProperty3 = null;
                        TextProperty4 = null;
                    }
                    else
                    {
                        throw new Exception("Video is not available");
                    }
                }

            }
        }

        void CompleteRental(object parameter)
        {
            int debt = 0;

            if (SelectedRental == null)
                return;
            else
            {
                var r1 = SelectedRental as Rental;
                var r2 = from r in db.rental
                         where r.clientId == r1.ClientId && r.videoId == r1.VideoId
                         select r;
                foreach(var r in r2)
                {
                    debt = logic.CheckDueDate(r.dueDate);
                }
                foreach (var r in r2)
                {
                    r.returned = true;
                    var v1 = from v in db.video
                             join rr in db.rental on v.id equals r.videoId
                             where r.videoId == r1.VideoId
                             select v;
                    var c1 = from c in db.client
                             join rr in db.rental on c.id equals r.clientId
                             where r.clientId == r1.ClientId
                             select c;
                    foreach (video v in v1)
                    {
                        v.available = true;
                    }

                    foreach (client c in c1)
                    {
                        c.debt = debt;
                    }
                }
                db.SubmitChanges();
                r1.Returned = true;
                RaisePropertyChanged("Rentals");
            }
        }
    }
}
