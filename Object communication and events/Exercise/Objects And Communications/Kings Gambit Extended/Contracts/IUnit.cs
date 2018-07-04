namespace Kings_Gambit_Extended.Contracts
{
    using System;

    public interface IUnit
    {
        string Name { get; }

        void RespondToAttack(object sender, EventArgs args);
    }
}
