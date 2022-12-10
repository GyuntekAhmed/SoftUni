using System;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    private Hero hero;
    private HeroRepository heroRepository;

    [SetUp]
    public void SetUp()
    {
        heroRepository = new HeroRepository();
        hero = new Hero("Me", 5);
    }

    [Test]
    public void HeroConstructorShouldSetCorrectly()
    {
        string expectedName = "Me";
        int expectedLevel = 5;

        string actualName = hero.Name;
        int actualLevel = hero.Level;

        Assert.AreEqual(expectedName, actualName);
        Assert.AreEqual(expectedLevel, actualLevel);
    }
    [Test]
    public void CreateThrowWhenIsNull()
    {
        Hero hero2 = null;

        Assert.Throws<ArgumentNullException>(() =>
        {
            heroRepository.Create(hero2);
        },
        "Hero is null");
    }
    [Test]
    public void CreateThrowWhenContainsHero()
    {
        heroRepository.Create(hero);

        Assert.Throws<InvalidOperationException>(() =>
        {
            heroRepository.Create(hero);
        },
        $"Hero with name {hero.Name} already exists");
    }
    [Test]
    public void CreateCorrectly()
    {
        heroRepository.Create(hero);

        Assert.AreEqual(1, heroRepository.Heroes.Count);
    }
    [Test]
    public void RemoveThrowWithNullName()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            heroRepository.Remove(null);
        },
        "Name cannot be null");
    }
    [Test]
    public void RemoveCorrectly()
    {
        Hero hero2 = new Hero("You", 6);

        heroRepository.Create(hero);
        heroRepository.Create(hero2);

        heroRepository.Remove(hero.Name);

        Assert.AreEqual(1, heroRepository.Heroes.Count);
    }

    [Test]
    public void GetHeroWithHighestLevelCorrectly()
    {
        Hero hero2 = new Hero("You", 7);

        heroRepository.Create(hero);
        heroRepository.Create(hero2);

        Hero highHero = heroRepository.GetHeroWithHighestLevel();

        Assert.AreEqual(7, highHero.Level);
    }
    [Test]
    public void GetHeroCorrectly()
    {
        heroRepository.Create(hero);

        Hero hero2 = heroRepository.GetHero("Me");

        Assert.AreEqual("Me", hero2.Name);
    }
}