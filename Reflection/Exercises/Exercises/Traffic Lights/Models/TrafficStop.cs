namespace Traffic_Lights.Models
{
    using System;
    using Traffic_Lights.Enums;

    public class TrafficStop
    {
        private TrafficLights[] trafficLights;

        public TrafficStop(params TrafficLights[] trafficLights)
        {
            this.trafficLights = trafficLights;
        }

        public void TurnLights()
        {
            for (int i = 0; i < trafficLights.Length; i++)
            {
                var currentLight = (int)trafficLights[i];

                var next = currentLight + 1 == 3 ? 0 :
                    currentLight + 1;

                trafficLights[i] = (TrafficLights)next;

                Console.Write(trafficLights[i] + " ");
            }
        }
    }
}
