using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class InteractableObject : MonoBehaviour
{
    public string ItemName;
    public bool grabbable;
    public bool playerInRange;

    public string GetItemName()
    {
        return ItemName;
    }

    void Update()
    {
        // NOTE: onTarget will apply for every item in range, even if only looking at one
        if(Input.GetKeyDown(KeyCode.E) && SelectionManager.Instance.onTarget && playerInRange && grabbable)
        {
            // if inventory is NOT full
            if (!InventorySystem.Instance.CheckIfFull())
            {
                InventorySystem.Instance.AddToInventory(ItemName);
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Inventory is full!");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
