using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnnoyingChildScript : MonoBehaviour
{

    private GameObject Player;
    private GameObject Dog;

    NavMeshAgent Enemy;

    private GameObject body;

    private GameObject fallenOver;

    public bool gotDog;


    void Start()
    {
        Enemy = GetComponent<NavMeshAgent>();
        Dog = GameObject.FindGameObjectWithTag("Dog");
        Player = GameObject.FindGameObjectWithTag("Player");

        body = this.gameObject.transform.GetChild(0).gameObject;
      
        fallenOver = this.gameObject.transform.GetChild(1).gameObject;
    }


    void Update()
    {
        if(!gotDog)
        {
            Enemy.SetDestination(Dog.transform.position);
        }
        else
        {
            Vector3 dirToPlayer = transform.position - Player.transform.position;
            Vector3 newPos = transform.position + dirToPlayer;

            Enemy.SetDestination(newPos);
        }
        
    }

    

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
    }



    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            // player smacks 
            transform.DetachChildren();
            fallenOver.SetActive(true);
            Destroy(body);
            Destroy(this.gameObject);

        }
        else if (other.gameObject.tag == "Dog")
        {
            // grabbed dog 
            gotDog = true;

        }
    }

}



