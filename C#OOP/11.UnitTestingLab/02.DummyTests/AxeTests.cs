using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    private Axe axe;
    private int attack = 5;
    private int durability = 5;
    private Dummy dummy = new Dummy(1000, 1000);

    [SetUp]
    public void SetUp()
    {
        axe = new Axe(attack, durability);
    }

    [Test]
    public void When_CreateAxe_ShouldBeCorrectSetParameters()
    {
        Assert.AreEqual(axe.AttackPoints, attack);
        Assert.That(axe.DurabilityPoints, Is.EqualTo(durability));
    }

    [Test]
    public void When_AxeAttackDummy_ShouldBeLosesDurabilityPoints()
    {
        axe.Attack(dummy);

        Assert.That(axe.DurabilityPoints, Is.EqualTo(durability - 1));
    }

    [Test]
    public void When_AxeAttackDummyWithZeroDurability_ShoutBeThrowException()
    {
        axe = new Axe(10, 0);
        Assert.That(() =>
        {
            axe.Attack(dummy);

        }, Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }


    [Test]
    public void When_AxeAttackDummyWithNegativeDurability_ShoutBeThrowException()
    {
        axe = new Axe(10, -1);
        Assert.That(() =>
        {
            axe.Attack(dummy);

        }, Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }

}