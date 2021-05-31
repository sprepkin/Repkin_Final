using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rB2D;
    BoxCollider2D c2D;

    //public GameObject spawnPoint;
    public float runSpeed;
    public float jumpForce;
    public float wallJumpForce;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public AudioSource[] audio1;
    public AudioClip jumpSound;
    public AudioClip wallJumpSound;
    public AudioClip loadSound;
    public AudioClip arrowCollect;


    //private Vector2 respawn;
    bool isGrounded;
    bool onWallLeft = false;
    bool onWallRight = false;
    bool canWallJump = true;

    // Start is called before the first frame update
    void Start()
    {
        //Vector2 respawn = new Vector2(spawnPoint.transform.position.x, spawnPoint.transform.position.y);
        rB2D = GetComponent<Rigidbody2D>();
        audio1 = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        int levelMask = LayerMask.GetMask("Level");

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded == true)
            {
                Jump();
            }
            else if ((onWallLeft == true || onWallRight == true) && canWallJump == true)
            {
                WallJump();
            }
        }

        if (Physics2D.BoxCast(transform.position, new Vector2(1f, .1f), 0f, Vector2.left, .01f, levelMask) && isGrounded == false)
        {
            onWallLeft = true;
        }
        else
        {
            onWallLeft = false;
        }

        if (Physics2D.BoxCast(transform.position, new Vector2(1f, .1f), 0f, Vector2.right, .01f, levelMask) && isGrounded == false)
        {
            onWallRight = true;
        }
        else
        {
            onWallRight = false;
        }

        if (Physics2D.BoxCast(transform.position, new Vector2(1f, .1f), 0f, Vector2.down, .01f, levelMask))
        {
            isGrounded = true;
            canWallJump = true;
        }
        else
        {
            isGrounded = false;
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

        if (Mathf.Abs(horizontalInput) > 0f && isGrounded == true)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }

    void Jump()
    {
        rB2D.velocity = new Vector2(rB2D.velocity.x, jumpForce);
        isGrounded = false;
        audio1[1].PlayOneShot(jumpSound, 1f);
    }

    void WallJump()
    {
        canWallJump = false;

        audio1[0].PlayOneShot(wallJumpSound, 1f);

        if (onWallLeft == true)
        {
            rB2D.velocity = new Vector2(wallJumpForce, jumpForce - 5);
        }
        
        if (onWallRight == true)
        {
            rB2D.velocity = new Vector2(wallJumpForce, jumpForce - 5);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Death"))
        {
            SceneManager.LoadScene("SampleScene");
            Target.triggered = false;
            Bow.arrowCount = 2;
            UI.arrowsDead = 0;
        }

        if (other.gameObject.CompareTag("Arrow"))
        {
            audio1[3].PlayOneShot(arrowCollect, .5f);
        }
    }
}