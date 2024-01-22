using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PlaywithRobo.Model
{
    public class Table
    {
        int height = 0;
        int width = 0;
        Robot robot;

        public Table(int _height, int _width, Robot _robot)
        {
            height = _height;
            width = _width;
            robot = _robot;
        }

        public bool IsValidXCoordinate()
        {
            if (robot.coordinateX >= 0 && robot.coordinateX <= width)
                return true;

            return false;
        }

        public bool IsValidYCoordinate()
        {
            if (robot.coordinateY >= 0 && robot.coordinateY <= height)
                return true;

            return false;
        }

        public bool reachedXCoordinate()
        {
            if (robot.coordinateX == 0 || robot.coordinateX == width)
                return true;

            return false;
        }

        public bool reachedYCoordinate()
        {
            if (robot.coordinateY == 0 && robot.coordinateY == height)
                return true;

            return false;
        }
    }
}