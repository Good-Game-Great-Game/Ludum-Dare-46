using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{

    public static bool isGoinToMenu = false;

    public void GoToMenu()
    {
        isGoinToMenu = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
