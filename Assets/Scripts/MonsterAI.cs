using UnityEngine;
using System.Collections;

public class MonsterAI : MonoBehaviour
{
    public int moveSpeed = 10;  //per second
    public int computerDirection;
    Vector3 moveDirection = new Vector3(-1, 0, 0);
    bool movingLeft = false;
    private Rigidbody rb;

    void Update()
    {
        rb = GetComponent<Rigidbody>();
        // If thief is moving to the right and its position is -101
        // set movingLeft to true and change direction
        if (!movingLeft && transform.localPosition.x <= 10)
        {
            moveDirection = new Vector3(1, 0, 0);
            movingLeft = true;
        }

        // If thief is moving to the left and its position is 126
        // set movingLeft to false and change direction  
        if (movingLeft && transform.localPosition.x >= 20)
        {
            moveDirection = new Vector3(-1, 0, 0);
            movingLeft = false;
        }

        transform.Translate(moveSpeed * Time.deltaTime * moveDirection);

    }
}

