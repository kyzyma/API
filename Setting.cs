using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using netapi.Services;

namespace netapi
{
    public static class Setting
    {
        public static double balanceParking = 0;
        public static int maxCapacity = 10;
        public static double timePeriodOnparking = 5;
        public static double KoefFine = 2.5;
        public static List<Car> carsOnPaking = new List<Car>();
        public static List<Car> cars = new List<Car>();
        public static List<Transaction> transactions = new List<Transaction>();

        public static double ShowBalanceParking()
        {          
            return Setting.balanceParking;
        }

        public static List<string> ShowListAllCars()
        {
           //int i = 1;
            List<string> NameCar = new List<string>();
            if (Setting.carsOnPaking.Count == 0)
            {
               // Console.WriteLine("List of cars on Parknig is empty");
               // Console.WriteLine();
                return new List<string>();
            }

            Console.WriteLine("List of cars on Parknig");
            foreach (Car car in Setting.carsOnPaking)
            {
                //Console.WriteLine($"{i++}. {car.Name}");
                NameCar.Add(car.Name);
            }
           //Console.WriteLine();
           return NameCar;
        }

        public static double ShowAmountMoneyEarnd()
        {
            double money = 3;
            foreach (Transaction transaction in Setting.transactions)
            {
                if (transaction.DateTimeTransac > (DateTime.Now.AddMinutes(-1)))
                    money += transaction.Amount;
            }
           // System.Console.WriteLine($"The amount of money earned in the last minute: {money} $");
           // Console.WriteLine();
           return money;
        }
        public static void ShowListAllTransactions()
        {
            int i = 1;
            if (Setting.transactions.Count == 0)
            {
                Console.WriteLine("List of Transactions is empty");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("List of Transactions for the last minute");
            foreach (Transaction transaction in Setting.transactions)
            {
                if (transaction.DateTimeTransac > (DateTime.Now.AddMinutes(-1)))
                    Console.WriteLine($"{i++}. {transaction.DateTimeTransac}  |  {transaction.NameCar}  |  {transaction.Amount}");
            }
            Console.WriteLine();
        }
        public static double ShowNumberFreePlaces()
        {
            int freePlaces = Setting.maxCapacity - Setting.carsOnPaking.Count;
           // Console.WriteLine($"Free Places: {freePlaces} and Busy Places: {Setting.carsOnPaking.Count}");
           //Console.WriteLine();
            return freePlaces;
        }

        public static double ShowNumberBusyPlaces()
        {                      
            return Setting.carsOnPaking.Count;
        }
        public static void EnterNameType(out string name, out string type)
        {
            Console.Write("Enter Name of car: ");
            name = Console.ReadLine();
            Console.Write("Enter Type of car: ");
            type = Console.ReadLine();
        }

        public static void WriteTransactions(DateTime dateNowe, string carName, double sumaOfPay)
        {
            Setting.transactions.Add(new Transaction(DateTime.Now, carName, sumaOfPay));

            string writePath = @"D:\transactions.txt";

            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(DateTime.Now.ToString() + " | " + carName + " | " + sumaOfPay);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ReadFromoFileTransactions()
        {
            string path = @"D:\transactions.txt";

            try
            {
                Console.WriteLine("******Read all transactions from file********");
                using (StreamReader sr = new StreamReader(path))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
