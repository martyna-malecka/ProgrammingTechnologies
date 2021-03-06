﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental
{

    public class Client 
    {
        private String name;
        private String surname;
        private String id;
        private double debt;

        public Client()
        {

        }

        public Client(String _name, String _surname)
        {
            name = _name;
            surname = _surname;
            id = Guid.NewGuid().ToString();
            debt = 0;
        }

        public String GetName()
        {
            return name;
        }

        public String GetSurname()
        {
            return surname;
        }

        public String GetID()
        {
            return id;
        }

        public void SetDebt(double _debt)
        {
            debt += _debt;
        }

        public void ResetDebt()
        {
            debt = 0;
        }

        public double GetDebt()
        {
            return debt;
        }
    }
}
