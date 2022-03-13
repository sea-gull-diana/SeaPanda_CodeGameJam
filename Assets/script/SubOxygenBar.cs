using UnityEngine;
using UnityEngine.UI;

public class SubOxygenBar : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient;
    public Image fill;
    public void SetMaxSubOxygen(int oxygenLevel)
    {
        slider.maxValue = oxygenLevel;
        slider.value = oxygenLevel;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetSubOxygenLevel(float oxygenLevel)
    {
        slider.value = oxygenLevel;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}

