using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody man;
    public Rigidbody dog;
    public float manSpeed;
    public float dogSpeed;
    public float leadLength;
    float coolDown;
    float manCoolDown;

    public bool dogTaken;

    void Start()
    {
        man = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 moveDirection = new Vector3(0, 0, 0);

        // Toby's shoddy fix at dog floating
        if(dog.transform.position.y > 0.32f)
        {
            dog.transform.position = new Vector3(dog.transform.position.x, (dog.transform.position.y - 0.05f), dog.transform.position.z);
        }

        //Manly Movement
        if (manCoolDown <= 0f)
        {
            
            if (Input.GetKey(KeyCode.W))
            {
                moveDirection.z = 1;
            }

            if (Input.GetKey(KeyCode.S))
            {
                moveDirection.z = -1;
            }

            if (Input.GetKey(KeyCode.D))
            {
                moveDirection.x = 1;
            }

            if (Input.GetKey(KeyCode.A))
            {
                moveDirection.x = -1;
            }

            moveDirection.Normalize();
            man.velocity = (moveDirection * manSpeed);
            man.transform.LookAt(man.transform.position + moveDirection);
        }
        


        //Dogo Movement
        coolDown -= Time.deltaTime;

        if (Vector3.Distance(man.transform.position, dog.transform.position) < leadLength && coolDown < 0)
        {
            Vector3 dogMoveDirection = new Vector3(0, 0, 0);

            if (Input.GetKey(KeyCode.UpArrow))
            {
                dogMoveDirection.z = 1;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                dogMoveDirection.z = -1;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                dogMoveDirection.x = 1;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                dogMoveDirection.x = -1;
            }

            if(!dogTaken)
            {
                dogMoveDirection.Normalize();
                dog.velocity = (dogMoveDirection * dogSpeed);
                dog.transform.LookAt(dog.transform.position + dogMoveDirection);
               
            }
            
            
        }
        else
        {            
            dog.transform.LookAt(new Vector3(man.transform.position.x, dog.transform.position.y, man.transform.position.z));

            // I've made it so dog is dragged faster if further away ( like if it gets stuck on a rock ) ~Toby
            if (Vector3.Distance(man.transform.position, dog.transform.position) > 16)
            {
                dog.velocity = (dog.transform.forward * manSpeed * 5);
            }
            else if (Vector3.Distance(man.transform.position, dog.transform.position) > 10)
            {
                dog.velocity = (dog.transform.forward * manSpeed * 3);
            }
            else
            {
                dog.velocity = (dog.transform.forward * manSpeed);
            }
        }

       

        manCoolDown -= Time.deltaTime;

        if (Vector3.Distance(man.transform.position, dog.transform.position) > leadLength)
        {
            coolDown = 0.2f;
        }
    }

    public void DraggedByKid()
    {
        man.transform.LookAt(new Vector3(dog.transform.position.x, man.transform.position.y, dog.transform.position.z));
        man.velocity = (man.transform.forward * 5);
        manCoolDown = 0.2f;
    }
}
