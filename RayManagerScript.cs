using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RayManagerScript : MonoBehaviour {

    public GameObject Ray;
    public GameObject cubitron;
    Animator cubitronAnim;
    Transform ray1Spawn;
    Transform ray2Spawn;
    GameObject[] rays;
    bool attack = false;
    GameObject[] targetRedColor;
    GameObject[] targetBlueColor;
    GameObject[] targetGreenColor;
    GameObject[] targetYellowColor;

    // Use this for initialization
    void Start()
    {
        
        rays = new GameObject[2];
        ray1Spawn = GameObject.Find("Ray1Spawn").transform;
        ray2Spawn = GameObject.Find("Ray2Spawn").transform;

        for (int i = 0; i < rays.Length; i++)
        {
            GameObject rayGO = Instantiate(Ray) as GameObject;
            rays[i] = rayGO;

        }

        rays[0].transform.position = ray1Spawn.position;
        rays[1].transform.position = ray2Spawn.position;

        targetRedColor = GameObject.FindGameObjectsWithTag("Red Cube");
        targetBlueColor = GameObject.FindGameObjectsWithTag("Blue Cube");
        targetGreenColor = GameObject.FindGameObjectsWithTag("Green Cube");
        targetYellowColor = GameObject.FindGameObjectsWithTag("Yellow Cube");

    }

    // Update is called once per frame
    void Update () {
        cubitronAnim = cubitron.GetComponent<Animator>();

        if (cubitronAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle_simple"))
        {
            if (!attack)
            {
                int target_color_num = Mathf.RoundToInt(UnityEngine.Random.Range(0, 4));

                switch (target_color_num)
                {
                    case 0:
                        {
                            AttackColorCube(rays[1], targetRedColor);
                            break;

                        }

                    case 1:
                        {
                            AttackColorCube(rays[1], targetBlueColor);
                            break;

                        }

                    case 2:
                        {
                            AttackColorCube(rays[1], targetGreenColor);
                            break;

                        }

                    case 3:
                        {
                            AttackColorCube(rays[1], targetYellowColor);
                            break;

                        }
                }

            }
        }
		
	}

    private void AttackColorCube(GameObject ray, GameObject[] targetColors)
    {
        NavMeshAgent navMeshRayAgent = ray.GetComponent<NavMeshAgent>();

        foreach (GameObject targetColor in targetColors)
        {
            if (targetColor != null)
            {
                float distanceToTarget = Vector3.Distance(ray.transform.position, targetColor.transform.position);

                if (distanceToTarget < 1f)
                {
                    navMeshRayAgent.SetDestination(targetColor.transform.position);
                    ray.transform.LookAt(targetColor.transform);
                }

                else if (distanceToTarget > 1f)
                {
                    NavMeshPath navPath = new NavMeshPath();

                    NavMesh.CalculatePath(ray.transform.position, targetColor.transform.position, NavMesh.AllAreas, navPath);

                    for (int i = 0; i < navPath.corners.Length - 1; i++)
                    {
                        navMeshRayAgent.SetDestination(navPath.corners[i]);
                        ray.transform.LookAt(navPath.corners[i]);
                    }


                }

                else
                {
                    navMeshRayAgent.SetDestination(ray2Spawn.position);
                    ray.transform.LookAt(ray2Spawn);
                }
            }
        }
        
    }
}
