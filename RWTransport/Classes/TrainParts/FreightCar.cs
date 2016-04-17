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
        #region Constructor
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
        #endregion

        #region Properties
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
                }
            }
        }
        public TransportType TransportType
        {
            get { return TransportType.FreightCar; }
        }       
        #endregion

        #region Methods
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
        public List<Freight> AddFreight(List<Freight> freight)
        {

            foreach (var x in freight.ToArray())
            {
                if (CurrentLoad == 0)
                {
                    if (this.FreightCarType == x.VagonType)
                    {
                        x.FreightMass = this.Load(x.FreightMass);
                        if (x.FreightMass == 0)
                        {
                            freight.Remove(x);
                        }
                        break;
                    }                   
                }
            }
            return freight;
        }
        #endregion
    }
}
