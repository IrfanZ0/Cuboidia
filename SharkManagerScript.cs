using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SharkManagerScript : MonoBehaviour {
    public GameObject Shark;
    GameObject[] sharks;
    Transform shark1Spawn;
    Transform shark2Spawn;
    

    // Use this for initialization
    void Start () {

        sharks = new GameObject[2];

        for (int i = 0; i < sharks.Length; i++)
        {
            GameObject sharkGO = Instantiate(Shark) as GameObject;
            sharks[i] = sharkGO;

        }

        shark1Spawn = GameObject.Find("Shark1Spawn").transform;
        shark2Spawn = GameObject.Find("Shark2Spawn").transform;

        sharks[0].transform.position = shark1Spawn.position;
        sharks[1].transform.position = shark2Spawn.position;

        

       

    }
	

	

    
}
