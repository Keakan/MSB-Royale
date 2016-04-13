using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour {

    public GameObject RespawnPoint;
    public int PlayerHealth;
    public int PlayerNumber;

    private void Kill()
    {
        string KillMessage = "Player " + PlayerNumber + " Died";
        string DeadMessage = "Player " + PlayerNumber + " Has No More Lives!";
        if (PlayerHealth > 1)
        {
            --PlayerHealth;
            Debug.Log( KillMessage);
            this.transform.position = RespawnPoint.transform.position;
        } 
        else
        {
            Debug.Log(DeadMessage);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "KillZone")
        {
            Kill();
        }
        
    }
}
