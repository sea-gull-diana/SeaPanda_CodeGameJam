using UnityEngine;
using UnityEngine.UI;

public class PlayerOxygeneBar : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient;
    public Image fill;
    public void SetMaxOxygen(int oxygenLevel)
    {
        slider.maxValue = oxygenLevel;
        slider.value = oxygenLevel;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetOxygenLevel(float oxygenLevel)
    {
        slider.value = oxygenLevel;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
