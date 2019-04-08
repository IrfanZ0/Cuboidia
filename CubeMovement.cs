using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeMovement : MonoBehaviour {

    Vector2 touchPos;
    Vector2 touchPosDelta;
    Vector3 worldCoord;
    RaycastHit hit;
    Ray ray;
    Touch touch;
    GameObject targetCube;
    GameObject arrowCanvas;
    GameObject arrowCanvasPanel;
    Image arrowCanvasImage;
    Image backgroundPanelImage;
    Animator arrowAnim;
    Transform redGoalTransform;
    Transform blueGoalTransform;
    Transform yellowGoalTransform;
    Transform greenGoalTransform;
    Vector3 direction;
    float speed = 0.5f;

    [HideInInspector] public Vector3 redInitialPos;
    [HideInInspector] public Vector3 blueInitialPos;
    [HideInInspector] public Vector3 greenInitialPos;
    [HideInInspector] public Vector3 yellowInitialPos;


    // Use this for initialization
    void Start () {
        arrowCanvas = GameObject.Find("Canvas");
        arrowCanvasPanel = arrowCanvas.transform.Find("Panel").gameObject;
        arrowCanvasImage = arrowCanvasPanel.transform.Find("Arrow").GetComponent<Image>();
        backgroundPanelImage = arrowCanvasPanel.GetComponent<Image>();
        arrowAnim = arrowCanvasPanel.GetComponentInChildren<Animator>();
        redGoalTransform = GameObject.FindGameObjectWithTag("Red Goal").transform;
        blueGoalTransform = GameObject.FindGameObjectWithTag("Blue Goal").transform;
        greenGoalTransform = GameObject.FindGameObjectWithTag("Green Goal").transform;
        yellowGoalTransform = GameObject.FindGameObjectWithTag("Yellow Goal").transform;

    }

    // Update is called once per frame
    void Update()
    {

        foreach (Touch touch in Input.touches)
        {
            if (Input.touchCount > 0 && touch.phase == TouchPhase.Stationary)
            {
                touchPos = touch.position;



                ray = Camera.main.ScreenPointToRay(touchPos);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {

                    targetCube = hit.transform.gameObject;

                    if (targetCube.CompareTag("Red Cube"))
                    {
                        redInitialPos = targetCube.transform.position;
                        Debug.Log("Red Initial Screen Position: " + redInitialPos);

                    }

                    else if (targetCube.CompareTag("Blue Cube"))
                    {
                        blueInitialPos = targetCube.transform.position;
                        Debug.Log("Blue Initial Screen Position: " + blueInitialPos);

                    }


                    else if (targetCube.CompareTag("Yellow Cube"))
                    {
                        yellowInitialPos = targetCube.transform.position;
                        Debug.Log("Yellow Initial Screen Position: " + yellowInitialPos);

                    }

                    else if (targetCube.CompareTag("Green Cube"))
                    {
                        greenInitialPos = targetCube.transform.position;
                        Debug.Log("Green Initial Screen Position: " + greenInitialPos);

                    }

                    else
                        Debug.Log("No Cube touched");
                }
            }

            if (Input.touchCount > 0 && touch.phase == TouchPhase.Began)
            {

                touchPos = touch.position;

                Debug.Log("Screen Position: " + touchPos);

                ray = Camera.main.ScreenPointToRay(touchPos);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {

                    targetCube = hit.transform.gameObject;

                    if (targetCube.CompareTag("Red Cube"))
                    {
                        Debug.Log("Red Cube touched");
                       

                    }

                    else if (targetCube.CompareTag("Blue Cube"))
                    {
                        Debug.Log("Blue Cube touched");

                    }


                    else if (targetCube.CompareTag("Yellow Cube"))
                        Debug.Log("Yellow Cube touched");
                    else
                        Debug.Log("Green Cube touched");
                }
            }



            if (touch.phase == TouchPhase.Moved)
            {
                touchPosDelta = touch.deltaPosition;

                if (touchPosDelta.x > 0)
                {
                    targetCube.transform.position = Vector3.right * Time.deltaTime;

                }

                else if (touchPosDelta.x < 0)
                {
                    targetCube.transform.position = Vector3.left * Time.deltaTime;
                }

                else if (touchPosDelta.y > 0)
                {
                    targetCube.transform.position = Vector3.forward * Time.deltaTime;
                }

                else
                {
                    targetCube.transform.position = Vector3.back * Time.deltaTime;
                }

                if (targetCube.CompareTag("Red Cube"))
                {
                    backgroundPanelImage.color = Color.red;

                    arrowAnim.Play("arrowDirections");

                    
                    arrowCanvas.transform.position = Vector3.MoveTowards(arrowCanvas.transform.position, redGoalTransform.position, speed * Time.deltaTime);
                }

                else if (targetCube.CompareTag("Blue Cube"))
                {
                    backgroundPanelImage.color = Color.blue;
                    arrowAnim.Play("arrowDirections");
                    arrowCanvas.transform.position = Vector3.MoveTowards(arrowCanvas.transform.position, blueGoalTransform.position, speed * Time.deltaTime);

                }


                else if (targetCube.CompareTag("Yellow Cube"))
                {
                    backgroundPanelImage.color = Color.yellow;
                    arrowAnim.Play("arrowDirections");
                    arrowCanvas.transform.position = Vector3.MoveTowards(arrowCanvas.transform.position, yellowGoalTransform.position, speed * Time.deltaTime);
                }
                    
                else
                {
                    backgroundPanelImage.color = Color.green;
                    arrowAnim.Play("arrowDirections");
                    arrowCanvas.transform.position = Vector3.MoveTowards(arrowCanvas.transform.position, greenGoalTransform.position, speed * Time.deltaTime);
                }

            }





        }
    }
}
