using UnityEngine;
using UnityEngine.UI;
public class AlgueCount : MonoBehaviour
{
    void Update()
    {
        this.GetComponent<Text>().text = Algue.nbAlgues.ToString();

    }
}
