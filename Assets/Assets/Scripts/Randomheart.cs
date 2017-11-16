using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomheart : MonoBehaviour {

    [SerializeField] GameObject Heart;
    [SerializeField] Transform[] spawnPoints;
    float spawntime;
    float spawnPeriod = 3f;

    // Use this for initialization
    void Start ()
    {
        random();     
    }

	// Update is called once per frame
	void Update ()
    {
        if(GameObject.Find("heart(Clone)") == null)
        {
            spawntime += Time.deltaTime;
            if(spawntime >= spawnPeriod)
            {
                random();
            }
        }
            
	}

    void random()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(Heart, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        spawntime = 0;
    }
}
