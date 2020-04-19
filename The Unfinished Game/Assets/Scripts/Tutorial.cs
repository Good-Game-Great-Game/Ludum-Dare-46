using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{

    public GameObject[] popups;
    public GameObject[] popupsMedium;
    private int popupIndex;
    private int popupIndesMed;

    private bool isActive = true;
    public static bool isTutorialOver = false;

    public GameObject Tut1;
    public GameObject Tut2;

    public Difficulty diff;

    public float startShowTime;
    private float showTime;

    public GameObject bSpawner;
    public GameObject gSpawner;

    // Start is called before the first frame update
    void Start()
    {
        gSpawner.SetActive(false);
        bSpawner.SetActive(false);

        showTime = startShowTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (diff.difficulty == 0)
        {
            isTutorialOver = false;
            Tut1.SetActive(true);
            Tut2.SetActive(false);

            for (int i = 0; i < popups.Length; i++)
            {
                if (i == popupIndex)
                {
                    popups[i].SetActive(true);
                    if (i == 2)
                    {
                        isTutorialOver = true;
                        if (showTime <= 0)
                        {
                            popups[i].SetActive(false);
                            
                        }
                        else
                        {
                            showTime -= Time.deltaTime;
                        }
                    }
                }
                else
                {
                    popups[i].SetActive(false);
                }
            }

            if (popupIndex == 0)
            {

                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    popupIndex++;
                }
            }
            else if (popupIndex == 1)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    popupIndex++;
                }
            }
            else if (popupIndex == 2)
            {
                gSpawner.SetActive(true);
                bSpawner.SetActive(true);
            }
        }

        if (diff.difficulty == 1)
        {
            isTutorialOver = false;
            if (isActive)
            {
                Tut2.SetActive(true);
                Tut1.SetActive(false);
            }
            for (int i = 0; i < popupsMedium.Length; i++)
            {
                if (i == popupIndesMed)
                {
                    popupsMedium[i].SetActive(true);
                    if(i == 2)
                    {
                        isTutorialOver = true;
                        if (Input.GetMouseButton(0))
                        {
                            isActive = false;
                            popupsMedium[i].SetActive(false);
                            Tut2.SetActive(false);
                        }
                        
                    }
                }
                else
                {
                    popupsMedium[i].SetActive(false);
                }
            }

            if (popupIndesMed == 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    popupIndesMed++;
                }
            }else if(popupIndesMed == 1)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    popupIndesMed++;
                }
            }else if(popupIndesMed == 2)
            {
                gSpawner.SetActive(true);
                bSpawner.SetActive(true);
            }
        }

        if(diff.difficulty == 2)
        {
            isTutorialOver = true;
            Tut2.SetActive(false);
            Tut1.SetActive(false);

            gSpawner.SetActive(true);
            bSpawner.SetActive(true);
        }
    }
}
