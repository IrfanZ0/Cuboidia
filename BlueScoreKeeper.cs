using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueScoreKeeper : MonoBehaviour {
    GameObject scoreBoard;
    Text blueScoreText;
    ParticleSystem psBlueWarp;
    int scoreValue;
    

	// Use this for initialization
	void Start () {
        psBlueWarp = GetComponent<ParticleSystem>();
        scoreBoard = GameObject.FindGameObjectWithTag("Score Board");
        blueScoreText = scoreBoard.transform.GetChild(0).Find("Blue Score").GetComponent<Text>();
        scoreValue = int.Parse(blueScoreText.text);
        
	}

    private void OnParticleCollision(GameObject other)
    {

        if (other.CompareTag("Blue Cube"))
        {
            Destroy(other.gameObject);
            scoreValue++;
            blueScoreText.text = scoreValue.ToString();


        }

        

    }
}
