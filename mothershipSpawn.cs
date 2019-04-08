using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mothershipSpawn : MonoBehaviour {
    public GameObject motherShip;

	// Use this for initialization
	void Start () {
        GameObject mShip = Instantiate(motherShip, transform.position, transform.rotation) as GameObject;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
