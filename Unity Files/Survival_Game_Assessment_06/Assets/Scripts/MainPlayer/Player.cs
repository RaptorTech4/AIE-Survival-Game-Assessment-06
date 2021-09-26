using UnityEngine;

public class Player : MonoBehaviour
{

    // public MouseItem mouseItem = new MouseItem();

    public InventoryObject inventory;
    public InventoryObject EquipmentInventory;

    private void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<GroundItem>();
        if (item)
        {
            Item _item = new Item(item.item);
            if (inventory.AddItem(_item, 1))
            {
                Destroy(other.gameObject);
            }

        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inventory.Save();
            EquipmentInventory.Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            inventory.Load();
            EquipmentInventory.Load();
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
        EquipmentInventory.Container.Clear();
    }
}
