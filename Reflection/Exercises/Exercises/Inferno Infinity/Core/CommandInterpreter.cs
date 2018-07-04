namespace Inferno_Infinity.Core
{
    using Inferno_Infinity.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IList<IWeapon> weapons;
        private IWeaponFactory weaponFactory;
        private IGemFactory gemFactory;

        public CommandInterpreter(IWeaponFactory weaponFactory, IGemFactory gemFactory)
        {
            this.weapons = new List<IWeapon>();
            this.weaponFactory = weaponFactory;
            this.gemFactory = gemFactory;
        }

        public void Create(string[] args)
        {
            var weaponTypes = args[0].Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            var weaponType = weaponTypes[1];
            var itemRarityName = weaponTypes[0];
            var weaponName = args[1];

            var weapon = this.weaponFactory.CreateWeapon(weaponType,
                itemRarityName, weaponName);

            this.weapons.Add(weapon);
        }

        public void Add(string[] args)
        {
            var gemTypes = args[2].Split(new[] { ' ' },
               StringSplitOptions.RemoveEmptyEntries);

            var weaponName = args[0];
            var slot = int.Parse(args[1]);
            var gemClarityName = gemTypes[0];
            var gemType = gemTypes[1];

            var gem = this.gemFactory.CreateGem(gemType, gemClarityName);

            var weapon = this.weapons
                .FirstOrDefault(x => x.Name == weaponName);

            if (weapon != null && slot < weapon.Sockets.Length)
            {
                weapon.Sockets[slot] = gem;
            }
        }

        public void Remove(string[] args)
        {
            var weaponName = args[0];
            var index = int.Parse(args[1]);
            var weapon = this.weapons.FirstOrDefault(x => x.Name == weaponName);

            if (weapon != null && index >= 0 && 
                index < weapon.Sockets.Length)
            {
                weapon.Sockets[index] = null;
            }
        }

        public void Print(string[] args)
        {
            var weaponName = args[0];
            var weapon = this.weapons.FirstOrDefault(x => x.Name == weaponName);

            if (weapon != null)
            {
                Console.WriteLine(weapon.Print());
            }
        }
    }
}
