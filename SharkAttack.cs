using UnityEngine;
using UnityEngine.AI;

public class SharkAttack : MonoBehaviour {

    GameObject cubitron;
    Animator cubitronAnim;
    bool attack = false;
    GameObject[] sharks;
    GameObject[] targetRedColor;
    GameObject[] targetBlueColor;
    GameObject[] targetGreenColor;
    GameObject[] targetYellowColor;
    GameObject[] targetColors;
    int target_color_num;
    NavMeshAgent navMeshShark1Agent;
    private int destPoint;

    private void Start()
    {
        cubitron = GameObject.FindGameObjectWithTag("Cubitron");
        sharks = GameObject.FindGameObjectsWithTag("Shark");
        target_color_num = Mathf.RoundToInt(UnityEngine.Random.Range(0, 4));

        Debug.Log("Target Color #: " + target_color_num);

        navMeshShark1Agent = sharks[0].GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        cubitronAnim = cubitron.GetComponent<Animator>();



        if (cubitronAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            if (!attack)
            {

                destPoint = 0;
                



                switch (target_color_num)
                {
                    case 0:
                        {

                            if (!navMeshShark1Agent.pathPending && navMeshShark1Agent.remainingDistance < 0.5f)
                            {
                                targetRedColor = GameObject.FindGameObjectsWithTag("Red Cube");
                               
                                navMeshShark1Agent.SetDestination(targetRedColor[destPoint].transform.position);
                                //sharks[0].transform.LookAt(targetRedColor[destPoint].transform);
                                destPoint = (destPoint + 1) % targetRedColor.Length;

                            }





                            break;

                        }

                    case 1:
                        {

                            if (!navMeshShark1Agent.pathPending && navMeshShark1Agent.remainingDistance < 0.5f)
                            {
                                targetBlueColor = GameObject.FindGameObjectsWithTag("Blue Cube");
                               
                                navMeshShark1Agent.SetDestination(targetBlueColor[destPoint].transform.position);
                                //sharks[0].transform.LookAt(targetBlueColor[destPoint].transform);
                                destPoint = (destPoint + 1) % targetBlueColor.Length;
                            }




                            break;

                        }

                    case 2:
                        {

                            if (!navMeshShark1Agent.pathPending && navMeshShark1Agent.remainingDistance < 0.5f)
                            {
                                targetGreenColor = GameObject.FindGameObjectsWithTag("Green Cube");
                               
                                navMeshShark1Agent.SetDestination(targetGreenColor[destPoint].transform.position);
                                //sharks[0].transform.LookAt(targetColors[destPoint].transform);
                                destPoint = (destPoint + 1) % targetGreenColor.Length;
                            }





                            break;

                        }

                    case 3:
                        {

                            if (!navMeshShark1Agent.pathPending && navMeshShark1Agent.remainingDistance < 0.5f)
                            {
                                targetYellowColor = GameObject.FindGameObjectsWithTag("Yellow Cube");
                                
                                navMeshShark1Agent.SetDestination(targetYellowColor[destPoint].transform.position);
                                //sharks[0].transform.LookAt(targetYellowColor[destPoint].transform);
                                destPoint = (destPoint + 1) % targetYellowColor.Length;
                            }





                            break;

                        }
                }


            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Red Cube") || other.CompareTag("Blue Cube") || other.CompareTag("Green Cube") || other.CompareTag("Yellow Cube"))
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
