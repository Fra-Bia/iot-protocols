using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreClient.ValueObjects
{
    internal class CarDoors
    {
        public string _open { get; private set;}
        public string _locked { get; private set;}

        public CarDoors(string open, string locked)
        {
            _locked = locked;
            _open = open;
        }
    }
}
