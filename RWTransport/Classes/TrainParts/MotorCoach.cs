using RWTransport.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWTransport.Classes
{
    class MotorCoach : PassengerRailCar, ILocomotive
    {
        public MotorCoach(PassengerRailCarType PassengerRailCarType, int MaxTrainMass, int MaxSpeed,
                          int PeopleCapacity = 50, int WeightWithoutLoad = 50, int MaxBaggageMass=6,
                          LocomotiveEngineType LocomotiveEngineType = LocomotiveEngineType.ElectricEngine)
            : base(PassengerRailCarType, PeopleCapacity, WeightWithoutLoad)
        {
            LocomotiveType = LocomotiveType.PassengerLocomotive ; this.LocomotiveEngineType = LocomotiveEngineType;
            this.MaxTrainMass = MaxTrainMass; this.MaxSpeed = MaxSpeed;
        }

        public override TransportType TransportType
        {
            get { return TransportType.MotorCoach; }
        }
        public LocomotiveType LocomotiveType { get; private set; }
        public LocomotiveEngineType LocomotiveEngineType { get; private set; }      
        public int MaxTrainMass { get; private set; }     
        public int MaxSpeed { get; private set; }
        public override int GetRailCarMass()
        {
            return WeightWithoutLoad;
        }
        public int LocomotiveMass 
        {
            get
            {
                return WeightWithoutLoad;
            }
        }
        
    }
}
