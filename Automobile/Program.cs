using Automobile;
using Automobile.Parameters;

var truck = new Truck(15, 200, 80, 2000);
var power = truck.CalculateRangeInKilometers(new TruckParameter(100, 20000));
Console.WriteLine(power);

