using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour {

    public float timer;
    public GameObject Box;
	void Start () {
		
	}
	
	void Update () {
        if (timer<=0)
            Spawner();
         timer -= Time.deltaTime;
	}
    void Spawner()
    {
        Instantiate(Box, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
        timer = 2f;
    }
}
