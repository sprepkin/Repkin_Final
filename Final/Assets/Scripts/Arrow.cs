using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    //public int despawnTime;

    Rigidbody2D rb;
    bool hit;
    public static int collected = 0;
    //float despawnTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        /*if (despawnTimer > 0f)
        {
            despawnTimer -= Time.deltaTime;
        }*/

        if (hit == false)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        /*if (hit == true && despawnTimer <= 0)
        {
            Destroy(gameObject);
        }*/
        collected = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hit = true;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        //despawnTimer = despawnTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            collected = 1;
            Destroy(gameObject);
        }
    }
}
