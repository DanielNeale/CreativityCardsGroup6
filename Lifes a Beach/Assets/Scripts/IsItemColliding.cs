using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsItemColliding : MonoBehaviour
{
    void OnTriggerEnter(Collider hit)
    {
        if (!(hit.transform.CompareTag("Ground") || hit.transform.CompareTag("Dog") || hit.transform.CompareTag("Player") || hit.transform.CompareTag("MetalDetector")))
        {
            transform.parent.GetComponent<TreasureSpawner>().collidingItems += 1;
            Destroy(this.gameObject);
        }
    }
}
