// See https://aka.ms/new-console-template for more information
using OOPReview1;
//Test creating a new roster with valid values
Roster validPlayer1 = new Roster(97,"Connor McDavid", Position.C);
Console.WriteLine(validPlayer1.ToString());

//Testing a new Roster with an invalid Number

try
{
    Roster invalidPlayerNo = new Roster(100, "Leon Draistil", Position.C);
}
catch(ArgumentOutOfRangeException ex )
{
    Console.WriteLine(ex.ParamName);
    Console.WriteLine(ex.Message);
}
//Testing an invalid player name
try
{
    Roster invalidPlayerNo = new Roster(50, null, Position.C);
}
catch(ArgumentNullException ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine(ex.ParamName);
}



var senators = new NhlTeam(
    NhlConferene.Eastern, 
    NhlDivision.Atlantic,
    "Senators",
    "Ottawa");
senators.GamesPlayed = 82;
senators.Wins = 33;
senators.Losses = 42;
senators.OvertimeLosses = 7;
// Print the Points - should be 73
Console.WriteLine(senators);
Console.WriteLine($"Points = {senators.Points}");
    


