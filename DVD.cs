using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental
{
    class DVD : IVideo
    {
        private int year;
        private String title;
        private String director;
        private String genre;
        private String id;
        private bool available;

        public DVD()
        {

        }

        public DVD(int _year, String _title, String _director, String _genre)
        {
            year = _year;
            title = _title;
            director = _director;
            genre = _genre;
            id = Guid.NewGuid().ToString();
            available = true;
        }

        public int GetYear()
        {
            return year;
        }

        public String GetTitle()
        {
            return title;
        }

        public String GetDirector()
        {
            return director;
        }

        public String GetGenre()
        {
            return genre;
        }

        public String GetID()
        {
            return id;
        }

        public void SetStatus(bool _available)
        {
            available = _available;
        }

        public bool GetStatus()
        {
            return available;
        }
    }
}
