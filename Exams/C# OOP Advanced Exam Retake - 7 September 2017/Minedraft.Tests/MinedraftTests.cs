using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class TestClass
{
    [Test]
    public void TestRegister()
    {
        // Act 
        var energyRepository = new EnergyRepository();
        var sut = new ProviderController(energyRepository);
        var result1 = sut.Register(new List<string> { "Pressure", "10", "100" });
        var result2 = sut.Register(new List<string> { "Standart", "20", "100" });
        var result3 = sut.Register(new List<string> { "Solar", "30", "100" });

        // Assert
        Assert.AreEqual("Successfully registered PressureProvider", result1);
        Assert.AreEqual("Successfully registered StandartProvider", result2);
        Assert.AreEqual("Successfully registered SolarProvider", result3);
    }
}