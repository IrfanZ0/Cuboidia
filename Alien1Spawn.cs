using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien1Spawn : MonoBehaviour {
    public GameObject alien1;

	// Use this for initialization
	void Start () {
        GameObject alien = Instantiate(alien1, transform.position, transform.rotation) as GameObject;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
