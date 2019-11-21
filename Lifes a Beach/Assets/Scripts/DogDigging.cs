using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogDigging : MonoBehaviour
{
    public InventoryScript inventory;

    void OnTriggerStay(Collider other)
    {
        if ((other.gameObject.tag == "DigSpot") &&(Input.GetKeyDown(KeyCode.RightShift)))
        {
            var item = other.GetComponent<Item>();
            if (item)
            {
                inventory.AddItem(item.item, 1);
                Destroy(other.gameObject);
            }
            print("Got Treasure!");
            Destroy(other.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
