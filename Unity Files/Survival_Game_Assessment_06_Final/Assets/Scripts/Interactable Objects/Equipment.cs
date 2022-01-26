using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipmentSlot;
    public SkinnedMeshRenderer mesh;

    public EquipmentMeshRegion[] coverdMeshRegions;

    [Header("Armor")]
    public int armorModifier;
    public bool RandomArmorModifier;

    public int minArmorModifier;
    public int maxArmorModifier;

    [Header("Damage")]
    public int damageModifier;
    public bool RandomDamageModifier;

    public int minDamageModifier;
    public int maxDamageModifier;

    public override void Use()
    {
        base.Use();
        EquipmentManager.Instance.Equip(this);
        RemoveFromInventory();
    }

    private void Awake()
    {
        RandomValeu();
    }

    public void RandomValeu()
    {
        if(RandomArmorModifier)
        {
            armorModifier = Random.Range(minArmorModifier, maxArmorModifier);
        }

        if(RandomDamageModifier)
        {
            damageModifier = Random.Range(minDamageModifier, maxDamageModifier);
        }
    }

}

public enum EquipmentSlot { Head, Chest, Legs, Weapon, Shield, Feet}

public enum EquipmentMeshRegion { Torso, Arms, Legs };
