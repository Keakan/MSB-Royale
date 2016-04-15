using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerRespawn : MonoBehaviour {

    public GameObject RespawnPoint;
    public int PlayerHealth;
    public int PlayerNumber;

    public GameObject DeathDisplay;
    public Text HealthDisplay;
    public Text KillsDisplay;
    private float _elapsedTime = 0;

    private void Start()
    {
        Time.timeScale = 1;
        DeathDisplay.SetActive(false);
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

        if (PlayerHealth > 1)
        {
            this.transform.position = RespawnPoint.transform.position;
            PlayerHealth -= 1;
            HealthDisplay.text = "Lives: " + PlayerHealth;
            Debug.Log(KillMessage);
        }
        else
        {
            Debug.Log(DeadMessage);
            Destroy(this.gameObject);
            DeathDisplay.SetActive(true);
            Destroy(HealthDisplay);
            Destroy(KillsDisplay);
           
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_elapsedTime >= 1)
        {
            _elapsedTime = 0; //reset it zero again
            if (other.tag == "KillZone")
            {
                Kill();
            }
        }
        else {
            _elapsedTime += Time.deltaTime;
        }
    }
}
