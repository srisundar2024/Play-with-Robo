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
        public void ValidateInvalidPlaceCommand()
        {
            Play robo = new Play();
            robo.ExecuteCommand("PLACE 6,3,EAST");

            Assert.AreSame(robo.errorMessageCoorinates, robo.errorMessage);
        }

        [TestMethod]
        public void ValidateMoveCommand()
        {
            Play robo = new Play();
            robo.ExecuteCommand("PLACE 1,3,EAST");
            robo.ExecuteCommand("MOVE");

            Robot expected = robo.CreateRobo(2, 3, "east");

            Assert.AreEqual(expected.coordinateX, robo.robo.coordinateX);
        }

        [TestMethod]
        public void ValidateWallMoveCommand()
        {
            Play robo = new Play();
            robo.ExecuteCommand("PLACE 5,3,EAST");
            robo.ExecuteCommand("MOVE");

            Robot expected = robo.CreateRobo(5, 3, "east");

            Assert.AreEqual(expected.coordinateX, robo.robo.coordinateX);           
        }

        [TestMethod]
        public void ValidateRightCommand()
        {
            Play robo = new Play();
            robo.ExecuteCommand("PLACE 5,3,EAST");
            robo.ExecuteCommand("RIGHT");

            Robot expected = robo.CreateRobo(5, 3, "south");

            Assert.AreEqual(expected.direction, robo.robo.direction);           
        }

        [TestMethod]
        public void ValidateLeftCommand()
        {
            Play robo = new Play();
            robo.ExecuteCommand("PLACE 5,3,EAST");
            robo.ExecuteCommand("LEFT");

            Robot expected = robo.CreateRobo(5, 3, "north");

            Assert.AreEqual(expected.direction, robo.robo.direction);
        }

        [TestMethod]
        public void ValidateReportCommand()
        {
            Play robo = new Play();
            robo.ExecuteCommand("PLACE 5,3,EAST");
            robo.ExecuteCommand("LEFT");
            robo.ExecuteCommand("REPORT");

            string expected = "OUTPUT: 5, 3, NORTH";

            Assert.AreEqual(expected, robo.robo.Report());            
        }

        [TestMethod]
        public void ValidateInvalidCommand()
        {
            Play robo = new Play();
            robo.ExecuteCommand("SOME COMMAND");

            Assert.AreSame(robo.errorInvalidCommand, robo.errorMessage);            
        }
    }
}