using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlitcherScript : MonoBehaviour
{

    public float startWaitTime;
    public float waitTime;

    public Difficulty diff;

    public float speed;
    private bool isFinalPosSet = false;

    public static bool shouldShake = false;

    public static bool isTouchingCore = false;

    private Rigidbody2D rb;

    public int repetation;

    private Animator anim;

    public GameObject destroyG;

    // Start is called before the first frame update
    void Start()
    {
        if(diff.difficulty < 2)
        {
            repetation = 3;
            speed = 2f;
        }else if(diff.difficulty == 2)
        {
            repetation = 2;
            speed = 4f;
        }

        waitTime = startWaitTime;
        isFinalPosSet = false;

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(repetation >= 0)
        {
            if(waitTime <= 0)
            {
                anim.SetTrigger("IsGlitcherGone");

                transform.position = GlitcherSpawner.staticSpawnPos[Random.Range(0, GlitcherSpawner.staticFinalPos.Length)].position;

                anim.SetTrigger("isSpawning");

                waitTime = startWaitTime;

                repetation--;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else
        {
            if (!isFinalPosSet)
            {
                anim.SetTrigger("IsGlitcherGone");
                transform.position = GlitcherSpawner.staticFinalPos[Random.Range(0, GlitcherSpawner.staticFinalPos.Length)].position;
                anim.SetTrigger("isSpawning");

                isFinalPosSet = true;
            }

            Vector2 differenceX = Vector3.zero - transform.position;

            if(differenceX.x > 0)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }else if(differenceX.x < 0)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        shouldShake = true;
        

        if (collision.CompareTag("Bullet"))
        {
            DestroyEnemy();
            SoundManager.PlaySound("kill");
            PlayerController.glitchesKilled++;
        }
        if (collision.CompareTag("Core"))
        {
            Destroy(gameObject);
            isTouchingCore = true;
        }
        if (collision.CompareTag("Player"))
        {
            DestroyEnemy();
            SoundManager.PlaySound("hurt");
            HopeScript.OnHopeDecrease();
            PlayerController.glitchesKilled++;
        }
    }

    void DestroyEnemy()
    {
        CameraShakeManager.Shake();

        Destroy(gameObject);
        GameObject effect = Instantiate(destroyG, transform.position, Quaternion.identity) as GameObject;
        Destroy(effect, 0.5f);
    }
}
