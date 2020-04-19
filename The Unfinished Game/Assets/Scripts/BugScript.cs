using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BugScript : MonoBehaviour
{

    public float speed;
    public int health;

    public Difficulty diff;

    public static bool isTouchingCore = false;

    private Rigidbody2D rb;

    public GameObject destroyG;

    public static bool shouldShake = false;

    public bool isWallBlockingWay = false;
    public Transform wallCheckPos;
    public float circleRadius;
    public LayerMask whatIsBlocking;

    public bool isOtherBlockingWay = false;
    public LayerMask whatIsOther;

    // Start is called before the first frame update
    void Start()
    {
        if(diff.difficulty == 0)
        {
            speed = 4;
            health = 1;
        }else if(diff.difficulty == 1)
        {
            speed = 5f;
            health = 1;
        }else if(diff.difficulty == 2)
        {
            speed = 6f;
            health = 1;
        }

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isWallBlockingWay = Physics2D.OverlapCircle(wallCheckPos.position, circleRadius, whatIsBlocking);
        isOtherBlockingWay = Physics2D.OverlapCircle(wallCheckPos.position, circleRadius, whatIsOther);

        if (isWallBlockingWay)
        {
            Flip();
        }
        if (isOtherBlockingWay)
        {
            rb.velocity = Vector2.up * 10;
        }

        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }

    void Flip()
    {
        speed *= -1;

        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        shouldShake = true;
        

        if (collision.CompareTag("Bullet"))
        {
            if(health <= 1)
            {
                DestroyEnemy();
                SoundManager.PlaySound("kill");
                PlayerController.bugsKilled++;
            }
            else
            {
                health--;
            }
        }
        if (collision.CompareTag("Core"))
        {
            isTouchingCore = true;
            Destroy(gameObject);
        }
    }

    void DestroyEnemy()
    {
        CameraShakeManager.Shake();

        Destroy(gameObject);
        GameObject effectE = Instantiate(destroyG, transform.position, Quaternion.identity) as GameObject;
        Destroy(effectE, 0.5f);
    }
}
