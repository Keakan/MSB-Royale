using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {
    public string playerNum = "";
    public float moveSpeed = 5.0f;

    private bool jumping = false;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

	void FixedUpdate()
    {
        if (Input.GetButton("A_" + playerNum))
        {
            if (!jumping)
            {
                jumping = true;
                rb.velocity = new Vector2(rb.velocity.x, 10);
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
        }
        if (x < 0)
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        if(x == 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (y > 0)
        {
            //Debug.Log("Down");
        }
        if (y < 0)
        {
            //Debug.Log("Up");
        }
    }

    void OnCollisionEnter2D(Collider2D other)
    {

    }
}
