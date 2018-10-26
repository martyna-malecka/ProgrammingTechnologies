using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental
{
    class Program
    {
        private TapeCatalog tapes = new TapeCatalog();
        private ClientCatalog clients = new ClientCatalog();
        private RentalCatalog rentals = new RentalCatalog();


        void Rent(Tape tape, Client client)
        {
            Rental rental = new Rental();

            rentals.Add(rental);
            tape.SetStatus(false);
        }

        void Return(Rental rental)
        {
            rental.GetTape().SetStatus(true);

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

        void AddTape(String title, String director, String genre, int year)
        {
            tapes.Add(new Tape(year, title, director, genre));
        }

        void AddClient(String name, String surname)
        {
            clients.Add(new Client(name, surname));
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

        List<Tape> GetAvailableTapes()
        {
            List<Tape> availableTapes = new List<Tape>();
            foreach(Tape tape in tapes)
            {
                if(tape.GetStatus() == true)
                {
                    availableTapes.Add(tape);
                }
            }
            return availableTapes;
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
