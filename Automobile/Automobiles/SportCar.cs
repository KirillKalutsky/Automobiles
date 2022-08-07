using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automobile
{
    public class SportCar : Automobile
    {
        public SportCar(double averageFuelConsumption, double fuelTankVolume, double speed)
            : base(averageFuelConsumption, fuelTankVolume, speed)
        {}
        public override AutomobileType Type => AutomobileType.SportCar;

    }
}
