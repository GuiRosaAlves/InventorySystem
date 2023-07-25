using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory Preset", menuName = "Inventory/Inventory Preset")]
public class Inventory : ScriptableObject
{
    public ItemStack[] itemList = new ItemStack[16];
}