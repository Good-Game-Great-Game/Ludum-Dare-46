using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitcherSpawner : MonoBehaviour
{

    public GameObject glitcher;

    public static int spawnEnemyNo;
    public static int spawnEnemNo;
    public int spawnEnemyNum;

    public Transform[] spawnPoints;
    public Transform[] finalPositions;
    public static Transform[] staticSpawnPos;
    public static Transform[] staticFinalPos;

    public Difficulty diff;

    public float startWaitTime;
    private float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        if(diff.difficulty == 0)
        {
            startWaitTime = 8f;
            spawnEnemyNum = 4;
        }else if(diff.difficulty == 1)
        {
            startWaitTime = 7f;
            spawnEnemyNum = 10;
        }else if(diff.difficulty == 2)
        {
            startWaitTime = 6f;
            spawnEnemyNum = 20;
        }

        staticSpawnPos = spawnPoints;
        staticFinalPos = finalPositions;

        spawnEnemyNo = spawnEnemyNum;
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnEnemyNo >= 1)
        {
            if (waitTime <= 0)
            {
                Instantiate(glitcher, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
                spawnEnemyNo--;

                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
