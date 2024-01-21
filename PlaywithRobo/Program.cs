using PlaywithRobo.BL;

//using Microsoft.Extensions.Configuration;

//IConfiguration Config = new ConfigurationBuilder()
//                .AddJsonFile("app.json")
//                .Build();

//string filepath = Config.GetSection("filepath").Value.ToString();
//string[] commands = File.ReadAllLines(filepath);

string[] commands = File.ReadAllLines(@".\robo_test.txt");


Play play = new Play(commands);

play.ParseCommands();