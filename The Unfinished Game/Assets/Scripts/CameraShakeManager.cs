using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeManager : MonoBehaviour
{

    private Animator camAnim;
    public static Animator staticCamAnim;

    // Start is called before the first frame update
    void Start()
    {
        camAnim = GetComponent<Animator>();
        staticCamAnim = camAnim;
        staticCamAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public static void Shake()
    {
        staticCamAnim.SetTrigger("shake");
    }
}
