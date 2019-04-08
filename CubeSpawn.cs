using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawn : MonoBehaviour {

    public GameObject Cube;
    int chosen;
    int numCubes;
    float timer;
    GameObject[] cubes;
    public float timeDelay = 5f;
    int counter;
    float releaseTime;
    int columns = 100;
    int rows = 100;
    GameObject coloredCube;
    


    // Use this for initialization
    void Start () {
        
        numCubes = 30;
        timer = 5f;
        cubes = new GameObject[numCubes];
        counter = 0;

        for(int i = 0; i < cubes.Length; i++)
        {
            int color = Mathf.RoundToInt(UnityEngine.Random.Range(0, 3));
            GameObject cubeGO = CubeChooser(color);
            cubes[i] = cubeGO;
            
        }

        

    }
	
	
   

    public GameObject CubeChooser(int chosen)
    {
        GameObject chosenCube = Instantiate(Cube) as GameObject;
        chosenCube.transform.position = transform.position;
        MeshRenderer mRenderer = chosenCube.GetComponent<MeshRenderer>();
        BoxCollider bCollider = chosenCube.GetComponent<BoxCollider>();
        bCollider.isTrigger = false;

        switch (chosen)
        {
            case 0:
                {
                   
                    mRenderer.enabled = true;
                    mRenderer.material.color = Color.red;
                    chosenCube.tag = "Red Cube";
                                        
                   
                    break;
                }
                

            case 1:
                {
                    
                    mRenderer.enabled = true;
                    mRenderer.material.color = Color.blue;
                    chosenCube.tag = "Blue Cube";
                                       
                    
                    break;
                }

            case 2:
                {
                    
                    mRenderer.enabled = true;
                    mRenderer.material.color = Color.green;
                    chosenCube.tag = "Green Cube";
                   
                   
                   
                    break;
                }

            case 3:
                {
                    
                    mRenderer.enabled = true;
                    mRenderer.material.color = Color.yellow;
                    chosenCube.tag = "Yellow Cube";
                                        
                    
                    break;
                }
        }

        return chosenCube;

    }
}
