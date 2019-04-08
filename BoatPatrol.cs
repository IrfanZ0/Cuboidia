using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoatPatrol : MonoBehaviour {

    
    Transform ship1Point;
    Transform ship2Point;
    Transform[] shipWayPoints;
    NavMeshAgent shipAgent;
    private int destPoint;

	// Use this for initialization
	void Start () {
        ship1Point = GameObject.Find("Ship1LaunchPoint").transform;
        ship2Point = GameObject.Find("Ship2LaunchPoint").transform;

        shipWayPoints = new Transform[2] { ship1Point, ship2Point };
        shipAgent = GetComponent<NavMeshAgent>();
        destPoint = 0;
	}
	
	// Update is called once per frame
	void Update () {

        shipAgent.SetDestination(shipWayPoints[1].position);

        if (shipAgent.remainingDistance <= shipAgent.stoppingDistance && !shipAgent.pathPending)
        {
            shipAgent.SetDestination(shipWayPoints[0].position);
            //destPoint = (destPoint + 1) % shipWayPoints.Length;
        }

		
	}
}
