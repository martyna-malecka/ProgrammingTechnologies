using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental
{
    public interface IVideo
    {
        int GetYear();

        String GetTitle();

        String GetDirector();

        String GetGenre();

        String GetID();

        void SetStatus(bool _available);

        bool GetStatus();
    }

}
