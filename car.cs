using System;

namespace IT_operators_testopgave
{
    public class Car
    {
        public string Name { get; set; }
        public double? Miles_per_Gallon { get; set; }
        public int? Cylinders { get; set; }
        public double? Displacement { get; set; }
        public double? Horsepower { get; set; }
        public int? Weight_in_lbs { get; set; }
        public double? Acceleration { get; set; }
        public DateTime Year { get; set; }
        public string Origin { get; set; }

        public double? WeightInKilograms
        {
            get
            {
                return Weight_in_lbs * 0.45;
            }
        }
    }
}
