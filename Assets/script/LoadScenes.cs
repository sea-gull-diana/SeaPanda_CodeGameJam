using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public bool isTitlePage = false;

    public bool isGameOver = false;
    public Animator fadeSystem;
    void Update() {
        if (PlayerOxygen.currentOxygenLevel <= 0) {
            PlayerOxygen.currentOxygenLevel = 100;
            StartCoroutine(loadPage("GameOver"));
        }

        if (Input.GetAxis("Submit") == 1) {
            if (isTitlePage) {
                StartCoroutine(loadPage("SampleScene"));
            }
            else if (isGameOver) {
                StartCoroutine(loadPage("Titre"));
            }
        }
    }

    public IEnumerator loadPage(string pageName) {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(pageName); 
    }
}
