using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWTransport.Interfaces
{
    interface IPassengerRailCar:ITransport    //Пассажирский вагон
    {
        PassengerRailCarType PassengerRailCarType { get; }
        int PeopleCapacity { get; }
        int CurrentPeopleLoad { get; }
        int BaggageMass { get; }
        byte Comfort { get; }
    }
}
