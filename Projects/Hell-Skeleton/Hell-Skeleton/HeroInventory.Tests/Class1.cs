using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

[TestFixture]
public class HeroInventoryTests
{
    private HeroInventory sut;

    [SetUp]
    public void TestInit()
    {
        this.sut = new HeroInventory();
    }

    [Test]
    public void AddCommmonItem()
    {
        CommonItem item = new CommonItem("item", 1, 2, 3, 4, 5);
        this.sut.AddCommonItem(item);
        Type clazz = typeof(HeroInventory);
        var field = clazz.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.GetCustomAttributes(typeof(ItemAttribute)) != null);
        
        var collection = (Dictionary<string, IItem>)field.GetValue(this.sut);

        Assert.AreEqual(1,collection.Count);
    }

    [Test]
    public void StrenghtBonusFromItems()
    {
        CommonItem item = new CommonItem("item", 1, 2, 3, 4, 5);
        this.sut.AddCommonItem(item);

        Assert.AreEqual(1,sut.TotalStrengthBonus);
    }

    [Test]
    public void AgilityBonusFromItems()
    {
        CommonItem item = new CommonItem("item", 1, 2, 3, 4, 5);
        this.sut.AddCommonItem(item);

        Assert.AreEqual(2, sut.TotalAgilityBonus);
    }

    [Test]
    public void IntelligenceBonusFromItems()
    {
        CommonItem item = new CommonItem("item", 1, 2, 3, 4, 5);
        this.sut.AddCommonItem(item);

        Assert.AreEqual(3, sut.TotalIntelligenceBonus);
    }

    [Test]
    public void HitPointsBonusFromItems()
    {
        CommonItem item = new CommonItem("item", 1, 2, 3, 4, 5);
        this.sut.AddCommonItem(item);

        Assert.AreEqual(4, sut.TotalHitPointsBonus);
    }

    [Test]
    public void DamageBonusFromItems()
    {
        CommonItem item = new CommonItem("item", 1, 2, 3, 4, 5);
        this.sut.AddCommonItem(item);

        Assert.AreEqual(5, sut.TotalDamageBonus);
    }
}

