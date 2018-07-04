﻿namespace FestivalManager.Entities.Instruments
{
    public class Guitar : Instrument
    {
        private const int GuitarRepairAmount = 60;

        public Guitar() 
            : base(GuitarRepairAmount)
        {
        }
    }
}
