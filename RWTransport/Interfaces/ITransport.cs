using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWTransport.Interfaces
{
    public interface ITransport
    {
        TransportType TransportType { get; }
        int WeightWithoutLoad { get; }
        int GetRailCarMass();
    }
}
