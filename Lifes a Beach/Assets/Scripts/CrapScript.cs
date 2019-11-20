using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrapScript : MonoBehaviour
{

    private GameObject Player;
    private GameObject Dog;

    NavMeshAgent Enemy;

    private GameObject body;


    public bool pinchedHuman;

    public Movement movementScript;

   // public float distance = 0f;

    void Start()
    {
        Enemy = GetComponent<NavMeshAgent>();
        Dog = GameObject.FindGameObjectWithTag("Dog");
        Player = GameObject.FindGameObjectWithTag("Player");

        body = this.gameObject.transform.GetChild(0).gameObject;
        movementScript = Player.GetComponent<Movement>();
    }


    void Update()
    {
    
        if(!pinchedHuman)
        {
            Enemy.SetDestination(Player.transform.position);
        }
       
        
    }

    

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        pinchedHuman = false;
    }



    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            if(!pinchedHuman)
            {
                movementScript.CrabPinched();
                pinchedHuman = true;
                StartCoroutine(Delay());
            }
            

        }
        else if (other.gameObject.tag == "Dog")
        {
            // stomped by dog

            //transform.DetachChildren();
            //Destroy(body);

            Destroy(this.gameObject);

           
          

        }
    }

}



