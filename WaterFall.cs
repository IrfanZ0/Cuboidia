using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Water;

public class WaterFall : MonoBehaviour {
    public Material foam;
    ParticleSystem psWaterFall;
    List<ParticleCollisionEvent> collEvents;
    WaterBase wBaseScript;

    private void Start()
    {
        psWaterFall = GetComponent<ParticleSystem>();
        collEvents = new List<ParticleCollisionEvent>();
    }

    private void OnParticleCollision(GameObject other)
    {
        int numColl = psWaterFall.GetCollisionEvents(other, collEvents);

        for (int i = 0; i < numColl; i++)
        {
            if (other.CompareTag("Pool"))
            {
                wBaseScript = other.GetComponent<WaterBase>();
                wBaseScript.sharedMaterial = foam;
            }
        }
        
    }
}
