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
        bool CheckCarsOnPaking(Car checkCar)
        {
            foreach (Car car in Setting.carsOnPaking)
            {
                if (car.Name == checkCar.Name && car.TypeOfCAr == checkCar.TypeOfCAr)
                {
                    Console.WriteLine($"This car <{car.Name}> can't put on the parknig, bacause it has been on the parknig yet");
                    return true;
                }
            }
            return false;
        }
     
         public void AddCarOnParking(Car addCar, int time)
        {
            bool NotexistInCars = true;            
           // int time = 0;         

            if(CheckCarsOnPaking(addCar))
                return;

            // add car on Parking
            if (Setting.carsOnPaking.Count < 10)
            {                
                // check the availability of a new Car in the list of cars
                foreach (Car car in Setting.cars)
                {
                    if (car.Name == addCar.Name && car.TypeOfCAr == addCar.TypeOfCAr)
                    {                        
                        Setting.carsOnPaking.Add(car);
                        car.PayByParking(time);
                        addCar.Balance = car.Balance;
                        NotexistInCars = false;
                    }
                }

                if (NotexistInCars)
                {
                    Setting.cars.Add(addCar);
                    Setting.carsOnPaking.Add(addCar);
                    addCar.PayByParking(time);
                }
                Console.WriteLine($"Parking: New car <{addCar.Name}> has been added to parking");
                Console.WriteLine();
            }
            else
                Console.WriteLine("There isn't free place on the parking");
        }    
     
    public void RemoveCarFromParking(Car dCar)
        {
            bool ExistOnPaking = false; 
            Car existCar = null;
        
            foreach (Car car in Setting.carsOnPaking)
            {
                if (car.Name == dCar.Name && car.TypeOfCAr == dCar.TypeOfCAr)
                {
                    existCar = car;
                    dCar.Balance = car.Balance;
                    ExistOnPaking = true;
                }
            }

            if (ExistOnPaking)
            {
                Setting.carsOnPaking.Remove(existCar);
                Console.WriteLine($"Parking: Car <{dCar.Name}> has been removed from parking");
            }
            else
                Console.WriteLine($"The car {dCar.Name} is not parked");
            Console.WriteLine();
        }
    
    public void RefillBalance(double amount, Car refCar)
        {
            Car newCar = null;
            bool notExist = true;
                      
            foreach (Car car in Setting.cars)
            {
                if (car.Name == refCar.Name && car.TypeOfCAr == refCar.TypeOfCAr)
                {                    
                    Console.Write($"Balance at the beginning: {car.Balance}, ");
                    car.Balance = car.Balance + amount;
                    Console.WriteLine($" Balance <{car.Name}> at the end: : {car.Balance} $");
                    notExist = false;
                    refCar.Balance = car.Balance;
                    break;
                }
            }

            if (notExist)
            {
                newCar = new Car(refCar.Name, refCar.TypeOfCAr, amount);
                refCar.Balance = newCar.Balance;
                Setting.cars.Add(newCar);
                Console.WriteLine($"On Balance <{newCar.Name}>: {newCar.Balance} $");
            }
            Console.WriteLine();
        }
    }
}
