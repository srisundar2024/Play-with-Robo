using PlaywithRobo.Interface;
using PlaywithRobo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PlaywithRobo.BL
{
    public class Play
    {
        Table table;        
        public Robot robo;

        string[] commandList;
        bool isRobotPlaced = false;

        public string errorMessage = "";
        public string errorMessageFormat = "format of PLACE command is invalid";
        public string errorMessageCoorinates = "Coorinates of PLACE command is invalid";
        public string errorInvalidCommand = "Robot not placed / invalid command";

        public Play()
        {
            
        }

        public Play(string[] _commandList)
        {
            commandList = _commandList;
        }

        public void ParseCommands()
        {
            try
            {
                foreach (string command in commandList)
                {
                    ExecuteCommand(command.ToLower());
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        
        public void ExecuteCommand(string command)
        {
            var commandType = "";
            command = command.ToLower();

            if (!isRobotPlaced && Regex.IsMatch(command, "^place"))
            {
                commandType = "place";

                if (command.Split(new[] { ',', ' '  }).Length != 4)
                {
                    errorMessage = errorMessageFormat;
                    return;
                }

                string[] coodinate = command.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                robo = CreateRobo(Convert.ToInt16(coodinate[1]), Convert.ToInt16(coodinate[2]), coodinate[3]);
                table = new Table(5, 5, robo);

                if (!table.IsValidXCoordinate() || !table.IsValidYCoordinate())
                {
                    errorMessage = errorMessageCoorinates;
                    return;
                }                    

                isRobotPlaced = true;              
            }            
            else
                commandType = command;

            if (robo == null || !isRobotPlaced)
            {
                errorMessage = errorInvalidCommand;
                return;
            }
            
            switch (commandType)
            {
                case "place":                    

                    break;

                case "move":

                    if((robo.direction == "east" || robo.direction == "west") && table.IsValidXCoordinate() && !table.reachedXCoordinate())
                        robo.Move();
                    else if ((robo.direction == "north" || robo.direction == "south") && table.IsValidYCoordinate() && !table.reachedYCoordinate())
                        robo.Move();

                    break;

                case "left":
                    robo.direction = robo.Left();
                    robo = CreateRobo(robo.coordinateX, robo.coordinateY, robo.direction);
                    table = new Table(5, 5, robo);

                    break;

                case "right":
                    robo.direction = robo.Right();
                    robo = CreateRobo(robo.coordinateX, robo.coordinateY, robo.direction);
                    table = new Table(5, 5, robo);

                    break;

                case "report":
                    Console.WriteLine(robo.Report());

                    break;

                default: break;
            }
        }

        public Robot CreateRobo(int coordinateX, int coordinateY, string direction)
        {
            IDirectionFactory Factory = new DirectionFactory();

            return Factory.CreateDirection(coordinateX, coordinateY, direction);
        }
        
        public string Report()
        {
            return robo.Report();
        }
    }
}
