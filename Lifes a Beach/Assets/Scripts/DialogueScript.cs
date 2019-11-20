using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    public GameObject shopkeeperAllMenus;

    void Start()
    {
        
    }


    public void Intro()
    {
        
    }
    public void Flirt()
    {

    }
    public void Exit()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            shopkeeperAllMenus.SetActive(true);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            shopkeeperAllMenus.SetActive(false);

        }
    }
}
