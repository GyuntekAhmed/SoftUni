using NUnit.Framework;

namespace FootballTeam.Tests
{
    public class Tests
    {
        FootballPlayer player;
        FootballTeam team;

        [SetUp]
        public void Setup()
        {
            player = new FootballPlayer("Me", 10, "Forward");
            team = new FootballTeam("MyTeam", 25);
        }

        [Test]
        public void PlayerConstructorShouldSetCorrectly()
        {
            string actualName = player.Name;
            int actualNumber = player.PlayerNumber;
            string actualPos = player.Position;

            Assert.That(actualName, Is.EqualTo("Me"));
            Assert.That(actualNumber, Is.EqualTo(10));
            Assert.That(actualPos ,Is.EqualTo("Forward"));
        }
    }
}