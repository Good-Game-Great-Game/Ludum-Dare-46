using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpHeight;
    private float moveInput;

    public static int bugsKilled;
    public static int glitchesKilled;

    public int bK;
    public int gK;

    private float bulletSpeed;
    private float startBulletSpeed;

    public static bool isPlayerGonnaDie = false;

    public GameObject burst;

    public float offset;

    private bool isFacingRight = false;

    public static bool shouldShake = false;

    private Rigidbody2D rb;

    public GameObject bullet;
    public GameObject gunTip;

    private bool isGrounded;
    public Transform groundCheckPos;
    public float checkRad;
    public LayerMask whatIsGround;

    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        bugsKilled = 0;
        glitchesKilled = 0;

        bulletSpeed = bullet.GetComponent<Bullet>().speed;

        startBulletSpeed = bulletSpeed;

        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        gK = glitchesKilled;
        bK = bugsKilled;

        if(HopeScript.hope <= 0)
        {
            isPlayerGonnaDie = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CameraShakeManager.Shake();
            SoundManager.PlaySound("shoot");
            FireBullet();
        }


        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            playerAnimator.SetTrigger("takeOff");
            rb.velocity = Vector2.up * jumpHeight;
        }

        if (isGrounded)
        {
            playerAnimator.SetBool("isJumping", false);
        }
        else if (!isGrounded)
        {
            playerAnimator.SetBool("isJumping", true);
        }

        if(moveInput == 0)
        {
            playerAnimator.SetBool("isRunning", false);
        }
        else
        {
            playerAnimator.SetBool("isRunning", true);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheckPos.position, checkRad, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(moveInput > 0 && !isFacingRight)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            isFacingRight = true;
        }else if(moveInput < 0 && isFacingRight)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            isFacingRight = false;
        }
    }

    void FireBullet()
    {
        shouldShake = true;
        

        if (!isFacingRight)
        {
            bullet.GetComponent<Bullet>().speed = -25;
            Instantiate(bullet, gunTip.transform.position, Quaternion.Euler(0, 0, 0));
            GameObject effect = Instantiate(burst, gunTip.transform.position, Quaternion.identity) as GameObject;
            Destroy(effect, 0.04f);
            
        }
        else if(isFacingRight)
        {
            bullet.GetComponent<Bullet>().speed = 25;
            Instantiate(bullet, gunTip.transform.position, Quaternion.Euler(0, 0, 180));
            GameObject effect = Instantiate(burst, gunTip.transform.position, Quaternion.identity) as GameObject;
            Destroy(effect, 0.04f);

        }
        //bulletSpeed = startBulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Heals"))
        {
            HopeScript.OnHopeIncrease();
            Destroy(collision.gameObject);
        }
    }
}
