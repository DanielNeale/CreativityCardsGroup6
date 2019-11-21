using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    public GameObject shopkeeperAllMenus;
    public GameObject shopkeeperFlirt;
    public GameObject shopkeeperFriendly;
    public GameObject shopkeeperNasty;
    public GameObject dialogueCanvas;
    public bool Discount;

    void Start()
    {
        Discount = false;
    }
    public void Friendly()
    {
        shopkeeperFriendly.SetActive(true);
        shopkeeperNasty.SetActive(false);
        shopkeeperFlirt.SetActive(false);
        dialogueCanvas.SetActive(false);
    }

    public void Flirt()
    {
        shopkeeperFlirt.SetActive(true);
        shopkeeperNasty.SetActive(false);
        shopkeeperFriendly.SetActive(false);
        dialogueCanvas.SetActive(false);
        Discount = true;
    }

    public void Nasty()
    {
        shopkeeperNasty.SetActive(true);
        shopkeeperFriendly.SetActive(false);
        shopkeeperFlirt.SetActive(false);
        dialogueCanvas.SetActive(false);
    }
}
