using System.Collections.Generic;
using TMPro;
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

    bool isOpen;

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


    }

    void OpenToolsCategory()
    {
        craftingScreenUI.SetActive(false);
        toolsScreenUI.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !isOpen)
        {
            Debug.Log("crafting opened");

            craftingScreenUI.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            isOpen = true;

        }
        else if (Input.GetKeyDown(KeyCode.Tab) && isOpen)
        {
            Cursor.lockState = CursorLockMode.Locked;

            craftingScreenUI.SetActive(false);
            toolsScreenUI.SetActive(false);

            isOpen = false;
        }
    }
}
