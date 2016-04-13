using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {
    public string playerNum = "";
    public float moveSpeed = 5.0f;
    public float jumpPower = 20f;
    public float fastFall = 10f;
    public bool jumping = false;
    bool facingRight = true;

    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("Ground", true);
        anim.SetFloat("Speed", 0f);
        anim.SetBool("Crouch", false);
    }

	void FixedUpdate()
    {
        if (Input.GetButton("A_" + playerNum))
        {
            if (!jumping)
            {
                jumping = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                anim.SetBool("Ground", false);
            }
        }
        if (Input.GetButton("B_" + playerNum))
        {
            //Debug.Log("B Pressed");
        }
        if (Input.GetButton("X_" + playerNum))
        {
            //Debug.Log("X Pressed");
        }
        if (Input.GetButton("Y_" + playerNum))
        {
            //Debug.Log("Y Pressed");
        }
        float x = Input.GetAxis("MovementX_" + playerNum),
              y = Input.GetAxis("MovementY_" + playerNum);
        if ( x > 0)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            if (!facingRight)
            {
                Flip();
            }
            anim.SetFloat("Speed", 1);
        }
        if (x < 0)
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            if (facingRight)
            {
                Flip();
            }
            anim.SetFloat("Speed", 1);
        }
        if(x == 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            anim.SetFloat("Speed", 0);
        }
        if (y > 0.5f /*&& jumping*/)
        {
            rb.velocity = new Vector2(rb.velocity.x, -fastFall);
            
        }
        if (y < 0)
        {
            //up
        }
    }

    void Flip()
    {
        // Switch the way the player is labelled as facing
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
