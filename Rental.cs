using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental
{
    class Rental
    {
        private Client client;
        private IVideo rentedVideo;
        private String id;
        private bool returned;
        private DateTime rentDate;
        private DateTime dueDate;

        public Rental()
        {

        }

        public Rental(Client _client, IVideo _rentedVideo)
        {
            client = _client;
            rentedVideo = _rentedVideo;
            id = Guid.NewGuid().ToString();
            returned = false;
            rentDate = DateTime.Today;
            dueDate = rentDate.AddDays(30);
        }

        public Client GetClient()
        {
            return client;
        }

        public IVideo GetVideo()
        {
            return rentedVideo;
        }

        public String GetID()
        {
            return id;
        }

        public void SetStatus(bool _returned)
        {
            returned = _returned;
        }

        public bool GetStatus()
        {
            return returned;
        }

        public DateTime GetRentDate()
        {
            return rentDate;
        }

        public DateTime GetDueDate()
        {
            return dueDate;
        }

    }
}
