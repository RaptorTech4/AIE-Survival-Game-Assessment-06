using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Object", menuName = "Inventory System/Item/Combat Equipment")]
public class CombatEquipmentObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.CombatEquipment;
    }
}
