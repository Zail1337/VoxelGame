using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {

    public List<Item> items = new List<Item>();

    private void Start()
    {
        ItemDatabaseSetup();
    } 

    private void ItemDatabaseSetup()
    {
        //To add a new Item:
        //items.Add(new Item("Name", "Description", "imageName", ID)


        items.Add(new Item("Iron Sword", "A solid weapom made of Iron.", "orcish_long_sword", 0));
        items.Add(new Item("Apple", "Fresh and healthy.", "apfel", 1));
    }

    public Item GetItemByID(int id)
    {
        foreach (Item itm in items)
        {
            if (itm.itemID == id)
            {
                return itm;
                Debug.Log(id);
            }
        }
        return null;
        Debug.LogError("Cant Find Item by ID");
    }

}
