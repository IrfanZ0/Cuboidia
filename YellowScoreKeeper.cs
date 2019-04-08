using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YellowScoreKeeper : MonoBehaviour {

    GameObject scoreBoard;
    Text yellowScoreText;
    ParticleSystem psYellowWarp;
    int scoreValue;

    // Use this for initialization
    void Start()
    {
        psYellowWarp = GetComponent<ParticleSystem>();
        scoreBoard = GameObject.FindGameObjectWithTag("Score Board");
        yellowScoreText = scoreBoard.transform.GetChild(0).Find("Yellow Score").GetComponent<Text>();
        scoreValue = int.Parse(yellowScoreText.text);
        
    }

    private void OnParticleCollision(GameObject other)
    {

        if (other.CompareTag("Yellow Cube"))
        {
            Destroy(other.gameObject);
            scoreValue++;
            yellowScoreText.text = scoreValue.ToString();


        }

       
    }
}
