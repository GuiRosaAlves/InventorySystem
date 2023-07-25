using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spawnable Item", menuName = "Inventory/Spawnable Item Data")]
public class SpawnableItem : Item
{
    protected GameObject gameObject;

    public SpawnableItem(string name, bool stackable) : base(name, stackable)
    {

    }

    public virtual void Spawn(Vector3 spawnPosition)
    {
        //GameObject droppedItem = GameObject.Instantiate(prefab.gameObject, spawnPosition, Quaternion.identity);
        GameObject droppedItem = new GameObject(name + "Dropped");
        droppedItem.AddComponent<SpriteRenderer>().sprite = image;
        droppedItem.AddComponent<PickupObject>().Initiate(GhostStack.stack.item, GhostStack.stack.quantity);
        droppedItem.AddComponent<BoxCollider2D>().isTrigger = true;
    }
}