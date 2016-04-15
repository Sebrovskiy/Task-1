using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWTransport.Interfaces
{
    interface ILocomotive:ITransport
    {
        LocomotiveType LocomotiveType { get; }
        LocomotiveEngineType LocomotiveEngineType { get; }
        int MaxTrainMass { get;  }
        int MaxSpeed { get; }
    }
}
