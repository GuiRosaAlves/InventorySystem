using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class GhostStack
{
    public static GameObject gameObject;
    public static Transform transform;
    public static ItemStack stack = new ItemStack();
    private static Image imageComponent;
    private static Text textComponent;

    public static void Initialize(GameObject gameObject)
    {
        GhostStack.gameObject = gameObject;
        GhostStack.transform = GhostStack.gameObject.transform;
        GhostStack.imageComponent = GhostStack.gameObject.GetComponentInChildren<Image>();
        textComponent = GhostStack.gameObject.GetComponentInChildren<Text>();
    }
    public static void UpdateUI()
    {
        if(!stack.IsEmpty())
        {
            gameObject.name = stack.item.name;
            imageComponent.sprite = stack.item.image;
            imageComponent.color = new Color(255, 255, 255, 255);
            textComponent.text = (stack.quantity > 1) ? stack.quantity + "" : "";
            GhostStack.gameObject.SetActive(true);
        }
    }
    public static void Move(Vector2 position)
    {
        GhostStack.transform.position = position;
    }
}