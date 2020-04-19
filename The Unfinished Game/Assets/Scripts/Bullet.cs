using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    public float lifeTime;

    public GameObject effect;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Invoke("DestroyBullet", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
        GameObject dest = Instantiate(effect, transform.position, Quaternion.identity) as GameObject;
        Destroy(dest, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            DestroyBullet();
    }
}
