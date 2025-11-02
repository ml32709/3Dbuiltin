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
        // NOTE: if multiple items satisfy all of these conditions at the same time and the player presses E, all items will be destroyed, not just one player looking at
        if(Input.GetKeyDown(KeyCode.E) && SelectionManager.Instance.onTarget && playerInRange && grabbable)
        {
            Debug.Log(ItemName + " added to inventory!");
            Destroy(gameObject);
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
