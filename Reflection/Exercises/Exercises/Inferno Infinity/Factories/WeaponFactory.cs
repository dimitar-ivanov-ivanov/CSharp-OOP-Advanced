namespace Inferno_Infinity.Factories
{
    using Inferno_Infinity.Contracts;
    using Inferno_Infinity.Enums;
    using System;
    using System.Linq;
    using System.Reflection;

    public class WeaponFactory : IWeaponFactory
    {
        public IWeapon CreateWeapon(string weaponType, string itemRarityName, string weaponName)
        {
            var typeToActivate = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == weaponType);

            var itemRarity = (ItemRarity)Enum.Parse(typeof(ItemRarity), itemRarityName);

            return (IWeapon)Activator.CreateInstance(typeToActivate,
                new object[] { weaponName, itemRarity });
        }
    }
}
