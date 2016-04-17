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
                    if ((x is IPassengerRailCar))
                    {
                        Console.WriteLine("{0} passengers car has {1} free places",
                            (x as IPassengerRailCar).PassengerRailCarType,
                            ((x as IPassengerRailCar).PeopleCapacity - (x as IPassengerRailCar).CurrentPeopleLoad));
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Sort by comfort and add passengers");
                PassengerTrain.AddPassengers(passengers);
                Console.WriteLine();               
                foreach (var x in PassengerTrain.SortByComfort())
                {
                    Console.WriteLine("Passangers train car {0}, free places {1}",
                        (x as IPassengerRailCar).PassengerRailCarType, (x as IPassengerRailCar).PeopleCapacity - (x as IPassengerRailCar).CurrentPeopleLoad);
                }

                Console.WriteLine("{0} passengers left", passengers.Count);
                Console.WriteLine(); Console.ReadLine();
                
                if (passengers.Count() == 0)
                {
                    Console.WriteLine("Try to find a passngers cars, whrere current people load beetwen 0 and 50");
                    List<ITransport> t = Builder.PassengerTrain()
                       .SelectByNumberOfPassengers(x => ((x as IPassengerRailCar).CurrentPeopleLoad > 0 && (x as IPassengerRailCar).CurrentPeopleLoad < 50));
                    foreach (var x in t)
                    {
                        Console.WriteLine("{0} meets a condition", (x as IPassengerRailCar).PassengerRailCarType);
                    }
                }
            }
            Console.WriteLine(); Console.WriteLine("*******************************"); Console.WriteLine();
            
            List<Freight> freight = Builder.Freight();
            Console.WriteLine("{0} units of freight in a warehouse", freight.Count());
            Console.WriteLine();
            Train FreightTrain;
            while (freight.Count() > 0)
            {
                FreightTrain = Builder.FreightTrain();
                Console.WriteLine("Freight train has arrived:");
                FreightTrain.AddFreight(freight);
                foreach (var x in FreightTrain.MyTrain)
                {
                    if ((x is IFreightCar))
                    {
                        Console.WriteLine("{0}, current load {1} ton",
                            (x as IFreightCar).FreightCarType, (x as IFreightCar).CurrentLoad);
                    }
                }
                Console.WriteLine();
                Console.WriteLine("{0} units of freight in a warehouse", freight.Count());
                if (FreightTrain.ICanMove)
                {
                    Console.WriteLine("Train left.");
                }
                else
                {
                    Console.WriteLine("Train overload.");
                }
                Console.ReadLine();
            }




            

            
            
            
            
            
            
            
            
            
            
            //MyFreightTrain.SortByComfort();

            //MyTrain.SelectByNumberOfPassengers(x=> ((x as PassengerRailCar).CurrentPeopleLoad >5 && (x as PassengerRailCar).CurrentPeopleLoad<100));
            
            Console.ReadLine();
        }
    }
}
