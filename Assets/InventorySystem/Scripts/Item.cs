using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item Data")]
public class Item : ScriptableObject
{
    public Sprite image;
    public bool stackable;

    public Item(string name, bool stackable)
    {
        this.name = name;
        this.stackable = stackable;
    }
}