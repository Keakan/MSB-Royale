using UnityEngine;
using System.Collections;

public class doneJumping : MonoBehaviour {

    public Control notify;
    public Animator anim;
	
	void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Floor")
        {
            notify.jumping = false;
            anim.SetBool("Ground", true);
        }
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            notify.jumping = false;
            anim.SetBool("Ground", true);
        }
    }
}
