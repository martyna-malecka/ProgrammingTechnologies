using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VideoRental
{
    [TestClass]
    public class RentalTest
    {
        private List<Rental> rentals;
        private List<Client> clients;
        private List<IVideo> videos;

        VideoRentalLogic logic;

        Client client;
        IVideo video;

        public RentalTest()
        {
            rentals = new List<Rental>();
            clients = new List<Client>();
            videos = new List<IVideo>();
            logic = new VideoRentalLogic(videos, rentals, clients);
            video = new Tape(2001, "Gladiator", "Ridley Scott", "Drama");
            client = new Client("Szymon", "Rogalski");
            videos.Add(video);
            clients.Add(client);
        }
        [TestMethod]
        public void RentAvailableVideo()
        {
             Assert.IsTrue(logic.Rent(video, client));
        }

        [TestMethod]
        public void ShowCurrentRentals()
        {
            logic.Rent(video, client);
            Rental expected = rentals[0];
            Assert.AreEqual(expected, logic.GetCurrentRentals()[0]);
        }

        [TestMethod]
        public void ReturnRentedVideo()
        {
            logic.Rent(video, client);
            Rental rental = rentals[0];
            logic.Return(rental);
            Assert.IsTrue(rental.GetStatus());
        }
    }
}
