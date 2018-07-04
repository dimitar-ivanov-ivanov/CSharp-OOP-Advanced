namespace Inferno_Infinity.Contracts
{
    public interface IWeaponFactory
    {
        IWeapon CreateWeapon(string weaponType, string itemRarityName, string weaponName);
    }
}
