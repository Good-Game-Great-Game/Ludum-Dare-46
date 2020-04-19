using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioClip shoot, kill, hurt;
    public static AudioClip sShoot, sKill, sHurt;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        sShoot = shoot;
        sKill = kill;
        sHurt = hurt;

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "shoot":
                audioSrc.PlayOneShot(sShoot);
                break;
            case "kill":
                audioSrc.PlayOneShot(sKill);
                break;
            case "hurt":
                audioSrc.PlayOneShot(sHurt);
                break;
        }
    }
}
