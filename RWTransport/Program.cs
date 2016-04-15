using RWTransport.Classes;
using RWTransport.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWTransport
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Passengers> passengers = Builder.Passengers();
            Console.WriteLine("Now {0} passengers waiting a trian", passengers.Count); Console.WriteLine(); 
            Train PassengerTrain;
            while (passengers.Count() > 0)
            {
                PassengerTrain = Builder.PassengerTrain();
                Console.WriteLine("Passengers train has arrived:");
                foreach (var x in PassengerTrain.MyTrain)
                {
                    if ((x is PassengerRailCar))
                    {
                        Console.WriteLine("{0} passengers car has {1} free places",
                            (x as PassengerRailCar).PassengerRailCarType, 
                            ((x as PassengerRailCar).PeopleCapacity - (x as PassengerRailCar).CurrentPeopleLoad));
                    }
                }
                Console.WriteLine();
                PassengerTrain.AddPassengers(passengers);
                Console.WriteLine("{0} passengers left", passengers.Count);
                Console.WriteLine(); Console.ReadLine();
            }

            List<Freight> freight = Builder.Freight();
            Console.WriteLine("{0} units of freight in a warehouse", freight.Count());
            Train FreightTrain;
            while (freight.Count() > 0)
            {
                FreightTrain = Builder.FreightTrain();
                Console.WriteLine("Freight train has arrived:");
                FreightTrain.AddFreight(freight);
                foreach (var x in FreightTrain.MyTrain)
                {
                    if ((x is FreightCar))
                    {
                        Console.WriteLine("{0}, current load {1} ton",
                            (x as FreightCar).FreightCarType, (x as FreightCar).CurrentLoad);
                    }
                }
                Console.WriteLine("{0} units of freight in a warehouse", freight.Count());
                Console.ReadLine();
            }




            

            
            
            
            
            
            
            
            
            
            
            //Train MyTrain = Builder.PassengerTrain();
            //Train MyFreightTrain = Builder.FreightTrain();
            //List<Freight> f = Builder.Freight();
            //MyTrain.SortByComfort();
            //MyFreightTrain.SortByComfort();

            //MyTrain.SelectByNumberOfPassengers(x=> ((x as PassengerRailCar).CurrentPeopleLoad >5 && (x as PassengerRailCar).CurrentPeopleLoad<100));
            
            Console.ReadLine();
        }
    }
}
