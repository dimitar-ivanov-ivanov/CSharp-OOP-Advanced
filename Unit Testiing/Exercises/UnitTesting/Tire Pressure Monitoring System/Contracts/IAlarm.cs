namespace Tire_Pressure_Monitoring_System.Contracts
{
    public interface IAlarm
    {
        void Check();

        bool AlarmOn { get; }
    }
}