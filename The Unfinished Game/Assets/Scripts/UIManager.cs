using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text bugsLeft;
    public Text glitchesLeft;
    public Text hope;

    //public BugSpawner bugs;
    //public GlitcherSpawner glitches;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hope.text = "Hope: " + HopeScript.hope;
        bugsLeft.text = "Bugs left: " + BugSpawner.spawnEnemyNo;
        glitchesLeft.text = "Glitches left: " + GlitcherSpawner.spawnEnemyNo;
    }
}
