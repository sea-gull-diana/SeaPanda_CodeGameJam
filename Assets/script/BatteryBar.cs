using UnityEngine;
using UnityEngine.UI;

public class BatteryBar : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient;
    public Image fill;
    public void SetMaxBattery(int batteryLevel)
    {
        slider.maxValue = batteryLevel;
        slider.value = batteryLevel;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetBatteryLevel(float batteryLevel)
    {
        slider.value = batteryLevel;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
