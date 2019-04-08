using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBouyancy : MonoBehaviour {

	GameObject cube;
    Rigidbody rbCube;
    float speed = 2.5f;
    float timer = 10f;
    CubeSpawn cSpawn;
    int chosen;
    BoxCollider bCollider;
    

    private void OnCollisionStay(Collision coll)
    {
        cube = coll.gameObject;
        rbCube = cube.GetComponent<Rigidbody>();
        bCollider = cube.GetComponent<BoxCollider>();
        bCollider.isTrigger = false;
        rbCube.useGravity = false;
        rbCube.AddForce(Vector3.up * speed, ForceMode.Acceleration);
        rbCube.constraints = RigidbodyConstraints.FreezePositionY;
        cSpawn = cube.GetComponent<CubeSpawn>();

        //if (timer <= 1)
        //{
        //    rbCube.constraints &= ~RigidbodyConstraints.FreezePositionY;
        //    rbCube.useGravity = true;
        //    Destroy(cube.gameObject, 3f);
        //    //chosen = Mathf.RoundToInt(UnityEngine.Random.Range(0, 4));
        //   // cSpawn.CubeChooser(chosen);


        //}
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        
        
    }


}
