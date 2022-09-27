/* Test plan for Person
 * 
 * Test case
 * 1 - Valid Full Name 
 * 2- Null Full name
 * 3- Empty Fullnam
 * 4- whitespace full name
 * 5- full name < 3 characters
 * */
using NHLSystem;
using System.Collections.Generic;
using System.Text.Json;

Person validPerson = new Person("Connor McDavid");
Console.WriteLine(validPerson.FullName);

try
{
    Person validPerson1 = new Person("AB");
    Console.WriteLine(validPerson1.FullName);
}
catch(ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}

DateTime start = DateTime.Parse("2021-09-02");
Coach oilersCoach = new Coach("Day Woodcroft", start);
Team oilersTeam = new Team("Edmonton Oilers", oilersCoach);
Player player1 = new Player("Connor McDavid", Position.C, 97);
Player player2 = new Player("Connor McDavid", Position.C, 96);
Player player3 = new Player("Connor McDavid", Position.C, 95);
oilersTeam.AddPlayer(player3);
oilersTeam.AddPlayer(player2);
oilersTeam.AddPlayer(player1);
player1.Goals = 44;
player1.Assists = 79;
player2.Goals = 22;
player2.Assists = 17;
player3.Goals = 55;
player3.Assists = 55;

Console.WriteLine($"Players in team is {oilersTeam.Players.Count}");
foreach(Player player in oilersTeam.Players)
{
    Console.WriteLine(player);
}
Console.WriteLine($"Total points is {oilersTeam.TotalPlayerPoints} ");
CreateTeamJsonFile();
oilersTeam = ReadTeamInfoFromJsonFile();

DisplayTeamInfo(oilersTeam);

//static Team ReadPlayerCsvFile()
//{
//    const string PlayerCsvFile = "../../../Players.csv";
//    Coach teamCoach = new Coach("Jay Woodcroft", DateTime.Parse("2022-02-10"));
//    Team oilersTeam = new Team("Edmonton Oilers", teamCoach);
//    try
//    {
//        string[] allLines= File.ReadAllLines(PlayerCsvFile);
//        foreach(string line in allLines)
//        {
//            try
//            {
//                Player currentPlayer = null;
//                bool success = Player.TryParse(line, out currentPlayer);
//                if (success)
//                {
//                    oilersTeam.AddPlayer(currentPlayer);    
//                }
//            }
//            catch(FormatException ex)
//            {
//                Console.WriteLine($"Format exception {ex.Message}");
//            }
//            catch(Exception ex)
//            {
//                Console.WriteLine($"Error parsing data from line {ex.Message}");
//            }
//        }
//    }
//    catch(Exception ex)
//    {
//        Console.WriteLine($"{ex.Message}");    
//    }
//    return oilersTeam;
//}
static Team ReadTeamInfoFromJsonFile()
{
    Team currentTeam = null!;
    try
    {
        const string TeamJsonFile = "../../../Team.json";
        string jsonString = File.ReadAllText(TeamJsonFile);
        JsonSerializerOptions options = new JsonSerializerOptions
        {
           WriteIndented = true,
         // IncludeFields = true,
        };
        currentTeam = JsonSerializer.Deserialize<Team>(jsonString, options);
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    return currentTeam;
}
static void DisplayTeamInfo(Team currentTeam)
{
    string name = currentTeam.TeamName;
    string cName = currentTeam.Coach.FullName;
    DateTime hireDate = currentTeam.Coach.StartDate;
    List <Player> lPlayer = currentTeam.Players;
    Console.WriteLine($"{name},{cName}, {hireDate}");
    foreach (Player x in lPlayer)
    {
        Console.WriteLine($"{x.FullName}, {x.Position}, {x.PrimaryNo}, {x.Goals}, {x.Assists}, {x.Points}");
    }
    lPlayer.ForEach(player => Console.WriteLine(player.ToString()));
}

static void CreatePlayersCsvFile()
{
    DateTime startDate = DateTime.Parse("2021-09-02");
    Coach oilersCoach = new Coach("Jay Woodcroft", startDate);
    // Create a new Team
    Team oilersTeam = new Team("Edmonton Oilers", oilersCoach);
    // Add 3 players to the Team
    Player player1 = new Player("Connor McDavid", Position.C, 97);
    Player player2 = new Player("Evander Kane", Position.LW, 91);
    Player player3 = new Player("Leeon Draisaitl", Position.C, 29);
    oilersTeam.AddPlayer(player1);
    oilersTeam.AddPlayer(player2);
    oilersTeam.AddPlayer(player3);

    const string PlayerCsvFile = "../../../Players.csv";
    File.WriteAllLines(PlayerCsvFile,
        oilersTeam.Players.Select(currentPlayer => currentPlayer.ToString()).ToList());

}

static void CreateTeamJsonFile()
{
    DateTime startDate = DateTime.Parse("2021-09-02");
    Coach oilersCoach = new Coach("Jay Woodcroft", startDate);
    // Create a new Team
    Team oilersTeam = new Team("Edmonton Oilers", oilersCoach);
    // Add 3 players to the Team
    Player player1 = new Player("Connor McDavid", Position.C, 97);
    Player player2 = new Player("Evander Kane", Position.LW, 91);
    Player player3 = new Player("Leeon Draisaitl", Position.C, 29);
    oilersTeam.AddPlayer(player1);
    oilersTeam.AddPlayer(player2);
    oilersTeam.AddPlayer(player3);

    const string TeamJsonFile = "../../../Team.json";
    JsonSerializerOptions options = new JsonSerializerOptions
    {
        WriteIndented = true,
        IncludeFields = true
    };
    string jsonString = JsonSerializer.Serialize<Team>(oilersTeam, options);
    File.WriteAllText(TeamJsonFile, jsonString);


}