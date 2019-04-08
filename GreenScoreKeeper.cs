using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenScoreKeeper : MonoBehaviour {

    GameObject scoreBoard;
    Text greenScoreText;
    ParticleSystem psGreenWarp;
    int scoreValue;
    

    // Use this for initialization
    void Start()
    {
        psGreenWarp = GetComponent<ParticleSystem>();
        scoreBoard = GameObject.FindGameObjectWithTag("Score Board");
        greenScoreText = scoreBoard.transform.GetChild(0).Find("Green Score").GetComponent<Text>();
        scoreValue = int.Parse(greenScoreText.text);
        
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Green Cube"))
        {
            Destroy(other.gameObject);
            scoreValue++;
            greenScoreText.text = scoreValue.ToString();


        }

        
    }
    
}
