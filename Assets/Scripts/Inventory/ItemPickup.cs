using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    public GameObject inSceneObject;
    public InventoryManager inventoryManager;
    public PlayerHealth lives;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
    }

    public void PickUp()
    {
        Debug.Log("Picking up "+ item.name);
        //add to inventory
        bool added = inventoryManager.AddItem(item);
        if (added)
        {
            Destroy(inSceneObject);
        }
        if (item.name == "Life")
        {
            lives = GameObject.Find("Player").GetComponent<PlayerHealth>();
            lives.currentHealth = 5;
        }
    }


}
