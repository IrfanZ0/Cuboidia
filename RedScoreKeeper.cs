using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedScoreKeeper : MonoBehaviour {

    GameObject scoreBoard;
    Text redScoreText;
    ParticleSystem psRedWarp;
    int scoreValue;
   

    // Use this for initialization
    void Start()
    {
        psRedWarp = GetComponent<ParticleSystem>();
        scoreBoard = GameObject.FindGameObjectWithTag("Score Board");
        redScoreText = scoreBoard.transform.GetChild(0).Find("Red Score").GetComponent<Text>();
        scoreValue = int.Parse(redScoreText.text);
        
    }

    private void OnParticleCollision(GameObject other)
    {

        if (other.CompareTag("Red Cube"))
        {
            Destroy(other.gameObject);
            scoreValue++;
            redScoreText.text = scoreValue.ToString();


        }

        
    }
}
