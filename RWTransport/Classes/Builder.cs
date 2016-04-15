
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RWTransport.Interfaces;

namespace RWTransport.Classes
{
    abstract class Builder
    {
        public static Train PassengerTrain()
        {
            Train MyTrain = new Train();
            MyTrain.AddTransport(new MotorCoach(PassengerRailCarType.General, MaxTrainMass: 3500, MaxSpeed: 120));
            MyTrain.AddTransport(new PassengerRailCar(PassengerRailCarType.Sleeper, PeopleCapacity:30,WeightWithoutLoad:50));
            MyTrain.AddTransport(new PassengerRailCar(PassengerRailCarType.Couchette, PeopleCapacity: 54, WeightWithoutLoad: 55));
            MyTrain.AddTransport(new PassengerRailCar(PassengerRailCarType.Compartment, PeopleCapacity: 64, WeightWithoutLoad: 57));
            MyTrain.AddTransport(new PassengerRailCar(PassengerRailCarType.General, PeopleCapacity: 64, WeightWithoutLoad: 57));
            MyTrain.AddTransport(new FreightCar(FreightCarType.Refrigerator, MaxLoad: 66, WeightWithoutLoad: 25));
            return MyTrain;
        }
        public static Train FreightTrain()
        {
            Train MyTrain = new Train();
            MyTrain.AddTransport(new Locomotive(LocomotiveType.FreightLocomotive, MaxTrainMass: 4000, MaxSpeed: 100, WeightWithoutLoad:50));
            MyTrain.AddTransport(new FreightCar(FreightCarType.BaggageCar, MaxLoad: 68, WeightWithoutLoad: 22));
            MyTrain.AddTransport(new FreightCar(FreightCarType.CarCarrier, MaxLoad: 68, WeightWithoutLoad: 23));
            MyTrain.AddTransport(new FreightCar(FreightCarType.Hopper, MaxLoad: 67, WeightWithoutLoad: 24));
            MyTrain.AddTransport(new FreightCar(FreightCarType.Tank, MaxLoad: 66, WeightWithoutLoad: 25));
            MyTrain.AddTransport(new FreightCar(FreightCarType.Platform, MaxLoad: 66, WeightWithoutLoad: 25));
            MyTrain.AddTransport(new FreightCar(FreightCarType.Refrigerator, MaxLoad: 66, WeightWithoutLoad: 25));

            return MyTrain;
        }

        public static List<Passengers> Passengers()
        {
            List<Passengers> _list = new List<Passengers>();
            Random r = new Random();
            int _countPassengers = r.Next(1, 200);
            for (int i = 1; i <= _countPassengers; i++)
            {
                _list.Add(new Passengers { BaggageMass = r.Next(1, 100), VagonType = (PassengerRailCarType)r.Next(4) });
            }
                return _list;
        }

        public static List<Freight> Freight()
        {
            List<Freight> _list = new List<Freight>();
            Random r = new Random();
            int _freightCount = r.Next(1, 10);
            for (int i = 1; i <= _freightCount; i++)
            {
                _list.Add(new Freight { FreightMass = r.Next(30, 100), VagonType = (FreightCarType)r.Next(4) });
            }
            return _list;
        }
    }
}
