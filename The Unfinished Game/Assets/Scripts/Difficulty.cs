using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{

    public int difficulty;
    public string[] names;

    //public Text textBox;

    private void Start()
    {
        difficulty = 0;
       // textBox.text = names[0];
    }

    // Update is called once per frame
    void Update()
    {
        //textBox.text = names[difficulty];
    }

    public void OnIncrease()
    {
        if(difficulty < names.Length)
        {
            difficulty += 1;
        }
        if(difficulty == names.Length)
        {
            difficulty = 0;
        }
        
    }

    public void OnDecrease()
    {
        if (difficulty <= names.Length && difficulty >= 0)
        {
            difficulty -= 1;
        }
        if (difficulty < 0)
        {
            difficulty = names.Length - 1;
        }
        //textBox.text = names[difficulty];
    }
}
