using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netapi.Services
{
    public class Parking
    {
        private static Parking instance;
        private Parking()
        { }
        public static Parking getInstance()
        {
            if (instance == null)
                instance = new Parking();
            return instance;
        }
        void CheckCarsOnPaking(string name, Vehicle typeOfVehicle)
        {
            foreach (Car car in Setting.carsOnPaking)
            {
                if (car.Name == name && car.TypeOfCAr == typeOfVehicle)
                {
                    Console.WriteLine($"This car <{car.Name}> can't put on the parknig, bacause it has been on the parknig yet");
                    return;
                }
            }
        }

        public void AddCarOnParking()
        {
            bool NotexistInCars = true;
            string name, type;
            Vehicle typeOfVehicle;
            int time = 0;

            Setting.EnterNameType(out name, out type);

            try
            {
                typeOfVehicle = (Vehicle)Enum.Parse(typeof(Vehicle), type.ToUpper());
                Console.Write("Enter time of parking: ");
                time = int.Parse(Console.ReadLine());
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"ERROR: Type Of Vehicle is wrong ({e.Message})");
                return;
            }
            catch (FormatException e)
            {
                Console.WriteLine($"ERROR: type of time data is wrong ({e.Message})");
                return;
            }

            Console.WriteLine();

            CheckCarsOnPaking(name, typeOfVehicle);
            // add car on Parking
            if (Setting.carsOnPaking.Count < 10)
            {
                Car newCar = new Car(name, type);
                // check the availability of a new Car in the list of cars
                foreach (Car car in Setting.cars)
                {
                    if (car.Name == name && car.TypeOfCAr == typeOfVehicle)
                    {
                        Setting.carsOnPaking.Add(car);
                        car.PayByParking(time);
                        NotexistInCars = false;
                    }
                }

                if (NotexistInCars)
                {
                    Setting.cars.Add(newCar);
                    Setting.carsOnPaking.Add(newCar);
                    newCar.PayByParking(time);
                }
                Console.WriteLine($"Parking: New car <{newCar.Name}> has been added to parking");
                Console.WriteLine();
            }
            else
                Console.WriteLine("There isn't free place on the parking");
        }

        public void RemoveCarFromParking()
        {
            bool ExistOnPaking = false;
            Car existCar = null;
            string name, type;
            Vehicle typeOfVehicle;

            Setting.EnterNameType(out name, out type);

            try
            {
                typeOfVehicle = (Vehicle)Enum.Parse(typeof(Vehicle), type.ToUpper());
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"ERROR: Type Of Vehicle is wrong ({e.Message})");
                return;
            }

            foreach (Car car in Setting.carsOnPaking)
            {
                if (car.Name == name && car.TypeOfCAr == typeOfVehicle)
                {
                    existCar = car;
                    ExistOnPaking = true;
                }
            }

            if (ExistOnPaking)
            {
                Setting.carsOnPaking.Remove(existCar);
                Console.WriteLine($"Parking: Car <{name}> has been removed from parking");
            }
            else
                Console.WriteLine($"The car {name} is not parked");
            Console.WriteLine();
        }

        public void RefillBalance()
        {
            Car newCar = null;
            bool notExist = true;
            string name, type;
            Vehicle typeOfVehicle;
            double amount = 0;

            Setting.EnterNameType(out name, out type);

            try
            {
                typeOfVehicle = (Vehicle)Enum.Parse(typeof(Vehicle), type.ToUpper());
                Console.Write("Enter the amount of the account replenishment: ");
                amount = double.Parse(Console.ReadLine());
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"ERROR: Type Of Vehicle is wrong ({e.Message})");
                return;
            }
            catch (FormatException e)
            {
                Console.WriteLine($"ERROR: type of amount data is wrong ({e.Message})");
                return;
            }

            foreach (Car car in Setting.cars)
            {
                if (car.Name == name && car.TypeOfCAr == typeOfVehicle)
                {
                    Console.Write($"Balance at the beginning: {car.Balance}, ");
                    car.Balance = car.Balance + amount;
                    Console.WriteLine($" Balance <{car.Name}> at the end: : {car.Balance} $");
                    notExist = false;
                    break;
                }
            }

            if (notExist)
            {
                newCar = new Car(name, type, amount);
                Setting.cars.Add(newCar);
                Console.WriteLine($"On Balance <{newCar.Name}>: {newCar.Balance} $");
            }
            Console.WriteLine();
        }
    }
}
