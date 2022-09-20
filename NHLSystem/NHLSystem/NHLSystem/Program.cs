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