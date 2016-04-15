using RWTransport.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWTransport.Classes
{
    class Locomotive : ILocomotive
    {
        public Locomotive(LocomotiveType LocomotiveType,int MaxTrainMass, int MaxSpeed, int WeightWithoutLoad,
                          LocomotiveEngineType LocomotiveEngineType = LocomotiveEngineType.DieselEngine)
        {
            this.LocomotiveType = LocomotiveType; this.LocomotiveEngineType = LocomotiveEngineType;
            this.MaxTrainMass = MaxTrainMass; this.MaxSpeed = MaxSpeed; this.WeightWithoutLoad = WeightWithoutLoad;
        }
        public LocomotiveType LocomotiveType { get; private set; }
        public LocomotiveEngineType LocomotiveEngineType { get; private set; }
        public int MaxTrainMass { get; private set; }
        public int MaxSpeed { get; private set; }
        public int WeightWithoutLoad { get; private set; }
        public TransportType TransportType
        {
            get { return TransportType.Locomotive; }
        }
        public int GetRailCarMass()
        {
            return WeightWithoutLoad; 
        }
    }
}
