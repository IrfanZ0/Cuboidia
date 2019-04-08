using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMap : MonoBehaviour {
    public GameObject star;
    GameObject[] stars;

	// Use this for initialization
	void Start () {
        stars = new GameObject[50];

        for (int i = 0; i < stars.Length; i++)
        {
            GameObject Star = Instantiate(star) as GameObject;
            stars[i] = Star;

            int j = Mathf.RoundToInt(UnityEngine.Random.Range(-50f, 50f));
            Vector3 starPos = stars[i].transform.position;

            if (i % 2 == 0)
            {
                starPos.x =  20 * j + transform.position.x;
                starPos.y = 5 * transform.position.y;
                starPos.z = Mathf.Abs(-8 * j + transform.position.z);
                stars[i].transform.position = starPos;
            }

            else if (i % 3 == 0)
            {
                starPos.x = 25 * j + transform.position.x;
                starPos.y = 3 * transform.position.y;
                starPos.z = Mathf.Abs(-7 * j + transform.position.z);
                stars[i].transform.position = starPos;
            }

            else
            {
                starPos.x = 30 * j + transform.position.x;
                starPos.y = 2 * transform.position.y;
                starPos.z = Mathf.Abs(-6 * j + transform.position.z);
                stars[i].transform.position = starPos;
            }
           
                      

        }

        
		
	}
	
	
}
