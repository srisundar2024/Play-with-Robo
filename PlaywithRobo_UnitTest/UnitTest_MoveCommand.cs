using PlaywithRobo.BL;
using PlaywithRobo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywithRobo_UnitTest
{
    [TestClass]
    public class UnitTest_MoveCommand
    {
        [TestMethod]
        public void ValidateCorrectMove()
        {            
            DirectionEast robo = new DirectionEast(1, 2, "east");
            robo.Move();

            Assert.AreEqual(2, robo.coordinateX);
        }
    }
}
