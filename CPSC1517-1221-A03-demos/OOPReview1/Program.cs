// See https://aka.ms/new-console-template for more information
using OOPReview1;

NHL_Team Senator = new NHL_Team(NHLConference.East, NHLDivision.Atlantic, "Senators", "Ottawa");
Senator.GamesPlayed = 82;
Senator.Wins = 33;
Senator.Losses = 42;
Senator.OvertimeLossses = 7;
Console.WriteLine(Senator.Points);