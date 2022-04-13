using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            cars = new List<Car>(capacity);
        }
        public List<Car> Cars { get => cars; set => cars=value; }
        public int Capacity { get => capacity; set => capacity =value; }

        public int Count { get => Cars.Count; }
        public string AddCar(Car car)
        {
            string message = string.Empty;
            bool isExistCurrCar = false;

            foreach (var currCar in Cars)
            {
                if (currCar.RegistrationNumber == car.RegistrationNumber)
                {
                    isExistCurrCar = true;
                }
            }
            if (isExistCurrCar)
            {
                message = $"Car with that registration number, already exists!";
            }
            else if (Capacity < Cars.Count + 1)
            {
                message = "Parking is full!";
            }
            else
            {
                Cars.Add(car);
                message = $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }

            return message;
        }
        public string RemoveCar(string registrationNumber)
        {
            string message = string.Empty;
            bool isFindCarWithRegisNumber = false;
            for (int i = 0; i < Cars.Count; i++)
            {
                if (Cars[i].RegistrationNumber == registrationNumber)
                {
                    message = $"Successfully removed {registrationNumber}";
                    Cars.Remove(Cars[i]);
                    isFindCarWithRegisNumber = true;
                   
                    break;
                }
            }
            if (isFindCarWithRegisNumber == false)
            {
                message = $"Car with that registration number, doesn't exist!";
            }
            return message;
        }

        public Car GetCar(string registrationNumber)
        {
            return Cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var currRegNum in registrationNumbers)
            {
                Cars.RemoveAll(x => x.RegistrationNumber == currRegNum);
            }
        }
    }
}
