using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeHope : MonoBehaviour
{

    public Transform[] hopePos;

    public float startTime;
    private float time;

    public GameObject hope;

    // Start is called before the first frame update
    void Start()
    {
        time = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Tutorial.isTutorialOver)
        {
            if (time <= 0)
            {
                Instantiate(hope, hopePos[Random.Range(0, hopePos.Length)].position, Quaternion.identity);
                time = startTime;
            }
            else
            {
                time -= Time.deltaTime;
            }
        }
    }
}
