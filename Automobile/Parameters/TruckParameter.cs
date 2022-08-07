namespace Automobile.Parameters
{
    public class TruckParameter:BaseParameter
    {
        public TruckParameter(double fuelVolume, double cargoWeight) : base(fuelVolume)
        {
            CargoWeight = cargoWeight;
        }
        public double CargoWeight { get; set; }
    }
}
