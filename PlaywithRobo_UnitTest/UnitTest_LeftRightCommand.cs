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
    public class UnitTest_LeftRightCommand
    {
        [TestMethod]
        public void ValidateRightTurn()
        {
            Play p1 = new Play();
            Robot robo = p1.CreateRobo(1, 2, "east");

            robo.direction = robo.Right();            

            Assert.AreEqual("Output: 1, 2, south", robo.Report());
        }
    }
}
