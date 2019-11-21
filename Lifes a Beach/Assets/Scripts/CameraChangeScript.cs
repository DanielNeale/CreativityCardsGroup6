using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeScript : MonoBehaviour
{
    
    public GameObject vCam;
    public GameObject vCam2;
    public GameObject player;
    public GameObject metalDetector;
    public GameObject shopkeeperAllMenus;
    public GameObject goToShopMenu;
    public float ShopAllMenusFadeValue;
    public bool ShopAllMenusActive;
    public float ToShopMenuFadeValue;
    public bool ToShopMenuActive;


    private void Start()
    {
        vCam.SetActive(false);
        vCam2.SetActive(false);
    }
    void Update()
    {
        shopAllMenusFade();
        ToShopMenusFade();
    }
    public void LookAtItems()
    {
        vCam.SetActive(false);
        vCam2.SetActive(true);
        goToShopMenu.SetActive(true);
        ShopAllMenusActive = false;
        ToShopMenuActive = true;
    }
    public void LookAtShop()
    {
        vCam.SetActive(true);
        vCam2.SetActive(false);
        shopkeeperAllMenus.SetActive(true);
        goToShopMenu.SetActive(false);
        ShopAllMenusActive = true;
        ToShopMenuActive = false;
    }
    public void shopAllMenusFade()
    {
        shopkeeperAllMenus.GetComponent<CanvasGroup>().alpha = ShopAllMenusFadeValue;
        if (ShopAllMenusActive == true)
        {
            if (ShopAllMenusFadeValue < 1)
            {
                ShopAllMenusFadeValue += Time.deltaTime;
            }
        }
        else
        {
            if (ShopAllMenusFadeValue > 0)
            {
                ShopAllMenusFadeValue -= Time.deltaTime;
            }
        }
        if (ShopAllMenusFadeValue <= 0)
        {
            shopkeeperAllMenus.SetActive(false);
        }
    }
    public void ToShopMenusFade()
    {
        goToShopMenu.GetComponent<CanvasGroup>().alpha = ToShopMenuFadeValue;
        if (ToShopMenuActive == true)
        {
            if (ToShopMenuFadeValue < 1)
            {
                ToShopMenuFadeValue += Time.deltaTime;
            }
        }
        else
        {
            if (ToShopMenuFadeValue > 0)
            {
                ToShopMenuFadeValue -= Time.deltaTime;
            }
        }
        if (ToShopMenuFadeValue <= 0)
        {
            goToShopMenu.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            vCam.SetActive(true);
            //player.GetComponent<MeshRenderer>().enabled = false;
            metalDetector.GetComponent<MeshRenderer>().enabled = false;
            ShopAllMenusActive = true;
            shopkeeperAllMenus.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            vCam.SetActive(false);
            vCam2.SetActive(false);
            //player.GetComponent<MeshRenderer>().enabled = true;
            metalDetector.GetComponent<MeshRenderer>().enabled = true;
            ShopAllMenusActive = false;
            ToShopMenuActive = false;
        }
    }
}
