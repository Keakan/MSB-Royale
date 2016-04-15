using UnityEngine;
using System.Collections;

public class Push : MonoBehaviour {
    private Vector2 direction;
    public float force = 25f;

    void Start()
    {
        direction = new Vector2(force, force/2);
    }

    public void Flip()
    {
        direction.x *= -1;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
            other.GetComponent<Rigidbody2D>().AddForce(direction);
    }
}
