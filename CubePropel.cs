using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePropel : MonoBehaviour {

    float speed = 1.5f;
    GameObject cube;
    Transform waterFallTransform;

    private void Start()
    {
        foreach (Transform child in gameObject.GetComponentInChildren<Transform>())
        {
            if (child.gameObject.name == "WaterFall")
            {
                waterFallTransform = child;
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blue Cube") || other.gameObject.CompareTag("Yellow Cube") || other.gameObject.CompareTag("Red Cube") || other.gameObject.CompareTag("Green Cube"))
        {
            cube = other.gameObject;
            Rigidbody rbCube = cube.gameObject.GetComponent<Rigidbody>();
            rbCube.useGravity = false;
            rbCube.constraints = RigidbodyConstraints.FreezePositionY;
            rbCube.constraints = RigidbodyConstraints.FreezeRotation;


        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Blue Cube") || other.gameObject.CompareTag("Yellow Cube") || other.gameObject.CompareTag("Red Cube") || other.gameObject.CompareTag("Green Cube"))
        {
            cube = other.gameObject;
            Rigidbody rbCube = cube.gameObject.GetComponent<Rigidbody>();
            rbCube.useGravity = false;
            rbCube.constraints = RigidbodyConstraints.FreezePositionY;
            rbCube.constraints = RigidbodyConstraints.FreezeRotation;
            Vector3 direction = waterFallTransform.position - transform.position;
            rbCube.MovePosition(cube.gameObject.transform.position + direction * speed * Time.deltaTime);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Blue Cube") || other.gameObject.CompareTag("Yellow Cube") || other.gameObject.CompareTag("Red Cube") || other.gameObject.CompareTag("Green Cube"))
        {
            cube = other.gameObject;
            Rigidbody rbCube = cube.gameObject.GetComponent<Rigidbody>();
            rbCube.useGravity = true;
            rbCube.constraints &= ~RigidbodyConstraints.FreezePositionY;
            rbCube.constraints &= ~RigidbodyConstraints.FreezeRotation;


        }
    }


}
