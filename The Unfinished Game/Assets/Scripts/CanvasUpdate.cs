using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CanvasUpdate : MonoBehaviour
{

    public Text textBox;
    public Difficulty diff;

    public static bool isClickingPlay = false;

    public string[] diffViewerTypes;
    public TextMeshProUGUI diffViewer;

    void Update()
    {
        diffViewer.text = diffViewerTypes[diff.difficulty];
        textBox.text = diff.names[diff.difficulty];
    }

    public void PlayGame()
    {
        isClickingPlay = true;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }
}
