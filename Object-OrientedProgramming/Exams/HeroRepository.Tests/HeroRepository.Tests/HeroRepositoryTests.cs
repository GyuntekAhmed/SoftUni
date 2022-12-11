using System;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    private Hero hero;
    private HeroRepository heroes;

    [SetUp]
    public void SetUp()
    {
        heroes = new HeroRepository();
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
            heroes.Create(hero2);
        },
        "Hero is null");
    }
    [Test]
    public void CreateThrowWhenContainsHero()
    {
        heroes.Create(hero);

        Assert.Throws<InvalidOperationException>(() =>
        {
            heroes.Create(hero);
        },
        $"Hero with name {hero.Name} already exists");
    }
    [Test]
    public void CreateCorrectly()
    {
        heroes.Create(hero);

        Assert.AreEqual(1, heroes.Heroes.Count);
    }
    [Test]
    public void RemoveThrowsWhenNameIsNull()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            heroes.Remove(null);
        },
        "Name cannot be null");
    }
    [Test]
    public void RemoveCorrectly()
    {
        Hero hero2 = new Hero("You", 6);

        heroes.Create(hero);
        heroes.Create(hero2);

        heroes.Remove(hero.Name);

        Assert.AreEqual(1, heroes.Heroes.Count);
    }

    [Test]
    public void GetHeroWithHighestLevelCorrectly()
    {
        Hero hero2 = new Hero("You", 7);

        heroes.Create(hero);
        heroes.Create(hero2);

        Hero highHero = heroes.GetHeroWithHighestLevel();

        Assert.AreEqual(7, highHero.Level);
    }
    [Test]
    public void GetHeroCorrectly()
    {
        heroes.Create(hero);

        Hero hero2 = heroes.GetHero("Me");

        Assert.AreEqual("Me", hero2.Name);
    }
}