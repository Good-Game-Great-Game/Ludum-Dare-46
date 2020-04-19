using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{

    public Transform[] spawnPoint;
    public GameObject bug;

    public static bool isGameStarted = false;

    public Difficulty diff;

    public static int spawnEnemyNo;
    public static int spawnEnemNo;
    public int enemyNumber;

    public float startWaitTime;
    private float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        isGameStarted = false;

        if(diff.difficulty == 0)
        {
            startWaitTime = 5f;
            enemyNumber = 10;
        }else if(diff.difficulty == 1)
        {
            startWaitTime = 4f;
            enemyNumber = 20;
        }else if(diff.difficulty == 2)
        {
            startWaitTime = 2f;
            enemyNumber = 32;
        }

        spawnEnemyNo = enemyNumber;
        spawnEnemNo = spawnEnemyNo;
        waitTime = startWaitTime;

        isGameStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnEnemyNo >= 1)
        {
            int r;
            if (waitTime <= 0)
            {
                r = Random.Range(0, spawnPoint.Length);
                Instantiate(bug, spawnPoint[r].position, Quaternion.identity);
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
