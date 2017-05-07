using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviourClassic {

    public int slotAmount = 30;

    //Prefabs and Object for Inventory
    public GameObject slotPrefab;
    public GameObject slotParent;
    public GameObject inventoryObject;
    public GameObject itemPrefab;



    //Item Database
    private ItemDatabase itemDatabase;

    public List<GameObject> slots = new List<GameObject>();

    //Open and Close Inv
    public KeyCode inventoryKey = KeyCode.Tab;
    public bool isShown = false;

    private void Start()
    {
        CreateSlots(slotAmount);

        //Find Item Database
        itemDatabase = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
    }

    private void CreateSlots(int slotAmount)
    {
        for(int i = 0; i < slotAmount; i++)
        {
            slots.Add(Instantiate(slotPrefab));
            slots[i].transform.SetParent(slotParent.transform);
        }
    }


    //Item Database
    public void AddItem(int id)
    {
        Item itemAdd = itemDatabase.GetItemByID(id);
        
        for(int i = 0; i < slots.Count; i++)
        {
            if (slots[i].transform.childCount <= 0)
            {
                Debug.Log("Creating Item");
                GameObject ItemInstance = Instantiate(itemPrefab);// Create Item Object
                ItemInstance.transform.SetParent(slots[i].transform); //set Item Parent
                ItemInstance.transform.localPosition = Vector2.zero; //set Items position to (0,0)
                itemPrefab.GetComponent<Image>().sprite = itemAdd.itemSprite; // Set Sprite
                break;
            }
        }
    }



    private void Update()
    {
        //Get Key to open Inventory
        if (Input.GetKeyDown(inventoryKey))
        {
            //set isShown to the oposit(true -> False / False -> True)
            isShown = !isShown;
        }
        if(isShown == true)
        {
            inventoryObject.SetActive(true);
        }

        if(isShown == false)
        {
            inventoryObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            AddItem(0);
            Debug.Log("Addet Item by id 0");        
        }
    }
}
