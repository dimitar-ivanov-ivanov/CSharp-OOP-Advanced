using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class InspectCommand : Command
{
    private const BindingFlags Flags = BindingFlags.Instance |
        BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

    public InspectCommand(IList<string> arguments, IProviderController providerController,
        IHarvesterController harvesterController)
        : base(arguments, providerController, harvesterController)
    {
    }

    public override string Execute()
    {
        var id = int.Parse(this.Arguments[0]);

        var harvesters = GetHarvesters();
        var providers = GetProviders();

        var found = harvesters.Concat(providers).FirstOrDefault(x=>x.ID == id);

        if(found == null)
        {
            return string.Format(Constants.NoEntityFound, id);
        }

        return found.ToString();
    }

    private IReadOnlyCollection<IEntity> GetHarvesters()
    {
        var field = this.HarvesterController
            .GetType()
            .GetProperties(Flags)
            .FirstOrDefault(x => x.Name == "Entities");

        return (IReadOnlyCollection<IEntity>)field.GetValue(this.HarvesterController);
    }

    private IReadOnlyCollection<IEntity> GetProviders()
    {
        var field = this.ProviderController
                 .GetType()
                 .GetProperties(Flags)
                 .FirstOrDefault(x => x.Name == "Entities");

        return (IReadOnlyCollection<IEntity>)field.GetValue(this.ProviderController);
    }
}
