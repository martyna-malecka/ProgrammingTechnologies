using System;
using System.Threading.Tasks;

namespace VideoRentalLogic
{
    public class Logic
    {
        public Logic()
        {

        }

        public int CheckDueDate(DateTime due)
        {
            int debtToAdd = 0;
            DateTime today = DateTime.Today;
            if (today > due)
            {
                TimeSpan span = today.Subtract(due);
                debtToAdd += (int)span.TotalDays;
            }
            return debtToAdd;
        }
    }
}
