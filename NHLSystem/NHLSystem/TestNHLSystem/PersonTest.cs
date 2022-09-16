using NHLSystem;
using System.Xml.Linq;

namespace TestNHLSystem
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        [DataRow("Connor McDavid")]
        [DataRow("Leon Draistal")]
        public void Fullname_ValidName_FullnameSet(string fullN)
        {
            Person validPlayer = new Person(fullN);
            Assert.AreEqual(fullN, validPlayer.FullName );
        }
        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("     ")]
        public void FullName_Invalid_ArgumentNullEx(string name)
        {
            var ex =Assert.ThrowsException<ArgumentNullException>(()=> new Person(name));
            Assert.AreEqual("Full name value is required", ex.ParamName);
        }
        [TestMethod]
        [DataRow("A")]
        [DataRow("AB")]
        public void FullName_InvalidNameLength_ArgumentEx(string name)
        {
            var ex =Assert.ThrowsException<ArgumentException>(()=> new Person(name));
            Assert.AreEqual(ex.Message, "Name needs to be more than 3 characters.");
        }
    }
}