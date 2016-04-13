using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour {

    public GameObject RespawnPoint;
    public int PlayerHealth;
    public int PlayerNumber;
    private void Start()
    {
        
    }
    private void Kill()
    {
        string KillMessage = "Player " + PlayerNumber + " Died";
        string DeadMessage = "Player " + PlayerNumber + " Has No More Lives!";

        if (PlayerHealth > 1)
        {
            this.transform.position = RespawnPoint.transform.position;
            PlayerHealth -= 1;
            Debug.Log( KillMessage);
            
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
