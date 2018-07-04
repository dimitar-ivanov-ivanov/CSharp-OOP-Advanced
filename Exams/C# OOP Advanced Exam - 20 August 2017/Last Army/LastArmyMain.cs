using System;
using System.Globalization;
using System.Threading;

public class LastArmyMain
{
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        var reader = new ConsoleReader();
        var writer = new ConsoleWriter();
        var army = new Army();
        var wareHouse = new WareHouse();
        var missionController = new MissionController(army, wareHouse);
        var missionFactory = new MissionFactory();
        var soldierFactory = new SoldierFactory();

        var gameController = new GameController(soldierFactory, missionFactory, army, wareHouse, missionController);
        var engine = new Engine(reader, writer, gameController);

        engine.Run();
    }
}