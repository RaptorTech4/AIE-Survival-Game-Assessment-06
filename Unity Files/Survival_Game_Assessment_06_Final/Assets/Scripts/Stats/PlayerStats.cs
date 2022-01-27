using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{


    public override void Start()
    {
        base.Start();
        EquipmentManager.Instance.onEquipmentChanged += OnEquipmentChanged;
    }


    void OnEquipmentChanged(Equipment newItem,Equipment oldItem)
    {
        if(newItem != null)
        {

            if (newItem.RandomValuseSet)
            {
                if (newItem.RandomArmorModifier)
                {
                    newItem.armorModifier = Random.Range(newItem.minArmorModifier, newItem.maxArmorModifier);
                }
                if (newItem.RandomDamageModifier)
                {
                    newItem.damageModifier = Random.Range(newItem.minDamageModifier, newItem.maxDamageModifier);
                }
                newItem.RandomValuseSet = true;
            }

            armor.AddModifier(newItem.armorModifier);
            damage.AddModifier(newItem.damageModifier);

            Debug.Log("Adding Modifier");
        }
        if(oldItem != null)
        {
            armor.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(oldItem.damageModifier);

            Debug.Log("Removing Modifier");
        }
            Debug.Log("No Modifier");
    }

    public override void Die()
    {
        base.Die();
        PlayerManager.Instance.KillPlayer();
    }
}
