using System;
using TrafficLights.Enums;

public class TrafficLight
{
    private LightColor lightColor;

    public TrafficLight(string lightColor)
    {
         this.lightColor = (LightColor)Enum.Parse(typeof(LightColor), lightColor);
    }

    public void UpdateState()
    {
        lightColor++;
        var lighColorCount = Enum.GetNames(typeof(LightColor)).Length;
        lightColor = (LightColor)((int)lightColor % lighColorCount);
    }

    public override string ToString()
    {
        return lightColor.ToString();
    }
}
