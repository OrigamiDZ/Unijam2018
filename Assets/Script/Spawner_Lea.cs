using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Lea : MonoBehaviour {
    public GameObject spawnPoint;
    public GameObject spawnedObject;
    private int lapseTime;
    private int timer;
	
    
    // Use this for initialization
	void Start () {
        timer = 0;
        lapseTime = 0;
	}

    // Update is called once per frame
    void Update()
    {
        timer++;
        if(timer >= lapseTime)
        {
            Spawn();
            timer = 0;
            lapseTime = Random.Range(200, 1000);
        }
    }

    void Spawn()
    {
        int numberSpawn = Random.Range(1,10);
        Vector3 offsetGlobal = new Vector3(Random.Range(-400, 400), Random.Range(-400, 400), 0);
        for (int i = 0; i<numberSpawn; i++)
        {
            Vector3 offset = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), 0);
            Instantiate(spawnedObject, spawnPoint.transform.position + offsetGlobal + offset, Quaternion.identity);
        }
    }
}
