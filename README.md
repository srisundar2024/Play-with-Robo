# Play-with-Robo

Play with Robo is the application created in .Net Core 7.0

**Project Name:** PlaywithRobo (C# Console application)
**Project Name:** PlaywithRobo_UnitTest (C# Unit Test application)

**Concepts Used:**
I have used the following concepts to develop this application, to implement Code decoupling and Test Driven Development (TDD)

1) **Single Responsibility Principle (SRP)** - each entity performs only one task like "Robot", "Table"

2) **Liskov Substitution Principle (LSP)** - "Robot" based class is provisioned to substitute with 4 different classes "DirectionEast", "DirectionWest", "DirectionNorth", "DirectionSouth"

3) **Inheritance and Abstration (Robot.cs)** - as we need 4 directions with similar tasks, created a Abstract class named "Robot" and created 4 different classes "DirectionEast", "DirectionWest", "DirectionNorth", "DirectionSouth", which will override "Robot" class and use different implementation for each different direction 

4) **Factory Design Pattern** - Created "IDirectionFactory" interface with a method "CreateDirection".
"DirectionFactory" class will implement this interface to create only the class which is necessary dynamically based on the command

**Steps to Clone & run this App:**

**Clone this repo:**
git clone git@github.com:srisundar2024/Play-with-Robo.git

**Run PlaywithRobo (C# Console application)**

Open the PlaywithRobo.sln and build as Release. Create a text file in the named "robo_test.txt" with list of commands on new lines. Navigate to the folder: ./PlaywithRobo/bin/Release Save this text file in the above folder

**Example Command 1:**
Input:
	PLACE 0,0,NORTH
	MOVE
	REPORT
	
Output: 0,1,NORTH

**Example Command 2:**
Input:
	PLACE 0,0,NORTH
	LEFT
	REPORT
	
Output: 0,0,WEST

Then run the application and you will get the output in the console

**Run PlaywithRobo_UnitTest (C# Unit Test application)**

run all the unit tests in the "UnitTest_AllCommands" file
