using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterZone : MonoBehaviour
{
    private bool isMonsterComing = false;

    private bool isMonsterHere = false;

    public static bool isAttacking = false;

    public Animator fadeSystem;

    public Animator redEyes;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMonsterComing) {
            StartCoroutine(monsterApproaching());
        }

        if (isMonsterHere) {
            StartCoroutine(hidingFromMonster());
            if (SubmarineMovement.isOn) {
                redEyes.SetTrigger("Appear");
                StartCoroutine(WaitForRedEyes());
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
		isMonsterComing = true;
	}

    public IEnumerator monsterApproaching() {
        fadeSystem.SetTrigger("LongFadeIn");
        yield return new WaitForSecondsRealtime(3f);
        isMonsterHere = true;
        isMonsterComing = false;
    }

    public IEnumerator hidingFromMonster() {
        yield return new WaitForSecondsRealtime(3f);
        fadeSystem.SetTrigger("FadeOut");
        isMonsterHere = false;
    }

    public IEnumerator WaitForRedEyes() {
        yield return new WaitForSecondsRealtime(2f);
        isAttacking = true;
    }
}
