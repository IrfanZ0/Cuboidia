using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CannonFire : MonoBehaviour {
    Transform cannon1;
    Transform cannon2;
    Transform cannon3;
    Transform cannon4;
    GameObject targetGroup;
    Transform pTarget1;
    Transform pTarget2;
    Transform pTarget3;
    Transform pTarget4;
    Transform pTarget5;
    Transform[] targets;
    GameObject[] projectiles;
    int projectileChoice;
    float distanceToTarget;
    Transform destination1;
    Transform destination2;
    NavMeshAgent shipAgent;
    public GameObject cube;
    public GameObject missile1;
    public GameObject bomb;
    CubeSpawn cSpawn;
    private float timer;
    GameObject CubeSpawn;
    GameObject missileSpawn;
    GameObject bombSpawn;
    float speed;
    GameObject cubeObject;
    Rigidbody rbCubeSpawn;

    // Use this for initialization
    void Start () {

        destination1 = GameObject.Find("Ship1LaunchPoint").transform;
        destination2 = GameObject.Find("Ship2LaunchPoint").transform;
        cSpawn = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CubeSpawn>();
        targetGroup = GameObject.Find("Projectile Targets");

        pTarget1 = targetGroup.transform.Find("Projectile_Target_1");
        pTarget2 = targetGroup.transform.Find("Projectile_Target_2");
        pTarget3 = targetGroup.transform.Find("Projectile_Target_3");
        pTarget4 = targetGroup.transform.Find("Projectile_Target_4");
        pTarget5 = targetGroup.transform.Find("Projectile_Target_5");

        targets = new Transform[5] { pTarget1, pTarget2, pTarget3, pTarget4, pTarget5 };
        speed = 0.5f;
        shipAgent = GetComponent<NavMeshAgent>();
        
        timer = 15f;
        projectiles = new GameObject[3] { cube, missile1, bomb };

        cubeObject = GameObject.Find("Cube(Clone)");
        rbCubeSpawn = cubeObject.GetComponent<Rigidbody>();

        foreach (Transform child in GetComponentInChildren<Transform>())
        {
            if (child.name == "Cannon1")
            {
                cannon1 = child;
            }

            if (child.name == "Cannon2")
            {
                cannon2 = child;
            }

            if (child.name == "Cannon3")
            {
                cannon3 = child;
            }

            if (child.name == "Cannon4")
            {
                cannon4 = child;
            }
        }
		
	}
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;
        
        if (timer < 1f)
        {
            distanceToTarget = DistanceToTarget(shipAgent, targets);

            projectileChoice = Mathf.RoundToInt(UnityEngine.Random.Range(0, 2f));



            switch (projectileChoice)
            {
                case 0:
                    {
                        int randomColor = Mathf.RoundToInt(UnityEngine.Random.Range(0, 4f));

                        if (distanceToTarget < 1.0f && shipAgent.destination == destination1.position)
                        {
                            
                            cSpawn.CubeChooser(randomColor);
                           // CubeSpawn.transform.position = Vector3.MoveTowards(cannon1.position, pTarget5.position, speed * Time.deltaTime);

                        }

                        if (distanceToTarget < 1.0f && shipAgent.destination == destination2.position)
                        {
                            CubeSpawn = Instantiate(cube, cannon1.position, cannon1.rotation) as GameObject;
                            cSpawn.CubeChooser(randomColor);
                           // CubeSpawn.transform.position = Vector3.MoveTowards(cannon1.position, pTarget5.position, speed * Time.deltaTime);

                        }


                        break;
                    }

                case 1:
                    {
                        if (distanceToTarget < 1.0f && shipAgent.destination == destination1.position)
                        {
                            missileSpawn = Instantiate(missile1, cannon2.position, cannon2.rotation) as GameObject;
                            

                        }

                        if (distanceToTarget < 1.0f && shipAgent.destination == destination2.position)
                        {
                            missileSpawn = Instantiate(missile1, cannon2.position, cannon2.rotation) as GameObject;
                            

                        }
                        break;
                    }

                case 2:
                    {
                        if (distanceToTarget < 1.0f && shipAgent.destination == destination1.position)
                        {
                            bombSpawn = Instantiate(bomb, cannon2.position, cannon2.rotation) as GameObject;
                            

                        }

                        if (distanceToTarget < 1.0f && shipAgent.destination == destination2.position)
                        {
                            bombSpawn = Instantiate(bomb, cannon2.position, cannon2.rotation) as GameObject;
                            

                        }
                        break;
                    }

                
            }

            

        }

		
	}

    private void FixedUpdate()
    {
        int targetChoice = Mathf.RoundToInt(UnityEngine.Random.Range(0, 4f));

        //Colored cube trajectory
        

        
        float disX = rbCubeSpawn.gameObject.transform.position.x - targets[targetChoice].position.x;
        float disY = rbCubeSpawn.gameObject.transform.position.y - targets[targetChoice].position.y;

        float velX =  disX / Time.deltaTime;
        float VelY = disY / Time.deltaTime + 0.5f * Mathf.Abs(Physics.gravity.y) * Time.deltaTime;

        Vector3 forceCube = new Vector3(velX, VelY, 0f);

        rbCubeSpawn.AddForce(forceCube);

        //Missile trajectory

        Rigidbody rbMissileSpawn = missileSpawn.GetComponent<Rigidbody>();

        float disMissileX = rbMissileSpawn.gameObject.transform.position.x - targets[targetChoice].position.x;
        float disMissileY = rbMissileSpawn.gameObject.transform.position.y - targets[targetChoice].position.y;

        float velMissileX = disMissileX / Time.deltaTime;
        float VelMissileY = disMissileY / Time.deltaTime + 0.5f * Mathf.Abs(Physics.gravity.y) * Time.deltaTime;

        Vector3 forceMissile = new Vector3(velMissileX, VelMissileY, 0f);

        rbMissileSpawn.AddForce(forceMissile);

        Rigidbody rbBombSpawn = bombSpawn.GetComponent<Rigidbody>();

        float disBombX = rbBombSpawn.gameObject.transform.position.x - targets[targetChoice].position.x;
        float disBombY = rbBombSpawn.gameObject.transform.position.y - targets[targetChoice].position.y;

        float velBombX = disBombX / Time.deltaTime;
        float VelBombY = disBombY / Time.deltaTime + 0.5f * Mathf.Abs(Physics.gravity.y) * Time.deltaTime;

        Vector3 forceBomb = new Vector3(velBombX, VelBombY, 0f);

        rbMissileSpawn.AddForce(forceBomb);
    }

    private float DistanceToTarget(NavMeshAgent shipAgent, Transform[] targetGroup)
    {
        float distance = 0f;

        foreach (Transform target in targetGroup)
        {
            distance = Vector3.Distance(shipAgent.transform.position, target.position);
        }

        return distance;
    }
}
