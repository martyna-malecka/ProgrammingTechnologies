using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental
{
    public class TestDataGenerator
    {
        private List<Client> clients;
        private List<IVideo> videos;
        private static Random random;
        
        public TestDataGenerator()
        {
            clients = new List<Client>();
            videos = new List<IVideo>();

            clients.Add(new Client("Martyna", "Malecka"));
            clients.Add(new Client("Szymon", "Rogalski"));
            clients.Add(new Client("Marta", "Brzozowska"));

            videos.Add(new DVD(2001, "The Lord of the Rings", "Peter Jackson", "Fantasy"));
            videos.Add(new BluRay(2011, "Drive", "Nicolas Winding Refn", "Drama"));
            videos.Add(new Tape(1962, "One Flew Over the Cuckoo's Nest", "Milos Forman", "Drama"));

            random = new Random();
        }

        public Client GetRandomClient()
        {
            int r = random.Next(clients.Count);
            return clients[r];
        }

        public IVideo GetRandomVideo()
        {
            int r = random.Next(videos.Count);
            return videos[r];
        }
    }
}
