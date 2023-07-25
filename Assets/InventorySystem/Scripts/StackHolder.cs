using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StackHolder : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public ItemStack stack;

    private Text textComponent;
    private Image imageComponent;
    private Vector2 mouseOffset;

    public void Start()
    {
        textComponent = GetComponentInChildren<Text>();
        imageComponent = GetComponent<Image>();
    }
    public void Initiate(ItemStack stack)
    {
        textComponent = GetComponentInChildren<Text>();
        imageComponent = GetComponent<Image>();
        this.stack = stack;
        UpdateUI();
        GhostStack.gameObject.SetActive(false);
    }

    public bool UpdateUI()
    {
        if (!stack.IsEmpty())
        {
            EnableUI();
            return true;
        }
        else
        {
            DisableUI();
            return false;
        }
    }

    public void EnableUI()
    {
        gameObject.name = stack.item.name;
        imageComponent.sprite = stack.item.image;
        imageComponent.color = new Color(255, 255, 255, 255);
        textComponent.text = (stack.quantity > 1) ? stack.quantity + "" : "";
    }

    public void DisableUI()
    {
        gameObject.name = "Empty Stack";
        imageComponent.color = new Color(255, 255, 255, 0);
        textComponent.text = "";
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        mouseOffset = eventData.position - (Vector2)transform.position;

        GhostStack.stack.id = stack.id;
        GhostStack.stack.item = stack.item;

        if (Input.GetMouseButton(0))
            GhostStack.stack.quantity = stack.quantity;
        else if (Input.GetMouseButton(2))
            GhostStack.stack.quantity = (stack.quantity / 2);
        else if (Input.GetMouseButton(1))
            GhostStack.stack.quantity = 1;
        else
            GhostStack.stack.quantity = 1;

        if ((stack.quantity - GhostStack.stack.quantity) <= 0)
        {
            DisableUI();
        }
        else
        {
            textComponent.text = ((stack.quantity - GhostStack.stack.quantity) > 1) ? (stack.quantity - GhostStack.stack.quantity) + "" : "";
        }

        GhostStack.UpdateUI();
    }

    public void OnDrag(PointerEventData eventData)
    {
        GhostStack.Move(eventData.position - mouseOffset);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject == null)
        {
            if (stack.item is SpawnableItem)
            {
                ((SpawnableItem)stack.item).Spawn(Vector3.zero);
            }
            stack.quantity -= GhostStack.stack.quantity;
        }
        GhostStack.gameObject.SetActive(false);
        UpdateUI();
    }
}