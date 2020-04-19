using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            if(PlayerController.isPlayerGonnaDie || BugScript.isTouchingCore || GlitcherScript.isTouchingCore)
            {
                StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
                BugScript.isTouchingCore = false;
                GlitcherScript.isTouchingCore = false;
            }
            if(BugSpawner.spawnEnemyNo <= 0 && GlitcherSpawner.spawnEnemyNo <= 0 && BugSpawner.isGameStarted)
            {
                StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 2));
                BugSpawner.isGameStarted = false;
            }
        }
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (CanvasUpdate.isClickingPlay)
            {
                CanvasUpdate.isClickingPlay = false;
                StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
            }
        }
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (LoseScene.isGoingToReturn)
            {
                LoseScene.isGoingToReturn = false;
                StartCoroutine(LoadScene(0));
            }
        }
        if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (WinScreen.isGoinToMenu)
            {
                WinScreen.isGoinToMenu = false;
                StartCoroutine(LoadScene(0));
            }
        }
    }

    IEnumerator LoadScene(int levelIndex)
    {
        anim.SetTrigger("fade");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(levelIndex);
    }
}
