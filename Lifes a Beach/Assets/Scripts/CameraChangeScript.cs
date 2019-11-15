using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeScript : MonoBehaviour
{
    
    public GameObject vCam;
    public GameObject player;
    public GameObject metalDetector;
   


    private void Start()
    {
        vCam.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        vCam.SetActive(true);
        player.GetComponent<MeshRenderer>().enabled = false;
        metalDetector.GetComponent<MeshRenderer>().enabled = false;
       

    }

    private void OnTriggerExit(Collider other)
    {
        vCam.SetActive(false);
        player.GetComponent<MeshRenderer>().enabled = true;
        metalDetector.GetComponent<MeshRenderer>().enabled = true;
    }
}
