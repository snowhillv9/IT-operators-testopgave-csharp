using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace IT_operators_testopgave
{
    public class CarFactory
    {
        private readonly string _filePath;

        public CarFactory(string filePath)
        {
            _filePath = filePath;
        }

        public Car AddCar(string name, double? milesPerGallon, int? cylinders, double? displacement,
                           double? horsepower, int? weightInLbs, double? acceleration, DateTime year, string origin)
        {
            var cars = JsonConvert.DeserializeObject<List<Car>>(File.ReadAllText(_filePath));
            var newCar = new Car
            {
                Name = name,
                Miles_per_Gallon = milesPerGallon,
                Cylinders = cylinders,
                Displacement = displacement,
                Horsepower = horsepower,
                Weight_in_lbs = weightInLbs,
                Acceleration = acceleration,
                Year = year,
                Origin = origin
            };
            cars.Add(newCar);
            var newJson = JsonConvert.SerializeObject(cars, Formatting.Indented);
            File.WriteAllText(_filePath, newJson);
            return newCar;
        }
    }

}
