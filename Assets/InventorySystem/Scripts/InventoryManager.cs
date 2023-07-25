using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Inventory InventoryPreset;
    [SerializeField] private ItemStack[] InventoryDefault = new ItemStack[16];
    public ItemStack[] Inventory { get { return ((InventoryPreset == null) ? InventoryDefault : InventoryPreset.itemList); } }
    private Slot[] slots;
    public Item equippedItem { get { return _equippedItem; } }
    public Item _equippedItem;

    private void Awake()
    {
        GhostStack.Initialize(GameObject.FindWithTag("GhostStack"));

        slots = GetComponentsInChildren<Slot>();

        for (int i = 0; i < slots.Length; i++)
        {
            InventoryDefault[i] = new ItemStack();
            Inventory[i].id = i;
            slots[i].Initiate(Inventory[i]);
        }
    }

    public static void MoveStacks(ItemStack a, ItemStack ghostStack, ItemStack b)
    {
        a.quantity -= GhostStack.stack.quantity;

        if (b.IsEmpty())
        {
            b.item = ghostStack.item;
            b.quantity = ghostStack.quantity;
        }
        else if (b.item.stackable && a.item == b.item)
        {
            b.item = ghostStack.item;
            b.quantity += ghostStack.quantity;
        }
        else
        {
            a.item = b.item;
            a.quantity = b.quantity;

            b.item = ghostStack.item;
            b.quantity = ghostStack.quantity;
        }
    }

    public void Add(Item item, int quantity)
    {
        if (item.stackable)
        {
            for (int i = 0; i < Inventory.Length; i++)
            {
                if (item == Inventory[i].item)
                {
                    Inventory[i].quantity += quantity;
                    slots[Inventory[i].id].stackedItem.UpdateUI();
                    return;
                }
            }
            foreach (ItemStack stack in Inventory)
            {
                if (stack.IsEmpty())
                {
                    stack.item = item;
                    stack.quantity = quantity;
                    slots[stack.id].stackedItem.UpdateUI();
                    return;
                }
            }
        }
        else
        {
            foreach (ItemStack stack in Inventory)
            {
                if (stack.IsEmpty())
                {
                    stack.item = item;
                    stack.quantity = quantity;
                    slots[stack.id].stackedItem.UpdateUI();
                    return;
                }
            }
        }
    }

    public void EquipItem(int index)
    {
        _equippedItem = Inventory[index].item;
    }

    public void OpenClose()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void OpenClose(bool state)
    {
        gameObject.SetActive(state);
    }
}