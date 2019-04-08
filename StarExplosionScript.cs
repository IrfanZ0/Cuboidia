using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarExplosionScript : MonoBehaviour {
    GameObject[] stars;
    Animator starAnim;
    float timer = 10f;
    CubeSpawn cSpawn;
    GameObject[] cubes;
    GameObject land;
    float speed = 2f;
    int targetStar;
    int counter = 0;
    GameObject cubeGO;
    Camera actionCamera;
    Camera mainCamera;

    // Use this for initialization
    void Start () {
        stars = GameObject.FindGameObjectsWithTag("Stars");
        cubes = new GameObject[10];
        land = GameObject.Find("Terrain");
        actionCamera = GameObject.Find("Action Camera").GetComponent<Camera>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mainCamera.enabled = true;
        actionCamera.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

       
        timer -= Time.deltaTime;

        if (timer < 1f)
        {
            targetStar = Mathf.RoundToInt(UnityEngine.Random.Range(0, stars.Length));
            stars[targetStar].SetActive(true);
            timer = 20f;
            mainCamera.enabled = false;
            actionCamera.enabled = true;
        }

        if (stars[targetStar] != null)
        {


            starAnim = stars[targetStar].GetComponent<Animator>();

            starAnim.SetTrigger("explode");


            Debug.Log("Star # " + targetStar + " is exploding!!!");

            stars[targetStar].SetActive(false);

            foreach (GameObject star in stars)
            { 
                if (counter < 20)
                {
                    cSpawn = star.GetComponent<CubeSpawn>();

                    int color = Mathf.RoundToInt(UnityEngine.Random.Range(0, 3));
                    cubeGO = cSpawn.CubeChooser(color);
                    counter += 1;

                }
                
                
                
                
            }

           

        }
		
	}

    private void FixedUpdate()
    {
            Rigidbody rbCubes = cubeGO.GetComponent<Rigidbody>();
            Transform targetSpot = land.transform.Find("Target");

            rbCubes.AddForce((targetSpot.position - cubeGO.transform.position) * speed);
    
        
    }
}
