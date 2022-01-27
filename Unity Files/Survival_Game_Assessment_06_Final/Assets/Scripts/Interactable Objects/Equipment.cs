using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    [Space]
    public EquipmentSlot equipmentSlot;
    public SkinnedMeshRenderer mesh;

    public EquipmentMeshRegion[] coverdMeshRegions;

    [Header("Armor")]
    
    public bool RandomArmorModifier;

    public int minArmorModifier;
    public int maxArmorModifier;

    [Header("Damage")]
    
    public bool RandomDamageModifier;

    public int minDamageModifier;
    public int maxDamageModifier;

    [HideInInspector] public bool RandomValuseSet;

    [Header("HandHeld")]
    public bool handHeld;
    public bool rightHand;
    public bool leftHand;


    public override void Use()
    {
        base.Use();
        EquipmentManager.Instance.Equip(this);
        RemoveFromInventory();
    }
}

public enum EquipmentSlot { Head, Chest, Legs, Weapon, Shield, Feet }

public enum EquipmentMeshRegion { Torso, Arms, Legs };
