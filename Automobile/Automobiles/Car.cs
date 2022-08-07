using Automobile.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automobile
{
    public class Car:Automobile
    {
        public Car(double averageFuelConsumption, double fuelTankVolume, double speed, int passengerCapacity)
            :base(averageFuelConsumption, fuelTankVolume, speed)
        {
            PassengerCapacity = passengerCapacity;
        }
        private const int passengerStep = 1;
        private const double percentStep = 6;
        public int PassengerCapacity { get; }

        public override AutomobileType Type => AutomobileType.Car;

        public new double CalculateRangeInKilometers<T>(T fuelVolume) where T : CarParameter
        {
            var powerReserve = base.CalculateRangeInKilometers(fuelVolume);

            if (fuelVolume.PassengersCount > PassengerCapacity)
                throw new OverflowException("Количество пассажиров превышает вместимость машины");

            for(var step = 0; step < fuelVolume.PassengersCount/passengerStep; step++)
            {
                powerReserve -= powerReserve * percentStep / 100;
            }

            return powerReserve;
        }
    }
}
