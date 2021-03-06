using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody2D rb;
    bool hit;
    public static int collected = 0;
    public float FallTimer = 3f;
    public AudioSource[] arrowAudio;
    public AudioClip wallHitSound;
    public AudioClip targetHitSound;
    public bool fell = false;
    public bool grounded = false;

    public static bool destroyed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        arrowAudio = GetComponents<AudioSource>();
    }

    void Update()
    {
        if (FallTimer > 0f)
        {
            FallTimer -= Time.deltaTime;
        }

        if (hit == false && grounded == false)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        if (hit == true && FallTimer <= 0)
        {
            rb.isKinematic = false;
            hit = false;
            fell = true;
        }

        collected = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hit = true;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;

        if(hit == true && collision.gameObject.CompareTag("Grid") && fell == false)
        {
            arrowAudio[0].PlayOneShot(wallHitSound, .75f);
        }

        if (hit == true && collision.gameObject.CompareTag("Target") && fell == false)
        {
            arrowAudio[1].PlayOneShot(targetHitSound, .75f);
        }

        if (fell == true && (collision.gameObject.CompareTag("Grid") || collision.gameObject.CompareTag("Target")))
        {
            rb.isKinematic = false;
            grounded = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            collected = 1;
            Destroy(gameObject);
            Bow.arrowCount += 1;
        }

        if (other.gameObject.CompareTag("Death"))
        {
            destroyed = true;
            UI.arrowsDead += 1;
            Destroy(gameObject);
        }
    }
}
