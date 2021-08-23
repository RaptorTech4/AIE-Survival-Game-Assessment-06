using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food Object", menuName = "Inventory System/Item/Food")]
public class FoodObject : ItemObject
{

    public int RestorHealthValue;
    public int RestorStaminaValue;

    public void Awake()
    {
        type = ItemType.Food;
    }

}
