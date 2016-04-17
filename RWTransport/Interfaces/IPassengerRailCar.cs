using RWTransport.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWTransport.Interfaces
{
    public interface IPassengerRailCar:ITransport   
    {
        PassengerRailCarType PassengerRailCarType { get; }
        int PeopleCapacity { get; }
        int CurrentPeopleLoad { get; }
        int BaggageMass { get; }
        byte Comfort { get; }
        List<Passengers> AddPassenger(List<Passengers> Passengers);
    }
}
