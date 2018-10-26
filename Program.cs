using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental
{
    class Program
    {
        private VideoCatalog videos = new VideoCatalog();
        private ClientCatalog clients = new ClientCatalog();
        private RentalCatalog rentals = new RentalCatalog();


        void Rent(IVideo video, Client client)
        {
            Rental rental = new Rental();

            rentals.Add(rental);
            video.SetStatus(false);
        }

        void Return(Rental rental)
        {
            rental.GetVideo().SetStatus(true);

            if(DateTime.Today > rental.GetDueDate()) //if overtime
            {
                rental.GetClient().SetDebt((DateTime.Today - rental.GetDueDate()).Days);
                rental.SetStatus(true);
            }
            else
            {
                rental.SetStatus(true);
            }
        }

        List<Client> GetClientsInDebt()
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

        List<IVideo> GetAvailableVideos()
        {
            List<IVideo> availableVideos = new List<IVideo>();
            foreach(IVideo video in videos)
            {
                if(video.GetStatus() == true)
                {
                    availableVideos.Add(video);
                }
            }
            return availableVideos;
        }

        List<Rental> GetCurrentRentals()
        {
            List<Rental> currentRentals = new List<Rental>();
            foreach(Rental rental in rentals)
            {
                if(rental.GetStatus() == false)
                {
                    currentRentals.Add(rental);
                }
            }
            return currentRentals;
        }

        static void Main(string[] args)
        {

        }
    }
}
