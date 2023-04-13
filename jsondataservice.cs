using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System;
using System.Linq;

namespace IT_operators_testopgave
{
    public class JsonDataService<T>
    {
        public List<T> GetAllCarData(string filePath)
        {
            string json = File.ReadAllText(filePath);
            List<T> data = JsonConvert.DeserializeObject<List<T>>(json);
            return data;
        }

        public static void PrintCars(List<Car> cars)
        {
            Console.WriteLine("Opgave 1:");
            Console.WriteLine();

            foreach (Car car in cars)
            {
                Console.WriteLine($"Name: {car.Name}");
                Console.WriteLine($"Miles_per_Gallon: {car.Miles_per_Gallon}");
                Console.WriteLine($"Cylinders: {car.Cylinders}");
                Console.WriteLine($"Displacement: {car.Displacement}");
                Console.WriteLine($"Horsepower: {car.Horsepower}");
                Console.WriteLine($"Weight_in_lbs: {car.Weight_in_lbs}");
                Console.WriteLine($"Acceleration: {car.Acceleration}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"Origin: {car.Origin}");
                Console.WriteLine();
            }
        }
        public static void AmountOfCarsByBrand(List<Car> cars)
        {
            Console.WriteLine("Opgave 2:");
            Console.WriteLine();

            Dictionary<string, int> amountOfCarsByBrand = new Dictionary<string, int>();

            foreach (Car car in cars)
            {
                string brand = car.Name.Split(' ')[0];
                if (amountOfCarsByBrand.ContainsKey(brand))
                {
                    amountOfCarsByBrand[brand]++;
                }
                else
                {
                    amountOfCarsByBrand.Add(brand, 1);
                }
            }

            foreach (KeyValuePair<string, int> entry in amountOfCarsByBrand)
            {
                Console.WriteLine("Brand: " + entry.Key + ", Amount of cars: " + entry.Value);
            }
        }
        public static void CountFordsAfter1980(List<Car> cars)
        {
            Console.WriteLine("Opgave 3:");
            Console.WriteLine();

            int count = 0;
            foreach (Car car in cars)
            {
                if (car.Name.ToLower().StartsWith("ford") && car.Year.Year >= 1980)
                {
                    count++;
                }
            }
            foreach (Car car in cars)
            {
                if (car.Name.ToLower().StartsWith("ford") && car.Year.Year >= 1980)
                {
                    Console.WriteLine($"Name: {car.Name}");
                    Console.WriteLine($"Miles_per_Gallon: {car.Miles_per_Gallon}");
                    Console.WriteLine($"Cylinders: {car.Cylinders}");
                    Console.WriteLine($"Displacement: {car.Displacement}");
                    Console.WriteLine($"Horsepower: {car.Horsepower}");
                    Console.WriteLine($"Weight_in_lbs: {car.Weight_in_lbs}");
                    Console.WriteLine($"Acceleration: {car.Acceleration}");
                    Console.WriteLine($"Year: {car.Year}");
                    Console.WriteLine($"Origin: {car.Origin}");
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Number of Fords after 1980: {count}");
            Console.WriteLine();
        }
        public static void AverageHorsepowerByOrigin(List<Car> cars)
        {
            Console.WriteLine("Opgave 4:");
            Console.WriteLine();

            var groupedCars = from car in cars
                              group car by car.Origin into originGroup
                              select new { Origin = originGroup.Key, AvgHorsepower = originGroup.Average(car => car.Horsepower) };

            foreach (var group in groupedCars)
            {
                Console.WriteLine($"Origin: {group.Origin}, Average Horsepower: {group.AvgHorsepower}");
            }
            Console.WriteLine();
        }

        public static void PrintCarsKPL(List<Car> cars) //Just a brief explanation of method name: Cars kilometres per litre
        {
            Console.WriteLine("Opgave 5:");
            Console.WriteLine("Tryk på enter for at fortsætte.");
            Console.ReadLine();

            foreach (Car car in cars)
            {
                car.Miles_per_Gallon *= 1.6; 
            }

            PrintCars(cars);
            Console.WriteLine();
        }


        public static void FindCarWithLargestMpg(List<Car> cars)
        {
            Console.WriteLine("Opgave 8:");
            Console.WriteLine();

            Car carWithHighestMPG = cars.OrderByDescending(c => c.Miles_per_Gallon).FirstOrDefault();

            Console.WriteLine($"Car with highest highest miles per gallon name: {carWithHighestMPG.Name}");
            Console.WriteLine($"miles per gallon: { carWithHighestMPG.Miles_per_Gallon}");
        }
    }

}
