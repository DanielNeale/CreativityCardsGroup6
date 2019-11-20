using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeScript : MonoBehaviour
{
    
    public GameObject vCam;
    public GameObject vCam2;
    public GameObject player;
    public GameObject metalDetector;
    public GameObject nose;
    public GameObject shopkeeperAllMenus;
    public GameObject goToShopMenu;


    private void Start()
    {
        vCam.SetActive(false);
        vCam2.SetActive(false);
    }

    public void LookAtItems()
    {
        vCam.SetActive(false);
        vCam2.SetActive(true);
        shopkeeperAllMenus.SetActive(false);
        goToShopMenu.SetActive(true);
    }
    public void LookAtShop()
    {
        vCam.SetActive(true);
        vCam2.SetActive(false);
        shopkeeperAllMenus.SetActive(true);
        goToShopMenu.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        vCam.SetActive(true);
        player.GetComponent<MeshRenderer>().enabled = false;
        nose.GetComponent<MeshRenderer>().enabled = false;
        metalDetector.GetComponent<MeshRenderer>().enabled = false;
       

    }

    private void OnTriggerExit(Collider other)
    {
        vCam.SetActive(false);
        player.GetComponent<MeshRenderer>().enabled = true;
        nose.GetComponent<MeshRenderer>().enabled = true;
        metalDetector.GetComponent<MeshRenderer>().enabled = true;
    }
}
