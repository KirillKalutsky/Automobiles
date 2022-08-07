using Automobile.Parameters;

namespace Automobile
{
    public abstract class Automobile
    {
        public Automobile(double averageFuelConsumption, double fuelTankVolume, double speed)
        {
            AverageFuelConsumptionPerHundredKilometers = averageFuelConsumption;
            FuelTankCapacity = fuelTankVolume;
            SpeedKilometersPerHour = speed;
        }

        private double averageFuelConsumptionPerHundredKilometers;
        public double AverageFuelConsumptionPerHundredKilometers
        {
            get { return averageFuelConsumptionPerHundredKilometers; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Средний расход топлива не может быть отрицательным числом");
                }
                averageFuelConsumptionPerHundredKilometers = value;
            }
        }

        private double fuelTankCapacity;
        public double FuelTankCapacity
        { 
            get 
            { 
                return fuelTankCapacity;
            } 

            protected set
            {
                if (value < 0)
                    throw new ArgumentException("Объем топливного бака положительное число");

                fuelTankCapacity = value;
            } 
        }

        public double SpeedKilometersPerHour { get; protected set; }

        public abstract AutomobileType Type { get; }

        public double CalculateRangeInKilometers()
        {
            return CalculateRangeInKilometers(new BaseParameter(FuelTankCapacity));
        }

        public virtual double CalculateRangeInKilometers<T>(T param) where T : BaseParameter
        {
            if (param.FuelVolume < 0 || param.FuelVolume > FuelTankCapacity)
                throw new ArgumentException("Объем топлива в баке должен быть положительным числом и не превышать объем бака");

            return param.FuelVolume / AverageFuelConsumptionPerHundredKilometers * 100;
        }

        public virtual TimeSpan CalculateTravelTime(double fuelVolume, double distance)
        {
            if (fuelVolume > FuelTankCapacity)
            {
                throw new OverflowException("Превышен объем топливного бака автомобиля");
            }

            if (distance > CalculateRangeInKilometers(new BaseParameter(fuelVolume)))
            {
                throw new OverflowException("Расстояние превышает запас хода автомобиля");
            }

            return TimeSpan.FromHours(distance / SpeedKilometersPerHour);
        }
    }
}
