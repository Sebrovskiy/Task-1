using RWTransport.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWTransport.Classes
{
    class Train
    {
        private List<ITransport> _myTrain = new List<ITransport>();
        #region Properties
        public List<ITransport> MyTrain
        {
            get 
            {
                return _myTrain;
            }
        }
        public bool ICanMove
        {
            get
            {
                int _mass = 0;
                foreach (var c in _myTrain)
                {
                    if (c is ILocomotive) _mass += (c as ILocomotive).MaxTrainMass;
                }

                return (this.GetAllMassTrain() < _mass);
            }
        }
        #endregion

        #region Methods
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
                if (c is IPassengerRailCar) _passengers += (c as IPassengerRailCar).CurrentPeopleLoad;
                if (c is MotorCoach) _passengers += (c as MotorCoach).CurrentPeopleLoad;
            }
            return _passengers;
        }
        public int GetAllBaggage()
        {
            int _baggage = 0;
            foreach (var c in _myTrain)
            {
                if (c is IPassengerRailCar) _baggage += (c as IPassengerRailCar).BaggageMass;
                if (c is MotorCoach) _baggage += (c as MotorCoach).BaggageMass;
            }
            return _baggage;
        }
        public List<Passengers> AddPassengers(List<Passengers> p)
        {
            foreach (var c in _myTrain)
            {
                if (c is IPassengerRailCar)
                {
                    (c as IPassengerRailCar).AddPassenger(p);
                }
            }
            return p;
        }       
        public List<Freight> AddFreight (List<Freight> freight)
        {
            foreach (var c in _myTrain)
            {
                if (c is IFreightCar)
                {
                    freight = (c as IFreightCar).AddFreight(freight);
                }
            }
            return freight;
        }
        public List<ITransport> SortByComfort()
        {
             List<ITransport> _mySortTrain = GetCarByType(TransportType.PassengerRailCar);
             if (_mySortTrain.Count == 0)
            {
                return null;
            }
            else
            {
                _mySortTrain.Sort((x, y) => (x as IPassengerRailCar).Comfort.CompareTo((y as IPassengerRailCar).Comfort));
            }
             return _mySortTrain;
        }
        public List<ITransport> SelectByNumberOfPassengers(Func<ITransport, bool> MyDelegate)
        {
            List<ITransport> _mySortTrain = new List<ITransport>();
            foreach (var c in GetCarByType(TransportType.PassengerRailCar).Where(MyDelegate))
            {
                _mySortTrain.Add(c);
            }
            return _mySortTrain;
        }
        private List<ITransport> GetCarByType(TransportType t)
        {
            List<ITransport> _mySortTrain = new List<ITransport>();
            foreach (var x in _myTrain)
            {
                if (x is IPassengerRailCar) _mySortTrain.Add(x);
            }
            return _mySortTrain;
 
        }
        #endregion       
    }
}
