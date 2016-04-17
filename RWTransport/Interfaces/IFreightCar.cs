using RWTransport.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWTransport.Interfaces
{
    public interface IFreightCar:ITransport        
    {
        FreightCarType FreightCarType { get; }
        int MaxLoad { get; }
        int CurrentLoad { get; }
        List<Freight> AddFreight(List<Freight> freight);

    }
}
