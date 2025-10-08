using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CS._1._012
{
    internal class Tariff
    {
        public string Name=string.Empty;
        double RatePerKwh, FixedCharge;

        //Validate() that throws if rate <= 0 or fixed < 0. for strech goal
        public void Validate()
        {
            if (RatePerKwh <= 0)
            {
                throw new ArgumentException("Rate must be greater than 0");
            }
            if (FixedCharge < 0)
            {
                throw new ArgumentException("Fixed charge cannot be negative");
            }
        }


        //Tariff(string name) → defaults: rate=6.0, fixed=50.
        public Tariff (string name)
        {
            Name = name;
            RatePerKwh = 6.0;
            FixedCharge = 50;
            Validate();
        }

        //Tariff(string name, double rate) → defaults fixed= 50.
        public Tariff (string name, double rate)
        {   
            Name = name;
            RatePerKwh = rate;
            FixedCharge = 50;
            Validate();
        }
        //Tariff(string name, double rate, double fixedCharge).
        public Tariff (string name, double rate, double fixedCharge)
        {
            Name = name;
            RatePerKwh = rate;
            FixedCharge= fixedCharge;
            Validate();
        }


        //ComputeBill(int units) → units * rate + fixed.

        public double ComputeBill(int units)
        {
            return units * RatePerKwh + FixedCharge;
        }
    }
}
