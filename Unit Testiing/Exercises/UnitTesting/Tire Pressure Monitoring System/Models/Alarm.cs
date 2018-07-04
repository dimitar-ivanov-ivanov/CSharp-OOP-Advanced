﻿namespace Tire_Pressure_Monitoring_System.Models
{
    using Tire_Pressure_Monitoring_System.Contracts;

    public class Alarm  : IAlarm
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;

        readonly Sensor _sensor = new Sensor();

        bool _alarmOn = false;

        public void Check()
        {
            double psiPressureValue = _sensor.PopNextPressurePsiValue();

            if (psiPressureValue < LowPressureThreshold ||
                HighPressureThreshold < psiPressureValue)
            {
                _alarmOn = true;
            }
        }

        public bool AlarmOn
        {
            get { return _alarmOn; }
        }
    }
}