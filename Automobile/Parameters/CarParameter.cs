namespace Automobile.Parameters
{
    public class CarParameter: BaseParameter
    {
        public CarParameter(double fuelVolume, int passengers):base(fuelVolume)
        {
            PassengersCount = passengers;
        }
        public int PassengersCount { get;}
    }
}
