using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSystem : MonoBehaviour
{
    public static CraftingSystem instance { get; set; }

    public GameObject craftingScreenUI;
    public GameObject toolsScreenUI;

    public List<string> inventoryItemList = new List<string>();

    // Category buttons
    Button toolsBTN;

    // Craft buttons
    Button craftAxe;

    // Requirement text
    TextMeshPro axeReq1, axeReq2;

    public bool isOpen;

    // All Blueprint


    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        isOpen = false;

        toolsBTN = craftingScreenUI.transform.Find("ToolsButton").GetComponent<Button>();
        toolsBTN.onClick.AddListener(delegate { OpenToolsCategory(); });

        // axe
        axeReq1 = toolsScreenUI.transform.Find("Axe").transform.Find("req1").transform.GetComponent<TextMeshPro>();
        axeReq2 = toolsScreenUI.transform.Find("Axe").transform.Find("req2").transform.GetComponent<TextMeshPro>();

        craftAxe = toolsScreenUI.transform.Find("Axe").transform.Find("Button").transform.GetComponent<Button>();
        craftAxe.onClick.AddListener(delegate { CraftAnyItem(); });
    }

    void OpenToolsCategory()
    {
        craftingScreenUI.SetActive(false);
        toolsScreenUI.SetActive(true);
    }

    void CraftAnyItem()
    {
        // add item to inventory

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && !isOpen)
        {
            Debug.Log("crafting opened");

            craftingScreenUI.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            isOpen = true;

        }
        else if (Input.GetKeyDown(KeyCode.C) && isOpen)
        {
            Cursor.lockState = CursorLockMode.Locked;

            craftingScreenUI.SetActive(false);
            toolsScreenUI.SetActive(false);

            isOpen = false;
        }
    }
}
