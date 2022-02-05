using UnityEngine;

public class EnemyStats : CharacterStats
{
    #region Modefire
    [Space]
    [SerializeField] bool randomModefire;
    [Header("Damige Modefire")]
    [SerializeField] int minDamigeModefire;
    [SerializeField] int maxDamigeModefire;
    [Header("Armor Modefire")]
    [SerializeField] int minArmorModefire;
    [SerializeField] int maxArmorModefire;
    #endregion Modefire

    [SerializeField] DroppebleItems droppebleEquipmentItems;
    [SerializeField] GameObject equipmentDropLocation;
    [SerializeField] DroppebleItems droppebleConsumableItems;
    [SerializeField] GameObject consumableDropLocation;

    public override void Start()
    {
        base.Start();
        if (randomModefire)
        {
            damage.AddModifier(Random.Range(minDamigeModefire, maxDamigeModefire));
            armor.AddModifier(Random.Range(minArmorModefire, maxArmorModefire));
        }
    }

    public override void Die()
    {
        base.Die();

        if(droppebleEquipmentItems != null)
        {
            droppebleEquipmentItems.SpawnRandomObject(equipmentDropLocation.transform);
        }

        if (droppebleConsumableItems != null)
        {
            droppebleConsumableItems.SpawnRandomObject(consumableDropLocation.transform);
        }

        Destroy(gameObject);
    }

}
