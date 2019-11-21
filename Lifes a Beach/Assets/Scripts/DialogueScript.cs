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
    public float dialogueFadeValue;
    public bool dialogueMenuActive;
    public bool Discount;

    void Start()
    {
        Discount = false;
        dialogueMenuActive = true;
    }
    void Update()
    {
        dialogueFade();
    }
    public void Friendly()
    {
        shopkeeperFriendly.SetActive(true);
        shopkeeperNasty.SetActive(false);
        shopkeeperFlirt.SetActive(false);
        dialogueMenuActive = false;
    }
    public void Flirt()
    {
        shopkeeperFlirt.SetActive(true);
        shopkeeperNasty.SetActive(false);
        shopkeeperFriendly.SetActive(false);
        dialogueMenuActive = false;
    }
    public void Nasty()
    {
        shopkeeperNasty.SetActive(true);
        shopkeeperFriendly.SetActive(false);
        shopkeeperFlirt.SetActive(false);
        dialogueMenuActive = false;
        Discount = true;
    }
    public void dialogueFade()
    {
        dialogueCanvas.GetComponent<CanvasGroup>().alpha = dialogueFadeValue;
        if (dialogueMenuActive == true)
        {
            dialogueFadeValue = 1;
        }
        if (dialogueMenuActive == false)
        {
            dialogueFadeValue -= Time.deltaTime;
            if (dialogueFadeValue <= 0)
            {
                dialogueCanvas.SetActive(false);
            }
        }
    }
}
