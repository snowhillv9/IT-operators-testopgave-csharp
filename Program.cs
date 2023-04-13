using System;
using System.Collections.Generic;

namespace IT_operators_testopgave
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePathForCarsData = @"C:\Users\Bruger\source\repos\IT-operators-testopgave\Data\mydata.json";
            var jsonService = new JsonDataService<Car>();

            List<Car> cars = jsonService.GetAllCarData(filePathForCarsData);
            JsonDataService<Car>.PrintCars(cars);
            JsonDataService<Car>.AmountOfCarsByBrand(cars);
            JsonDataService<Car>.CountFordsAfter1980(cars);
            JsonDataService<Car>.AverageHorsepowerByOrigin(cars);
            JsonDataService<Car>.PrintCarsKPL(cars);
            Console.WriteLine("Opgave 6: (bevis på, at det virker)");
            Console.WriteLine(cars[0].Weight_in_lbs);
            Console.WriteLine(cars[0].WeightInKilograms);
            var carFactory = new CarFactory(filePathForCarsData);
            Console.WriteLine();
            Console.WriteLine("Opgave 7:");
            var newCar = carFactory.AddCar("Ford Mustang", 100.1, 8, 302.0, 140.0, 3449, 10.5, new DateTime(1976, 1, 1), "USA");
            Console.WriteLine("For at vise at opgaven er besvaret i konsollen. Kan selvfølgelig ses i mydata.json filen");
            Console.WriteLine($" Bilnavn: {newCar.Name} Miles per gallon: {newCar.Miles_per_Gallon}");
            Console.WriteLine();
            JsonDataService<Car>.FindCarWithLargestMpg(cars);
            Console.WriteLine("Jeg nåede ikke at debugge nok og finde ud af, hvorfor den har den forkerte miles per gallon value før tiden løb ud.");
            Console.WriteLine("Den finder dog den rigtige bil, der har den højeste miles per gallon.");
            Console.ReadLine();
        }
    }
}
