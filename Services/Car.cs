using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netapi.Services
{
    public class Car
    {
        public string Name { get; set; }
        public Vehicle TypeOfCAr { get; set; }
        public double Balance { get; set; }

         public Car()
        {}

        public Car(string name, string typeOfVehicle)
        {
            Name = name;
            TypeOfCAr = (Vehicle)Enum.Parse(typeof(Vehicle), typeOfVehicle.ToUpper());
            Balance = 0;
        }

        public Car(string name, string typeOfVehicle, double groshi)
        {
            Name = name;
            TypeOfCAr = (Vehicle)Enum.Parse(typeof(Vehicle), typeOfVehicle.ToUpper());
            Balance = groshi;
        }

        public Car(string name, Vehicle typeOfVehicle, double groshi)
        {
            Name = name;
            TypeOfCAr = typeOfVehicle;
            Balance = groshi;
        }
        public void PayByParking(int time)
        {
            double payWithFine = 0;
            double NumberPeriods = Math.Ceiling(time / Setting.timePeriodOnparking);
            double sumaOfPay = NumberPeriods * (int)TypeOfCAr;

            Setting.balanceParking = sumaOfPay < Balance ? Setting.balanceParking + sumaOfPay
                                                        : Setting.balanceParking + (sumaOfPay * Setting.KoefFine);
            Console.Write($"Balance at the beginning: {Balance}, ");

            if (sumaOfPay < Balance)
            {
                Balance = Balance - sumaOfPay;
                Console.WriteLine($"Parking cost: {sumaOfPay}, Balance at the end: {Balance}");
                Setting.WriteTransactions(DateTime.Now, Name, sumaOfPay);
            }
            else
            {
                payWithFine = sumaOfPay * Setting.KoefFine;
                Balance = Balance - payWithFine;
                Console.WriteLine($"Parking cost: {sumaOfPay}, Fine: {payWithFine - sumaOfPay}, Balance at the end: {Balance}");
                Setting.WriteTransactions(DateTime.Now, Name, payWithFine);
            }                     
        }
    }
}