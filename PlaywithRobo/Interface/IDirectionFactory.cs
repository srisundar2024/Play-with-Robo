using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaywithRobo.Model;

namespace PlaywithRobo.Interface
{
    internal interface IDirectionFactory
    {
        Robot CreateDirection(int _coordinateX, int _coordinateY, string _direction);
    }
}
