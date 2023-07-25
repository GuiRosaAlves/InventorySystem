using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private Item[] ItemArray;
    [SerializeField] private InventoryManager InvManager;

    public void AddRandomItem()
    {
        var ItemToAdd = PickRandom(ItemArray);
        InvManager.Add(ItemToAdd, 1);
    }

    public static T PickRandom<T>(T[] Array)
    {
        var randomIndex = Random.Range(0, Array.Length);
        return Array[randomIndex];
    }
}
