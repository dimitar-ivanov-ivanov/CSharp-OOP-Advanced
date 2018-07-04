namespace King_s_Gambit.Contracts
{
    using System;

    public interface IUnit
    {
        string Name { get; }

        void RespondToAttack(object sender, EventArgs args);
    }
}
