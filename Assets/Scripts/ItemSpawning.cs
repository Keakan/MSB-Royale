using UnityEngine;
using System.Collections;

public class ItemSpawning : MonoBehaviour {
    private float timer;
    public bool isThereAnItem = false;
    public GameObject cowItem;
    public GameObject HoltsFaceItem;
    public GameObject spawnspot1;
    public GameObject spawnspot2;
    public GameObject spawnspot3;
    public GameObject ActSpawnspot;
    public GameObject SpawnedItem;
    // Use this for initialization
	void Start ()
    {
        timer = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        ++timer;
        if(!SpawnedItem)
        {
            isThereAnItem = false;
        }
        


        if (timer > Random.Range(100, 701))
        {
            if(isThereAnItem == false)
            {
                SpawnItem();
                timer = 0;
            }
            
        }
	}
    void SpawnLocation(ref GameObject spawnspot)
    {
        int SpawnLoc = Random.Range(0, 3);

        switch (SpawnLoc)
        {
            case 0:
                spawnspot = spawnspot1;
                break;

            case 1:
                spawnspot = spawnspot2;
                break;

            case 2:
                spawnspot = spawnspot3;
                break;

        }

    }

    void SpawnItem()
    {
        int itemSpawned = Random.Range(0, 2);
        SpawnLocation(ref ActSpawnspot);
        isThereAnItem = true;

        switch (itemSpawned)
            {
            case 0:
                Debug.Log("Item 0");

               
                SpawnedItem = (GameObject) Instantiate(cowItem, ActSpawnspot.transform.position, ActSpawnspot.transform.rotation);
                break;

            case 1:
                SpawnedItem = (GameObject) Instantiate(HoltsFaceItem, ActSpawnspot.transform.position, ActSpawnspot.transform.rotation);
                Debug.Log("Item 1");
                break;
            
            }
    }

}
