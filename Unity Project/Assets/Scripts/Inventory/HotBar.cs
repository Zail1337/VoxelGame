using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotBar : MonoBehaviourClassic
{

    public int slotAmount = 3;


    public GameObject slotPrefab;
    public GameObject slotParent;
    public GameObject inventoryObject;

    public List<GameObject> slots = new List<GameObject>();

    public KeyCode inventoryKey = KeyCode.Tab;
    public bool isShown = false;

    private void Start()
    {
        CreateSlots(slotAmount);
    }

    private void CreateSlots(int slotAmountslots)
    {
        for (int i = 0; i < slotAmount; i++)
        {
            slots.Add(Instantiate(slotPrefab));
            slots[i].transform.SetParent(slotParent.transform);
        }
    }

    private void Update()
    {

    }
}
