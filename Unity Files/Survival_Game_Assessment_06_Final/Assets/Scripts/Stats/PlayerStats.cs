using UnityEngine;

public class PlayerStats : CharacterStats
{


    public override void Start()
    {
        base.Start();
        EquipmentManager.Instance.onEquipmentChanged += OnEquipmentChanged;
        EquipmentManager.Instance.onItemConsumed += OnItemConsumed;
    }


    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
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

        }
        if (oldItem != null)
        {
            armor.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(oldItem.damageModifier);

        }
    }

    void OnItemConsumed(Consumable item)
    {

        switch (item.consumableType)
        {
            case ConsumableType.AddCurrentHealth:
                    currentHealf += item.healthModifier;
                    if (currentHealf > maxHealf)
                    {
                        currentHealf = maxHealf;
                    }
                break;

            case ConsumableType.AddMaxHealth:
                    maxHealf += item.healthModifier;
                break;

            case ConsumableType.MaxHealth:
                    currentHealf = maxHealf;
                break;

            default:
                break;
        }


    }

    public override void Die()
    {
        base.Die();
        PlayerManager.Instance.KillPlayer();
    }
}
