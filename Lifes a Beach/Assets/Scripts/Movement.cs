using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    Rigidbody man;
    public Rigidbody dog;
	public GameObject notEnoughMoney;
	public Text moneyText;
    public float manSpeed;
    public float dogSpeed;
    public float leadLength;
	public float moneyFadeValue;
	public bool moneyMenuActive;
	public float moneyCountdown;
	public int money;
    float coolDown;
    float manCoolDown;

    public bool dogTaken;

    void Start()
    {
        man = GetComponent<Rigidbody>();
		money = 0;
		moneyCountdown = 0.5f;
        moneyMenuActive = false;
        moneyFadeValue = 1f;
		notEnoughMoney.SetActive(false);
    }

    void Update()
    {
		if (moneyMenuActive == true) 
		{
			noMoney();
		}
		moneyText.text = money.ToString();
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
	public void noMoney()
	{
		if (moneyCountdown > 0)
        {
			notEnoughMoney.SetActive(true);
            moneyCountdown -= Time.deltaTime;
        }
		else
		{
			notEnoughMoney.GetComponent<CanvasGroup>().alpha = moneyFadeValue;
			moneyFadeValue -= Time.deltaTime;
			if (moneyFadeValue <= 0)
			{
				notEnoughMoney.SetActive(false);
				moneyCountdown = 0.5f;
				moneyMenuActive = false;
				moneyFadeValue = 1f;
			}
		}
	}

    public void DraggedByKid()
    {
        man.transform.LookAt(new Vector3(dog.transform.position.x, man.transform.position.y, dog.transform.position.z));
        man.velocity = (man.transform.forward * 5);
        manCoolDown = 0.2f;
    }

    public void CrabPinched()
    {
       
        StartCoroutine(PinchedDelay());
    }


    IEnumerator PinchedDelay()
    {
        float speedBefore = manSpeed;
        manSpeed = manSpeed / 2;
        yield return new WaitForSeconds(1.5f);
        manSpeed = speedBefore;
        
    }
	
	public void SpeedUpgrade()
	{
		if (money >= 5) 
		{
			money = money - 5;
			manSpeed = 7;
		}
		else
		{
			moneyMenuActive = true;
		}
	}
	public void LuckUpgrade()
	{
		if (money >= 7) 
		{
			money = money - 7;
		}
		else
		{
			moneyMenuActive = true;
		}
	}
	public void BackUpgrade()
	{
		if (money >= 2) 
		{
			money = money - 2;
		}
		else
		{
			moneyMenuActive = true;
		}
	}
}
