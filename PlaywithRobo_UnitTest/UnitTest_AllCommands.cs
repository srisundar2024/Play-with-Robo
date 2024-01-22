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
    public class UnitTest_AllCommands
    {
        [TestMethod]
        public void ValidatePlaceCommand()
        {
            Play robo = new Play();            
            robo.ExecuteCommand("PLACE 2,3,WEST");

            Assert.IsNotNull(robo.robo);
        }

        [TestMethod]
        public void ProcessInvalidPlaceCommand()
        {
            Play robo = new Play();
            robo.ExecuteCommand("PLACE 5,3,EAST");

            Assert.AreSame(robo.errorMessageCoorinates, robo.errorMessage);
        }

        
    }
}
