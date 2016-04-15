using RWTransport.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWTransport.Classes
{
    class PassengerRailCar : IPassengerRailCar
    {
        Random r = new Random();
        int _currentPeopleLoad; int _currentBaggageMass;
        public PassengerRailCar(PassengerRailCarType PassengerRailCarType, int PeopleCapacity, int WeightWithoutLoad)
        {
            this.PassengerRailCarType = PassengerRailCarType; this.PeopleCapacity = PeopleCapacity;
            this.WeightWithoutLoad = WeightWithoutLoad;          
            _currentPeopleLoad = r.Next(0, PeopleCapacity);
            _currentBaggageMass = r.Next(0, _currentPeopleLoad * 100);
        }
        public PassengerRailCar(PassengerRailCarType PassengerRailCarType, int PeopleCapacity, int WeightWithoutLoad, int CurrentPeopleLoad, int BaggageMass)
        {
            this.PassengerRailCarType = PassengerRailCarType; this.PeopleCapacity = PeopleCapacity;
            this.WeightWithoutLoad = WeightWithoutLoad; this.CurrentPeopleLoad = CurrentPeopleLoad; this.BaggageMass = BaggageMass;
        }
        public PassengerRailCarType PassengerRailCarType { get; protected set; }
        public int PeopleCapacity { get; protected set; }       
        public int CurrentPeopleLoad
        {
            get
            {
                return _currentPeopleLoad;
            }
            private set
            {
                if ( value <= PeopleCapacity)
                {
                    _currentPeopleLoad = value;
                }
                else
                {
                    //событие
                }
            }
        }
        public virtual TransportType TransportType
        {
            get { return TransportType.PassengerRailCar; }
        }
        public int WeightWithoutLoad { get; protected set; }

        public virtual int GetRailCarMass()
        {
            return WeightWithoutLoad + _currentBaggageMass;            
        }
        public int BaggageMass
        {
            get
            {
                return _currentBaggageMass;
            }
            private set
            {
                _currentBaggageMass = value;
            }
        }



        public List<Passengers> AddPassenger(List<Passengers> passengers)
        {
            
            foreach (var c in passengers.ToArray())
            {
                if (CurrentPeopleLoad >= PeopleCapacity)
                {
                    break;
                }
                if ((c.VagonType == PassengerRailCarType)&& CurrentPeopleLoad < PeopleCapacity)
                {
                    CurrentPeopleLoad+=1;
                    BaggageMass += c.BaggageMass;
                    passengers.Remove(c);
                }
                
            }
            
            return passengers;
            }

        public byte Comfort
        {
            get
            {
                switch (PassengerRailCarType)
                {
                    case (PassengerRailCarType.Compartment): return 1;
                    case (PassengerRailCarType.Sleeper): return 2;
                    case (PassengerRailCarType.Couchette): return 3;
                    case (PassengerRailCarType.General): return 4;
                    default: return 0;
                }
            }
        }
    }
    }

