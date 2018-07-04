namespace FestivalManager.Entities.Instruments
{
    using System;
    using Contracts;

	public abstract class Instrument : IInstrument
	{
		private double wear;
        private double repairAmount;
		private const int MaxWear = 100;
        private const int MinWear = 0;

		protected Instrument(double repairAmount)
		{
			this.Wear = MaxWear;
            this.repairAmount = repairAmount;
		}

		public double Wear
		{
			get
			{
				return this.wear;
			}
			private set
			{
				this.wear = Math.Min(Math.Max(value, MinWear), MaxWear);
			}
		}

		public void Repair() => this.Wear += this.repairAmount;

		public void WearDown() => this.Wear -= this.repairAmount;

		public bool IsBroken => this.Wear <= MinWear;

		public override string ToString()
		{
			var instrumentStatus = this.IsBroken ? "broken" : $"{this.Wear}%";

			return $"{this.GetType().Name} [{instrumentStatus}]";
		}
	}
}
