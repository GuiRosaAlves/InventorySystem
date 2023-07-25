using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D))]
public class PickupObject : MonoBehaviour
{
    public Item item;
    public int quantity;

    public void Initiate(Item item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
    }

    private void CollectObject(InventoryManager inventoryManager)
    {
        if (Input.GetButton("Pickup"))
        {
            inventoryManager.Add(item, quantity);
            Destroy(gameObject);
        }
    }
}