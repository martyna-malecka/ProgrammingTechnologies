using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental
{
    public class VideoRentalLogic
    {
        private List<IVideo> videos;
        private List<Rental> rentals;
        private List<Client> clients;

        public VideoRentalLogic(List<IVideo> _videos, List<Rental> _rentals, List<Client> _clients)
        {
            videos = _videos;
            rentals = _rentals;
            clients = _clients;
        }

        public bool Rent(IVideo video, Client client)
        {
           if(video.GetStatus() == false)       //if video taken
            {
                return false;                   //fail
            }
           else                                 //if video available
            {
                video.SetStatus(false);         //set video taken
                rentals.Add(new Rental(video, client));
                return true;                    //video rented
            }
        }

        public void Return(Rental rental)
        {
            if(DateTime.Today > rental.GetDueDate())                                            //if due date has passed
            {
                rental.GetClient().SetDebt((DateTime.Today - rental.GetDueDate()).TotalDays);   //add 1 for each day there is now after duedate
                rental.GetVideo().SetStatus(true);                                              //make video available again
                rental.SetStatus(true);                                                         //make rental finished(returned)
            }
            else
            {
                rental.GetVideo().SetStatus(true);                                              //make video available again
                rental.SetStatus(true);                                                         //make rental finished(video returned)
            }
        }

        public List<Client> GetClientsInDebt()
        {
            List<Client> clientsInDebt = new List<Client>();
            foreach (Client client in clients)
            {
                if (client.GetDebt() != 0)
                {
                    clientsInDebt.Add(client);
                }
            }
            return clientsInDebt;
        }

        public List<IVideo> GetAvailableVideos()
        {
            List<IVideo> availableVideos = new List<IVideo>();
            foreach (IVideo video in videos)
            {
                if (video.GetStatus() == true)
                {
                    availableVideos.Add(video);
                }
            }
            return availableVideos;
        }

        public List<Rental> GetCurrentRentals()
        {
            List<Rental> currentRentals = new List<Rental>();
            foreach (Rental rental in rentals)
            {
                if (rental.GetStatus() == false)
                {
                    currentRentals.Add(rental);
                }
            }
            return currentRentals;
        }
    }
}
