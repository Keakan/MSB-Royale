using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {
    public string playerNum = "";
    public float moveSpeed = 20f;
    public float jumpPower = 35f;
    public float fastFall = 30f;
    public bool jumping = false;
    bool facingRight = true;
    public GameObject hitBox;
    private Push direction;
    private int powerUpTimer = 0;
    public double cowsPickedUp = 0;
    public double facespickedup = 0;
    private const double MOVESPEEDMOD = .1;
    private const double JUMPPOWERMOD = .1;

    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        direction = hitBox.GetComponent<Push>();

        anim.SetBool("Ground", true);
        anim.SetFloat("Speed", 0f);
        anim.SetBool("Crouch", false);

        //ignore collision between players
        Physics2D.IgnoreLayerCollision(8, 8);
    }

	void FixedUpdate()
    {
        moveSpeed = 20 + (float)(20 * MOVESPEEDMOD * cowsPickedUp);
        jumpPower = 35 + (float)(35 * JUMPPOWERMOD * facespickedup);
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
        //push attack, removed because it sucks
        /*if (Input.GetButton("X_" + playerNum))
        {
            hitBox.SetActive(true);
        }
        else if (hitBox.activeSelf)
        {
            hitBox.SetActive(false);
        }*/
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
            //rb.velocity = new Vector2(rb.velocity.x, -fastFall);
            rb.velocity += new Vector2(0, -2);
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
        direction.Flip();
        // Multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

   

    void OnTriggerEnter2D(Collider2D other)
    {
        string playerpickupmessage;
        if (other.gameObject.tag == "cowItem" || other.gameObject.tag == "holt'sface")
        {
            Debug.Log("Picking up item");
            
            switch (other.gameObject.tag)
            {

                case "holt'sface":
                   playerpickupmessage = playerNum + " picked up a Holt's face!";
                    ++facespickedup;
                    Debug.Log(playerpickupmessage);
                    Destroy(other.gameObject);
                    break;

                    
                case "cowItem":
                    playerpickupmessage = playerNum + " picked up a cow item!";
                    ++cowsPickedUp;
                    Debug.Log(playerpickupmessage);
                    Destroy(other.gameObject);
                    break;

                    default:
                    Debug.Log("Help");
                    break;


            }
        }

    }
}
