using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPlayer : MonoBehaviour {
    private int playerDiecount = 0;
    
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void CountPlayerDie()
    {
        playerDiecount++;
    }
    public int GetPlayercount()
    {
        return playerDiecount;
    }

}
