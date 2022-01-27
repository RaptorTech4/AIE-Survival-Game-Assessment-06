using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Inventory/Consumable")]
public class Consumable : Item
{

    public ConsumableType consumableType;

    public override void Use()
    {
        base.Use();
        EquipmentManager.Instance.ConsumeItem(this);
        RemoveFromInventory();
    }

}

public enum ConsumableType { AddCurrentHealth, AddMaxHealth, MaxHealth }