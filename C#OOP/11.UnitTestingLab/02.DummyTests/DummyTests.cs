using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private Dummy dummy;
    private int healt = 10;
    private int experience = 12;

    [SetUp]

    public void SetUp()
    {
         dummy = new Dummy(healt, experience);
    }

    [Test]
    public void When_DummyAlliveTakeAttack_ShouldBeDecreaseHealt()
    {
        dummy.TakeAttack(5);

        Assert.That(dummy.Health, Is.EqualTo(healt - 5));
    }

    [Test]
    public void When_DummyIsDeadWithZeroHealt_ShouldBeBool()
    {
        dummy = new Dummy(0, 40);

        Assert.That(dummy.IsDead(), Is.EqualTo(true));
    }

    [Test]
    public void When_DummyIsDeadWithNegativeHealt_ShouldBeBool()
    {
        dummy = new Dummy(-5, 40);

        Assert.That(dummy.IsDead(), Is.EqualTo(true));
    }

    [Test]
    public void When_DummyIsAllive_ShouldBeBool()
    {
        Assert.That(dummy.IsDead(), Is.EqualTo(false));
    }

    [Test]  

    public void When_DummyIsDeadAndTakeAttack_ShouldBeThrowException()
    {
        dummy = new Dummy(-1, 12);

        Assert.That(() =>
        {
            dummy.TakeAttack(5);
        }, Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }

    [Test]

    public void When_DummyDeadGiveExperience_Experience()
    {
        dummy = new Dummy(0, experience);
        Assert.That(dummy.GiveExperience(), Is.EqualTo(experience));
    }

    [Test]

    public void When_DummyAlliveGiveExperience_Experience()
    {
        
        Assert.That(() =>
        {
            dummy.GiveExperience();
        }, Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }
}
