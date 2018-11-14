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
        TestDataGenerator data;

        Client client;
        IVideo video;

        public RentalTest()
        {
            rentals = new List<Rental>();
            clients = new List<Client>();
            videos = new List<IVideo>();
            logic = new VideoRentalLogic(videos, rentals, clients);
            data = new TestDataGenerator();
            video = new Tape(2001, "Gladiator", "Ridley Scott", "Drama");
            client = new Client("John", "Exemplary");
            videos.Add(video);
            clients.Add(client);
        }
        [TestMethod]
        public void RentAvailableVideo()
        {
             Assert.IsTrue(logic.Rent(video, client));
        }

        [TestMethod]
        public void ReturnRentedVideo()
        {
            logic.Rent(video, client);
            Rental rental = rentals[0];
            logic.Return(rental);
            Assert.IsTrue(rental.GetStatus());
        }

        [TestMethod]
        public void RentRentedVideo()
        {
            logic.Rent(video, data.GetRandomClient());
            Assert.IsFalse(logic.Rent(video, data.GetRandomClient()));
        }

        [TestMethod]
        public void ReturnAvailableVideo()
        {
            Rental testrental = new Rental(data.GetRandomVideo(), data.GetRandomClient());
            Assert.IsFalse(logic.Return(testrental));
        }

        [TestMethod]
        public void ShowCurrentRentals()
        {
            logic.Rent(data.GetRandomVideo(), data.GetRandomClient());
            Rental expected = rentals[0];
            Assert.AreEqual(expected, logic.GetCurrentRentals()[0]);
        }

        [TestMethod]
        public void ShowClientsInDebt()
        {
            Client client = data.GetRandomClient();
            client.SetDebt(20);
            clients.Add(client);
            
            Assert.AreEqual(client, logic.GetClientsInDebt()[0]);
        }

        [TestMethod]
        public void ShowAvailableVideos()
        {
            videos.Add(data.GetRandomVideo());
            videos.Add(video);

            logic.Rent(videos[1], data.GetRandomClient());

            List<IVideo> expected = new List<IVideo>();
            expected.Add(videos[0]);

            Assert.AreEqual(expected[0], logic.GetAvailableVideos()[0]);
        }
    }
}
