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

    void Start()
    {
        man = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 moveDirection = new Vector3(0, 0, 0);

        //Manly Movement
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

            dogMoveDirection.Normalize();
            dog.velocity = (dogMoveDirection * dogSpeed);
            dog.transform.LookAt(dog.transform.position + dogMoveDirection);
        }

        else
        {            
            dog.transform.LookAt(new Vector3(man.transform.position.x, dog.transform.position.y, man.transform.position.z));
            dog.velocity = (dog.transform.forward * manSpeed);
        }

        if (Vector3.Distance(man.transform.position, dog.transform.position) > leadLength)
        {
            coolDown = 0.2f;
        }
    }
}
