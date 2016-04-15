using RWTransport.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWTransport.Classes
{
    class Train
    {
        public List<ITransport> MyTrain
        {
            get 
            {
                return _myTrain;
            }
        }
        private List<ITransport> _myTrain = new List<ITransport>();
        public void AddTransport(ITransport transport)
        {
            _myTrain.Add(transport);
        }
        public void RemoveTransport(ITransport transport)
        {
            _myTrain.Remove(transport);
        }
        public int GetAllMassTrain()
        {
            int _mass = 0;
            foreach (var c in _myTrain)
            {
                _mass += c.GetRailCarMass();
            }
            return _mass;

        }
        public int GetAllPassengers()
        {
            int _passengers = 0;
            foreach (var c in _myTrain)
            {
                if (c is PassengerRailCar) _passengers += (c as PassengerRailCar).CurrentPeopleLoad;
                if (c is MotorCoach) _passengers += (c as MotorCoach).CurrentPeopleLoad;
            }
            return _passengers;
        }
        public int GetAllBaggage()
        {
            int _baggage = 0;
            foreach (var c in _myTrain)
            {
                if (c is PassengerRailCar) _baggage += (c as PassengerRailCar).BaggageMass;
                if (c is MotorCoach) _baggage += (c as MotorCoach).BaggageMass;
            }
            return _baggage;
        }
        public List<Passengers> AddPassengers(List<Passengers> p)
        {
            foreach (var c in _myTrain)
            {
                if (c is PassengerRailCar)
                {
                    (c as PassengerRailCar).AddPassenger(p);
                }
            }
            return p;
        }       
        public List<Freight> AddFreight (List<Freight> freight)
        {
            foreach (var c in _myTrain)
            {
                if (c is FreightCar)
                {
                    foreach (var x in freight.ToArray())
                    {
                        if ((x.VagonType == (c as FreightCar).FreightCarType)&& ((c as FreightCar).CurrentLoad)==0)
                        {
                            x.FreightMass = (c as FreightCar).Load(x.FreightMass);
                            if (x.FreightMass == 0)
                            {
                                freight.Remove(x);
                            }
                            break;
                        }                        
                    }
                }
            }
            return freight;
        }
        public void SortByComfort()
        {
             List<ITransport> _mySortTrain = GetCarByType(TransportType.PassengerRailCar);
             if (_mySortTrain.Count == 0)
            {
                Console.WriteLine("This train hasn't passangers train cars");
            }
            else
            {
                _mySortTrain.Sort((x, y) => (x as PassengerRailCar).Comfort.CompareTo((y as PassengerRailCar).Comfort));
                foreach (var x in _mySortTrain)
                {
                    Console.WriteLine("Passangers train car {0}, people capacity {1}", 
                        (x as PassengerRailCar).PassengerRailCarType, (x as PassengerRailCar).PeopleCapacity);
                }
            }

        }
        public void SelectByNumberOfPassengers(Func<ITransport, bool> MyDelegate)
        {
            var result = GetCarByType(TransportType.PassengerRailCar).Where(MyDelegate);
            foreach (var c in result)
            {
                Console.WriteLine((c as PassengerRailCar).CurrentPeopleLoad);
            }
        }

       

        private List<ITransport> GetCarByType(TransportType t)
        {
            List<ITransport> _mySortTrain = new List<ITransport>();
            foreach (var x in _myTrain)
            {
                if (x is PassengerRailCar) _mySortTrain.Add(x);
            }
            return _mySortTrain;
 
        }
    }
}
