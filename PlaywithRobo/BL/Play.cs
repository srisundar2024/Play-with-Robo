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
        Robot robo;

        string[] commandList;
        bool isRobotPlaced = false;

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
        
        void ExecuteCommand(string command)
        {
            var commandType = "";

            if(!isRobotPlaced && Regex.IsMatch(command, "^place"))
            {
                commandType = "place";

                if (command.Split(new[] { ',', ' '  }).Length != 4)
                {
                    throw new InvalidDataException("format of PLACE command is invalid");
                }

                string[] coodinate = command.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                robo = CreateRobo(Convert.ToInt16(coodinate[1]), Convert.ToInt16(coodinate[2]), coodinate[3]);
                table = new Table(5, 5, robo);

                isRobotPlaced = true;              
            }            
            else
                commandType = command;
            
            if (robo == null || !isRobotPlaced) return;

            switch (commandType)
            {
                case "place":                    

                    break;

                case "move":

                    var isValidXCoordinate = table.IsValidXCoordinate();
                    var isValidYCoordinate = table.IsValidYCoordinate();

                    if((robo.direction == "east" || robo.direction == "west") && isValidXCoordinate)
                        robo.Move();

                    if ((robo.direction == "north" || robo.direction == "south") && isValidYCoordinate)
                        robo.Move();

                    break;

                case "left":
                    robo.direction = robo.Left();
                    
                    break;

                case "right":
                    robo.direction = robo.Right();

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
            
            if (direction == "east")
                return Factory.CreateDirection(coordinateX, coordinateY, direction);
            else if (direction == "west")
                return Factory.CreateDirection(coordinateX, coordinateY, direction);
            else if (direction == "north")
                return Factory.CreateDirection(coordinateX, coordinateY, direction);
            else if (direction == "south")
                return Factory.CreateDirection(coordinateX, coordinateY, direction);

            return null;
        }
        
        public string Report()
        {
            return robo.Report();
        }
    }
}
