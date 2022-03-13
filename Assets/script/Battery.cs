using UnityEngine;

public class Battery : MonoBehaviour
{
    public int maxBattery;
    public float currentBattery;
    public float batteryUsedPerSecond;


    public BatteryBar batteryBar;
    public SubmarineMovement submarine;
    void Start()
    {
        float saveBatteryUsedPerSecond = batteryUsedPerSecond;
        currentBattery = maxBattery;
        batteryBar.SetMaxBattery(maxBattery);
    }

    void Update()
    {
        if (submarine.getIsOn())
        {
            SubOxygenDecrease(batteryUsedPerSecond * 2);
        }
        else
        {
            SubOxygenDecrease(batteryUsedPerSecond);
        }
    }

    public void SubOxygenDecrease(float _SuboxygenUsedPerSecond)
    {
        if (currentBattery > 0)
        {
            currentBattery -= _SuboxygenUsedPerSecond * Time.deltaTime;
            batteryBar.SetBatteryLevel(currentBattery);
        }
    }

    public float GetCurrentBatery()
    {
        return currentBattery;
    }
}
