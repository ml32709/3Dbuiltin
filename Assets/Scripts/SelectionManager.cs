using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 
public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance { get; set; }

    public bool onTarget;
    public GameObject interaction_Info_UI;
    TextMeshProUGUI interaction_text;

    private void Start()
    {
        interaction_text = interaction_Info_UI.GetComponent<TextMeshProUGUI>();
        interaction_text.text = "";
        onTarget = false;
    }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Update()
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);

        // cast ray to screen center
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;
            InteractableObject ourInteractable = selectionTransform.GetComponent<InteractableObject>();
 
            if (ourInteractable && ourInteractable.playerInRange)
            {
                onTarget = true;
                interaction_text.text = ourInteractable.GetItemName();
            }
            else
            {
                onTarget = false;
                interaction_text.text = "";
            }
 
        }
        else
        {
            onTarget = false;
            interaction_text.text = "";
        }
    }
}
