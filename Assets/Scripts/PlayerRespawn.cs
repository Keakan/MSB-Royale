using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerRespawn : MonoBehaviour {

    public GameObject RespawnPoint;
    private Rigidbody2D rb;
    public int PlayerHealth;
    public int PlayerNumber;
    public Control cont;

    public GameObject DeathDisplay;
    public Text HealthDisplay;
    public Text KillsDisplay;
    private float _elapsedTime = 0;

    private void Start()
    {
        Time.timeScale = 1;

        DeathDisplay.SetActive(false);
       
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (!(_elapsedTime > 1))
            _elapsedTime += Time.deltaTime;
    }
    private void Kill()
    {
        string KillMessage = "Player " + PlayerNumber + " Died";
        string DeadMessage = "Player " + PlayerNumber + " Has No More Lives!";
        cont.cowsPickedUp = 0;
        cont.facespickedup = 0;
    
        if (PlayerHealth > 1)
        {
            this.transform.position = RespawnPoint.transform.position;
            rb.velocity *= 0;
            PlayerHealth -= 1;
            HealthDisplay.text = "Lives: " + PlayerHealth;
            Debug.Log(KillMessage);
        }
        else
        {
            Debug.Log(DeadMessage);
            DeathDisplay.SetActive(true);
            Destroy(this.gameObject);
            Destroy(HealthDisplay);
            Destroy(KillsDisplay);
           
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_elapsedTime >= .01)
        {
            _elapsedTime = 0; //reset it zero again
            if (other.tag == "KillZone")
            {
                Kill();
            }
            if (other.tag != "BulletP" + PlayerNumber)
            {
                Destroy(other.gameObject);
                Kill();
            }
        }
        else {
            _elapsedTime += Time.deltaTime;
        }
    }
}
