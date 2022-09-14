using OOPReview1;
namespace NHLSystemTest

{
    [TestClass]
    public class RosterTest
    {
        [TestMethod]
        [DataRow(97,"Connor McDavid", Position.C)]
        [DataRow(50, "McDavid", Position.RW)]
        [DataRow(10, "Connor", Position.G)]
        public void Constructor_ValidValues_SetsNoNamePosition(int playerNo, string playerName, Position playerPosition)
        {
            //Arrange
            Roster validPlayer1 = new Roster(playerNo,playerName,playerPosition);

            //Act

            //Assert
            Assert.AreEqual(playerNo, validPlayer1.No);
            Assert.AreEqual(playerName, validPlayer1.Name);
            Assert.AreEqual(playerPosition, validPlayer1.Position);
        }
        [TestMethod]
        [DataRow(-1)]
        [DataRow(99)]
        public void No_InvalidNo_ThrowsArgumentOutOfrangeexception(int playerNo)
        {
         
           

            //Act and Assert
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() => 
            {
                //Arrange
                Roster invalidPlayer = new Roster(playerNo, "Idris Ilmi", Position.C);
            });
            Assert.AreEqual("Player number must be between 0 and 98", exception.ParamName);
        }
        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        [DataRow("    ")]
        public void Name_InvalidName_ThrowsArgumentNullException(string playerName)
        {
            //A
        }
    }
}