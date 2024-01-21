using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaywithRobo.Interface;

namespace PlaywithRobo.Model
{
    internal class DirectionFactory : IDirectionFactory
    {
        public Robot CreateDirection(int _coordinateX, int _coordinateY, string _direction)
        {
            switch(_direction)
            {
                case "east":
                    return new DirectionEast(_coordinateX, _coordinateY, _direction);
                case "west":
                    return new DirectionWest(_coordinateX, _coordinateY, _direction);
                case "north":
                    return new DirectionNorth(_coordinateX, _coordinateY, _direction);
                case "south":
                    return new DirectionSouth(_coordinateX, _coordinateY, _direction);
                default:
                    return new DirectionEast(_coordinateX, _coordinateY, _direction);
            }
        }
    }
}
