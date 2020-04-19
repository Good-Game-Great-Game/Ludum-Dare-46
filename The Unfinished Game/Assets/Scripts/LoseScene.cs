using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScene : MonoBehaviour
{

    public static bool isGoingToReturn = false;

    public void GoToMenu()
    {
        isGoingToReturn = true;
        //SceneManager.LoadScene(0);
        HopeScript.HopeReset();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
