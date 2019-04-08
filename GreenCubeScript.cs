using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCubeScript : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shark"))
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
