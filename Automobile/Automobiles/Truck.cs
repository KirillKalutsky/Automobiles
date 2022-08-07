using Automobile.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automobile
{
    public class Truck : Automobile
    {
        public Truck(double averageFuelConsumption, double fuelTankVolume, double speed, double loadCapacity)
           : base(averageFuelConsumption, fuelTankVolume, speed)
        {
            LoadCapacity = loadCapacity;
        }

        private const double weightStep = 200;
        private const double percentStep = 4;
        public double LoadCapacity { get; set; }

        public override AutomobileType Type => AutomobileType.Truck;

        public new double CalculateRangeInKilometers<T>(T param)where T:TruckParameter
        {
            var powerReserve = base.CalculateRangeInKilometers(param);

            if (param.CargoWeight > LoadCapacity)
                throw new OverflowException("Груз превышает грузоподъемность транспортного средства");

            for(var delta = 0; delta < param.CargoWeight / weightStep; delta++)
            {
                powerReserve -= powerReserve*percentStep/100;
            }

            return powerReserve;
        }
    }
}
