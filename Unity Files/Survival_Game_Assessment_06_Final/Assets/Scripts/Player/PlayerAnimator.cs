using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : CharacterAnimator
{

    public WeaponAnimation[] weaponAnimations;
    Dictionary<Equipment, AnimationClip[]> weaponsAnimationsDictionary;

    protected override void Start()
    {
        base.Start();

        EquipmentManager.Instance.onEquipmentChanged += OnEquipmentChange;
        weaponsAnimationsDictionary = new Dictionary<Equipment, AnimationClip[]>();
        foreach (WeaponAnimation a in weaponAnimations)
        {
            weaponsAnimationsDictionary.Add(a.weapon, a.clips);
        }

    }

    void OnEquipmentChange(Equipment newItem, Equipment oldItem)
    {
        if(newItem != null && newItem.equipmentSlot == EquipmentSlot.Weapon)
        {
            animator.SetLayerWeight(1, 1);

            if(weaponsAnimationsDictionary.ContainsKey(newItem))
            {
                currentAttackAnimationSet = weaponsAnimationsDictionary[newItem];
            }
        }
        else if(newItem == null && oldItem != null && oldItem.equipmentSlot == EquipmentSlot.Weapon)
        {
            animator.SetLayerWeight(1, 0);
            currentAttackAnimationSet = defaultAttackAnimationSet;
        }

        if (newItem != null && newItem.equipmentSlot == EquipmentSlot.Shield)
        {
            animator.SetLayerWeight(2, 1);
        }
        else if (newItem == null && oldItem != null && oldItem.equipmentSlot == EquipmentSlot.Shield)
        {
            animator.SetLayerWeight(2, 0);

        }

    }

    [System.Serializable]
    public struct WeaponAnimation
    {
        public Equipment weapon;
        public AnimationClip[] clips;
    }

}
