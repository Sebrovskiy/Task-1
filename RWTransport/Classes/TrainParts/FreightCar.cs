using RWTransport.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWTransport.Classes
{
    class FreightCar:IFreightCar
    {
        int _currentLoad;
        Random r = new Random();
        public FreightCar(FreightCarType FreightCarType, int MaxLoad, int WeightWithoutLoad)
        {
            this.FreightCarType = FreightCarType; this.MaxLoad = MaxLoad;
            this.WeightWithoutLoad = WeightWithoutLoad;
            this.CurrentLoad = 0;
        }
        public FreightCar(FreightCarType FreightCarType, int MaxLoad, int WeightWithoutLoad, int CurrentLoad)
        {
            this.FreightCarType = FreightCarType; this.MaxLoad = MaxLoad;
            this.WeightWithoutLoad = WeightWithoutLoad; this.CurrentLoad = CurrentLoad;
        }      
        public FreightCarType FreightCarType { get; private set;}
        public int MaxLoad { get; private set;}
        public int WeightWithoutLoad { get; private set; }
        public int CurrentLoad
        {
            get { return _currentLoad; }
            private set
            {
                if ((value) <= MaxLoad)
                {
                    _currentLoad = value;
                }
                else
                {
                    _currentLoad = MaxLoad;
                    //Событие перегрузка
                }
            } 
        }
        public TransportType TransportType
        {
            get { return TransportType.FreightCar; }
        }       
        public int Load(int mass)
        {
            if ((_currentLoad + mass) <= MaxLoad)
            {
                _currentLoad += mass;
                return 0;
            }
            else
            {
                mass = mass - MaxLoad + _currentLoad;
                _currentLoad = MaxLoad;
                return mass;
                // событие 
            }
        }
        public void UnLoad()
        {
            _currentLoad = 0;
        }
        public int GetRailCarMass()
        {
            return WeightWithoutLoad + _currentLoad;
        }
       
    }
}
