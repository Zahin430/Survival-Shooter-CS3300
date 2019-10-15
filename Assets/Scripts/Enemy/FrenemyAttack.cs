using UnityEngine;
using System.Collections;

public class FrenemyAttack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + "  says to " + other.gameObject.name + ": Stop touching me!");
    }
}
