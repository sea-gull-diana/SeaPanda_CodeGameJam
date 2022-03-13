using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public SubmarineMovement submarineMovement;

    public float cameraSousmarin;
    public float cameraPlongeur;

    public float timeOffset;
    public Vector3 posOffset;

    private Vector3 velocity;

    void Update()
    {
        if (submarineMovement.getPlayerInside())
        {
            gameObject.GetComponent<Camera>().orthographicSize = cameraSousmarin;
        }
        else
        {
            gameObject.GetComponent<Camera>().orthographicSize = cameraPlongeur;
        }
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
    }
}