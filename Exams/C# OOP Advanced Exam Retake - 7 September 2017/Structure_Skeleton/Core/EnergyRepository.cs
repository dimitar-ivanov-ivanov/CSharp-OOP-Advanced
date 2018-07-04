﻿public class EnergyRepository : IEnergyRepository
{
    public double EnergyStored { get; private set; }

    public void StoreEnergy(double energy)
    {
        this.EnergyStored += energy;
    }

    public bool TakeEnergy(double energyNeeded)
    {
        if(energyNeeded > EnergyStored)
        {
            return false;
        }

        this.EnergyStored -= energyNeeded;

        return true;
    }
}
