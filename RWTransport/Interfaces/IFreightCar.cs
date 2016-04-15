using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWTransport.Interfaces
{
    interface IFreightCar:ITransport          //Грузовой вагон
    {
        FreightCarType FreightCarType { get; }
        int MaxLoad { get; }
        int CurrentLoad { get; }

    }
}
