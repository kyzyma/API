using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netapi.Services
{
    public struct Transaction
    {
        public string NameCar { get; set; }
        public DateTime DateTimeTransac { get; set; }
        public double Amount { get; set; }

        public Transaction(DateTime time, string carName, double groshi)
        {
            DateTimeTransac = time;
            NameCar = carName;
            Amount = groshi;
        }
    }
}
