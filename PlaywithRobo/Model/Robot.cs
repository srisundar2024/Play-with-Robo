using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywithRobo.Model
{
    public abstract class Robot
    {
        public int coordinateX = 0;
        public int coordinateY = 0;
        public string direction = "";

        public Robot(int _coordinateX, int _coordinateY, string _direction)
        {
            this.coordinateX = _coordinateX;
            this.coordinateY = _coordinateY;
            this.direction = _direction;
        }

        public abstract int Move();
        public abstract string Left();
        public abstract string Right();

        public string Report()
        {
            return String.Format("Output: {0}, {1}, {2}", coordinateX, coordinateY, direction).ToUpper();
        }
    }

    public class DirectionEast : Robot
    {
        public DirectionEast(int _coordinateX, int _coordinateY, string _direction) : base(_coordinateX, _coordinateY, _direction) { }

        public override int Move()
        {
            return coordinateX++;
        }

        public override string Right()
        {
            return "south";
        }

        public override string Left()
        {
            return "north";
        }
    }

    public class DirectionWest : Robot
    {
        public DirectionWest(int _coordinateX, int _coordinateY, string _direction) : base(_coordinateX, _coordinateY, _direction) { }

        public override int Move()
        {
            return coordinateX--;
        }

        public override string Right()
        {
            return "north";
        }

        public override string Left()
        {
            return "south";
        }
    }

    public class DirectionNorth : Robot
    {
        public DirectionNorth(int _coordinateX, int _coordinateY, string _direction) : base(_coordinateX, _coordinateY, _direction) { }

        public override int Move()
        {
            return coordinateY++;
        }

        public override string Right()
        {
            return "east";
        }

        public override string Left()
        {
            return "west";
        }
    }

    public class DirectionSouth : Robot
    {
        public DirectionSouth(int _coordinateX, int _coordinateY, string _direction) : base(_coordinateX, _coordinateY, _direction) { }

        public override int Move()
        {
            return coordinateY--;
        }

        public override string Right()
        {
            return "west";
        }

        public override string Left()
        {
            return "east";
        }
    }

}
