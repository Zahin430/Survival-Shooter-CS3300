using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParentHellephant : MonoBehaviour
{
    // public GameObject pickupEffect;
    void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Player"))
        {
            // Instantiate(pickupEffect, transform.position, transform.rotation);
            other.SendMessage("AddHealth", 1);
            Destroy(transform.parent.gameObject);
            // Debug.Log(other);
        }    
    }
}
