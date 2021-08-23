using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuildingMaterialType
{
    Wood,
    Steal,
    Stone
}

[CreateAssetMenu(fileName = "New Building Material Object", menuName = "Inventory System/Item/Building Material")]
public class BuildingMaterialObject : ItemObject
{

    public BuildingMaterialType MaterialType;

    public void Awake()
    {
        type = ItemType.BuildingMaterial;
    }

}
