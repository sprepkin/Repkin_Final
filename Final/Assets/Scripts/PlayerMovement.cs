using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rB2D;

    //public GameObject spawnPoint;
    public float runSpeed;
    public float jumpForce;
    public SpriteRenderer spriteRenderer;
    //public Animator animator;

    //private Vector2 respawn;
    
    // Start is called before the first frame update
    void Start()
    {
        //Vector2 respawn = new Vector2(spawnPoint.transform.position.x, spawnPoint.transform.position.y);
        rB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            int levelMask = LayerMask.GetMask("Level");

            if (Physics2D.BoxCast(transform.position, new Vector2(1f, .1f), 0f, Vector2.down, .01f, levelMask))
            {
                Jump();
            }
        }
    }


    void FixedUpdate()
    {
        //Run left and right
        float horizontalInput = Input.GetAxis("Horizontal");

        rB2D.velocity = new Vector2(horizontalInput * runSpeed * Time.fixedDeltaTime, rB2D.velocity.y);

        if (rB2D.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        if (rB2D.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }

        /*if (Mathf.Abs(horizontalInput) > 0f)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }*/
    }

    void Jump()
    {
        rB2D.velocity = new Vector2(rB2D.velocity.x, jumpForce);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Death"))
        {
            /*transform.position = respawn;
            score = 0;
            SetCountText();*/

            SceneManager.LoadScene("SampleScene");
        }
    }
}
