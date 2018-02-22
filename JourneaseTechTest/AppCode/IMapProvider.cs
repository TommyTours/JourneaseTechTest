using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JourneaseTechTest.AppCode
{
    public interface IMapProvider
    {
        bool postCodeExists(string postcode);
        Coordinates GetCoordinates(string postcode);
    }
}
