using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class GameController
{
    private const string Preffix = "Parse";

    private ISoldierFactory soldierFactory;
    private IMissionFactory missionFactory;
    private IArmy army;
    private IWareHouse wareHouse;
    private MissionController missionController;

    public GameController(ISoldierFactory soldierFactory, IMissionFactory missionFactory, IArmy army, IWareHouse wareHouse, MissionController missionController)
    {
        this.soldierFactory = soldierFactory;
        this.missionFactory = missionFactory;
        this.army = army;
        this.wareHouse = wareHouse;
        this.missionController = missionController;
    }

    public void GiveInputToGameController(string input)
    {
        var args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        var command = Preffix + args[0];
        args = args.Skip(1).ToList();

        var method = this.GetType()
            .GetMethods(BindingFlags.Instance | BindingFlags.Static |
            BindingFlags.Public | BindingFlags.NonPublic)
            .FirstOrDefault(x => x.Name == command);

        method.Invoke(this, new object[] { args });
    }

    public string RequestResult()
    {
        var builder = new StringBuilder();

        return "Results:\n" +
               $"Successful missions - {missionController.SuccessMissionCounter}\n" + 
               $"Failed missions - {missionController.FailedMissionCounter}";
    }

    private void ParseSoldier(IList<string> args)
    {
        if (args.Count == 2)
        {
            var soldierType = args[1];
            Regenerate(soldierType);
        }
        else
        {
            AddSoldierToArmy(args);
        }
    }

    private void ParseWareHouse(IList<string> args)
    {
        var name = args[0];
        var count = int.Parse(args[1]);

        this.wareHouse.AddAmmunition(name, count);
    }

    private void Regenerate(string soldierType)
    {
        this.army.RegenerateTeam(soldierType);
    }

    private void AddSoldierToArmy(IList<string> args)
    {
        var type = args[0];
        var name = args[1];
        var age = int.Parse(args[2]);
        var experience = double.Parse(args[3]);
        var endurance = double.Parse(args[4]);

        var soldier = soldierFactory.CreateSoldier(type, name, age, experience, endurance);

        army.AddSoldier(soldier);
    }

    private void ParseMission(IList<string> args)
    {
        var missionType = args[0];
        var scoreToComplete = double.Parse(args[1]);

        var mission = missionFactory.CreateMission(missionType, scoreToComplete);
        missionController.PerformMission(mission);
    }
}