using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using VideoRentalData;
using VideoRental.Model;

namespace VideoRental.ViewModel
{
    class ClientsViewModel : BaseViewModel
    {
        public ObservableCollection<Client> Clients { get; set; }
        object _SelectedClient;
        DataClassesDataContext db = new DataClassesDataContext();
        public object SelectedClient
        {
            get
            {
                return _SelectedClient;
            }
            set
            {
                if (_SelectedClient != value)
                {
                    _SelectedClient = value;
                    RaisePropertyChanged("SelectedClient");
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


        public RelayCommand AddUserCommand { get; set; }
        public RelayCommand DeleteUserCommand { get; set; }
        public RelayCommand SetDebtCommand { get; set; }


        public ClientsViewModel()
        {
            var maxId = (from c in db.client
                        select c.id).Max();
            var minId = (from c in db.client
                         select c.id).Min();
            var q = from c in db.client
                              select c.id;
            List<int> availableIds = q.ToList();

            Clients = new ObservableCollection<Client>();
            for (int i = minId; i <= maxId; i++)
            {
                if (availableIds.Contains(i))
                {
                    Clients.Add((from c in db.client
                                 where c.id == i && c.firstName != null
                                 select new Client { Id = c.id, FirstName = c.firstName, LastName = c.lastName, Debt = c.debt }).FirstOrDefault());
                }
            }

            TextProperty1 = null;
            TextProperty2 = null;
            TextProperty3 = null;

            AddUserCommand = new RelayCommand(AddUser);
            DeleteUserCommand = new RelayCommand(DeleteUser);
            SetDebtCommand = new RelayCommand(SetDebt);
        }

        void AddUser(object parameter)
        {
            if (TextProperty1 == null || TextProperty2 == null) return;
            client c = new client { firstName = TextProperty1, lastName = TextProperty2 };
            db.client.InsertOnSubmit(c);
            db.SubmitChanges();
            Clients.Add(new Client { FirstName = TextProperty1, LastName = TextProperty2, Debt = 0 });
            RaisePropertyChanged("Clients");
            TextProperty1 = null;
            TextProperty2 = null;

        }

        void DeleteUser(object parameter)
        {
            if (SelectedClient == null)
            {
                return;
            }
            else
            {
                var c1 = SelectedClient as Client;
                var c2 = from c in db.client
                         where c.firstName == c1.FirstName && c.lastName == c1.LastName
                         select c;
                foreach (client c in c2)
                {
                    db.client.DeleteOnSubmit(c);
                }

                db.SubmitChanges();
                Clients.Remove(c1);
                RaisePropertyChanged("Clients");
            }
        }

        void SetDebt(object parameter)
        {
            if (SelectedClient == null || TextProperty3 == null)
            {
                return;
            }
            else
            {
                var c1 = SelectedClient as Client;
                var c2 = from c in db.client
                         where c.firstName == c1.FirstName && c.lastName == c1.LastName
                         select c;
                foreach (client c in c2)
                {
                    c.debt = Convert.ToInt32(TextProperty3);
                }
                db.SubmitChanges();
                c1.Debt = Convert.ToInt32(TextProperty3);
                RaisePropertyChanged("Clients");
                TextProperty3 = null;
            }
        }

    }
}
