using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOxygen : MonoBehaviour
{
    public int maxOxygenLevel = 100;
    public static float currentOxygenLevel = 1;
    public float oxygenUsedPerSecond;
    public float oxygenIncreasedPerSecond;

    public PlayerOxygeneBar oxygenBar;
    public SubmarineMovement submarine;
    public SubmarineOxygene submarineOxygene;
    void Start()
    {
        currentOxygenLevel = maxOxygenLevel;
        oxygenBar.SetMaxOxygen(maxOxygenLevel);
    }

    void Update()
    {
        if (submarine.getPlayerInside() && submarineOxygene.GetCurrentSubOxygeneLevel() >= 0)
        {
            OxygenIncrease(oxygenIncreasedPerSecond);

        }
        else
        {
            OxygenDecrease(oxygenUsedPerSecond);
        }



    }

    public void OxygenDecrease(float _oxygenIncreasedPerSecond)
    {
        if (currentOxygenLevel > 0)
        {
            currentOxygenLevel -= _oxygenIncreasedPerSecond * Time.deltaTime;
            oxygenBar.SetOxygenLevel(currentOxygenLevel);
        }
    }

    public void OxygenIncrease(float _oxygenUsedPerSecond)
    {
        if (currentOxygenLevel < maxOxygenLevel)
        {
            currentOxygenLevel += _oxygenUsedPerSecond * Time.deltaTime;
            oxygenBar.SetOxygenLevel(currentOxygenLevel);
        }
    }

    public float GetPlayerOxygen()
    {
        return currentOxygenLevel;
    }



}
