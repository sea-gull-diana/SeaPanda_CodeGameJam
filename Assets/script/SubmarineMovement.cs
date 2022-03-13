using UnityEngine;

public class SubmarineMovement : MonoBehaviour
{
    public int speed;

    public static bool isOn;
    public bool PlayerCanEnter;
    private bool PlayerInside;
    private int numTarget;

    public Transform[] targets;
    private Transform target;
    public GameObject joueur;
    public SpriteRenderer spriteSousMarin;

    private void Start()
    {
        isOn = false;
        numTarget = -1;
        isArrived();       
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            isOn = !isOn;
        }
        if(PlayerCanEnter && Input.GetKeyDown(KeyCode.E))
        {
            InAndOutSumbamrine();
        }
        if (isOn)
        {
            MoveSubmarine(target);
        }
        if (PlayerInside)
        {
            joueur.GetComponent<Transform>().position = transform.position;
        }
    }

    private void MoveSubmarine(Transform cible)
    {
        Vector3 dir = cible.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerCanEnter = true;
        }
        if (collision.CompareTag("Target"))
        {
            isArrived();
        }
        if (collision.CompareTag("needFlipY"))
        {
            isArrived();
            spriteSousMarin.flipY = !spriteSousMarin.flipY;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerCanEnter = false;
        }
    }

    private void InAndOutSumbamrine()
    {
        PlayerInside = !PlayerInside;
        joueur.GetComponent<SpriteRenderer>().enabled = !joueur.GetComponent<SpriteRenderer>().enabled;
    }

    private void isArrived()
    {
        if (numTarget == targets.Length - 1)
        {
            isOn = false;
        }
        else
        {
            numTarget++;
        }
        target = targets[numTarget];
        transform.right = target.position - transform.position;
    }

    public bool getPlayerInside()
    {
        return PlayerInside;
    }

    public bool getIsOn()
    {
        return isOn;
    }
}
