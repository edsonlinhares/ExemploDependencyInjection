using System.Collections.Generic;
using ExemploDI.Models;

namespace ExemploDI.Stores
{
    public interface ICarStore
    {
        List<Car> List();
        Car Get(int id);
    }
}
