using UnityEngine;

public class SubmarineOxygene : MonoBehaviour
{
    public int maxSubOxygene;
    public int oxygeneParAlgue;
    public float currentSubOxygeneLevel;
    public float suboxygenUsedPerSecond;


    public SubOxygenBar oxygenBar;
    public SubmarineMovement submarine;
    void Start()
    {
        currentSubOxygeneLevel = maxSubOxygene;
        oxygenBar.SetMaxSubOxygen(maxSubOxygene);
    }

    void Update()
    {
        if (submarine.getPlayerInside() && Algue.nbAlgues>0)
        {
            SubOxygeneIncrease();
        }
        SubOxygenDecrease(suboxygenUsedPerSecond);
    }

    public void SubOxygenDecrease(float _SuboxygenUsedPerSecond)
    {
        if (currentSubOxygeneLevel > 0)
        {
            currentSubOxygeneLevel -= _SuboxygenUsedPerSecond * Time.deltaTime;
            oxygenBar.SetSubOxygenLevel(currentSubOxygeneLevel);
        }
    }

    public void SubOxygeneIncrease()
    {
        if (currentSubOxygeneLevel < maxSubOxygene)
        {
            currentSubOxygeneLevel += Algue.nbAlgues * oxygeneParAlgue;
            Algue.nbAlgues = 0;
        }
    }

    public float GetCurrentSubOxygeneLevel()
    {
        return currentSubOxygeneLevel;
    }
}
