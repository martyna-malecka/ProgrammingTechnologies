using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental
{
    public class Rental
    {
        private IVideo rentedVideo;
        private Client rentingClient;
        private String id;
        private bool returned;
        private DateTime rentDate;
        private DateTime dueDate;

        public Rental()
        {

        }

        public Rental(IVideo _rentedVideo, Client _rentingClient)
        {
            rentedVideo = _rentedVideo;
            rentingClient = _rentingClient;
            id = Guid.NewGuid().ToString();
            returned = false;
            rentDate = DateTime.Today;
            dueDate = rentDate.AddDays(30);
        }

        public IVideo GetVideo()
        {
            return rentedVideo;
        }

        public String GetID()
        {
            return id;
        }

        public Client GetClient()
        {
            return rentingClient;
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
