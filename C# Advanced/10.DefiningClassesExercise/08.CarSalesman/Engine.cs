using System;
using System.Collections.Generic;
using System.Text;

namespace P08.CarSalesman
{
    public class Engine
    {

        public Engine(string model, string power)
        {
            Model = model;
            Power = power;
            Displacement = "n/a";
            Efficiency = "n/a";
        }
        public Engine(string model, string power, int displacement)
            : this(model, power)
        {
            Displacement = displacement.ToString();
        }
        public Engine(string model,string power,string efficiency)
            : this(model, power)
        {
            Efficiency = efficiency;
        }
        public Engine(string model, string power, string displacement, string efficiency)
            : this(model, power)
        {
            Displacement = displacement;
            Efficiency = efficiency;
        }
        public string Model { get; set; }

        public string Power { get; set; }

        public string Displacement { get; set; }

        public string Efficiency { get; set; }
    }
}
