using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien2Spawn : MonoBehaviour {

    public GameObject alien2;

	// Use this for initialization
	void Start () {
        GameObject alien = Instantiate(alien2, transform.position, transform.rotation) as GameObject;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
