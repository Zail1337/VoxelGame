using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item {

    public string itemName;
    public string itemDescription;
    public Sprite itemSprite;
    public string itemSpriteName;
    public int itemID;

    public Item(string name, string description, string spriteName,  int id)
    {
        itemName = name;
        itemDescription = description;
        itemSpriteName = spriteName;
        itemSprite = Resources.Load<Sprite>("2D/Items/" + spriteName);
        itemID = id;
    }
}
