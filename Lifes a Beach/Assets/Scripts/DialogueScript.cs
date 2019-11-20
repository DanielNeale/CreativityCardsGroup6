using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    public GameObject shopkeeperBio;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            shopkeeperBio.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            shopkeeperBio.SetActive(false);
        }
    }
}
