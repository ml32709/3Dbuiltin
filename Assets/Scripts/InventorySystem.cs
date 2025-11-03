using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem Instance { get; set; }
 
    public GameObject inventoryScreenUI;
    public bool isOpen;
 
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
 
    void Start()
    {
        isOpen = false;
    }
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !isOpen)
        {
 
		    Debug.Log("inventory opened");
            inventoryScreenUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            isOpen = true;
 
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && isOpen)
        {
            Cursor.lockState = CursorLockMode.Locked;
            inventoryScreenUI.SetActive(false);
            isOpen = false;
        }
    }
}