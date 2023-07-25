using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public StackHolder stackedItem;

    public void Initiate(ItemStack stack)
    {
        stackedItem = GetComponentInChildren<StackHolder>();
        stackedItem.Initiate(stack);
    }

    public void OnDrop(PointerEventData eventData)
    {
        ItemStack droppedStack = eventData.pointerDrag.GetComponent<StackHolder>().stack;
        if (!droppedStack.IsEmpty() && !GhostStack.stack.IsEmpty())
        {
            InventoryManager.MoveStacks(droppedStack, GhostStack.stack, stackedItem.stack);
            stackedItem.UpdateUI();
        }
        GhostStack.stack.EmptyStack();
    }
}