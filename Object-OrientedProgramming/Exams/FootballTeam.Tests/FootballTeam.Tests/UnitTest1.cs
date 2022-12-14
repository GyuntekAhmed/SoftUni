using NUnit.Framework;
using System;

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
            int actualScore = player.ScoredGoals;

            Assert.That(actualName, Is.EqualTo("Me"));
            Assert.That(actualNumber, Is.EqualTo(10));
            Assert.That(actualPos ,Is.EqualTo("Forward"));
            Assert.That(actualScore, Is.EqualTo(0));
        }
        [Test]
        public void PlayerNameShouldSetCorrectly()
        {
            string actualName = player.Name;

            Assert.That(actualName, Is.EqualTo("Me"));
        }
        [TestCase(null)]
        [TestCase("")]
        public void PlayerNameThrowWithInvalidName(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                player = new FootballPlayer(name, 11, "Forward");
            },
            "Name cannot be null or empty!");
        }
        [Test]
        public void PlayerNumberShouldSetCorrectly()
        {
            int actualNum = player.PlayerNumber;

            Assert.That(actualNum, Is.EqualTo(10));
        }
        [TestCase(0)]
        [TestCase(30)]
        public void PlayerNumberThrowWithInvalidValue(int expectedNum)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                player = new FootballPlayer("Me", expectedNum, "Forward");
            },
            "Player number must be in range [1,21]");
        }
        [TestCase("Forward")]
        [TestCase("Midfielder")]
        [TestCase("Goalkeeper")]
        public void PositionShouldSetCorrectly(string position)
        {
            player = new FootballPlayer("Me", 10, position);
            string actualPos = player.Position;

            Assert.That(actualPos, Is.EqualTo(position));
        }
        [Test]
        public void PositionThrowWithInvalidValue()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                player = new FootballPlayer("Me", 10, "Aaa");
            },
            "Invalid Position");
        }
        [Test]
        public void ScoreShouldSetScoreCorrectly()
        {
            player.Score();

            int expScore = 1;
            int actualScore = player.ScoredGoals;

            Assert.That(actualScore, Is.EqualTo(expScore));
        }
        [Test]
        public void TeamConstructorShouldSetCorrectly()
        {
            string actualName = team.Name;
            int actualCap = team.Capacity;
            int actualPlayers = team.Players.Count;

            Assert.That(actualName, Is.EqualTo("MyTeam"));
            Assert.That(actualCap, Is.EqualTo(25));
            Assert.That(actualPlayers, Is.EqualTo(0));
        }
        [Test]
        public void NameShouldSetCorrectlyName()
        {
            string expName = "MyTeam";
            string actualName = team.Name;

            Assert.That(actualName, Is.EqualTo(expName));
        }
        [TestCase(null)]
        [TestCase("")]
        public void NameThrowWithEmptyName(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                team = new FootballTeam(name, 22);
            },
            "Name cannot be null or empty!");
        }
        [Test]
        public void CapacityShouldSetValueCorrectly()
        {
            int actualCapacity = team.Capacity;

            Assert.That(actualCapacity, Is.EqualTo(25));
        }
        [Test]
        public void CapacityThrowWithLessThan15()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                team = new FootballTeam("MyTeam", 10);
            },
            "Capacity min value = 15");
        }
        [Test]
        public void ListOfPlayersShouldSetCorrectly()
        {
            int countOfPlayers = team.Players.Count;

            Assert.That(countOfPlayers, Is.EqualTo(0));
        }
        [Test]
        public void AddNewPlayerWhenNoSpace()
        {
            for (int i = 0; i < 25; i++)
            {
                team.AddNewPlayer(player);
            }

            string expectedOut = "No more positions available!";
            string actualOut = team.AddNewPlayer(player);

            Assert.That(actualOut, Is.EqualTo(expectedOut));
        }
        [Test]
        public void AddNewPlayerCorrectlyCount()
        {
            team.AddNewPlayer(player);

            Assert.That(team.Players.Count, Is.EqualTo(1));
        }
        [Test]
        public void AddNewPlayerCorrectly()
        {
            string expectedOut =
                $"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}";
            string actualOut = team.AddNewPlayer(player);

            Assert.That(actualOut, Is.EqualTo(expectedOut));
        }
        [Test]
        public void PickPlayerCorrectly()
        {
            team.AddNewPlayer(player);

            string expectedPlayer = "Me";
            var actualPlayer = team.PickPlayer(expectedPlayer);

            Assert.That(actualPlayer.Name, Is.EqualTo(expectedPlayer));
        }
        [Test]
        public void PlayerScoreShouldReturnCorrectly()
        {
            team.AddNewPlayer(player);

            string expectedOutput = "Me scored and now has 1 for this season!";

            string output = team.PlayerScore(10);
            var playerOut = team.PickPlayer("Me");

            Assert.That(output, Is.EqualTo(expectedOutput));

            Assert.That(player.ScoredGoals, Is.EqualTo(1));
            Assert.That(playerOut.ScoredGoals, Is.EqualTo(1));
        }
    }
}