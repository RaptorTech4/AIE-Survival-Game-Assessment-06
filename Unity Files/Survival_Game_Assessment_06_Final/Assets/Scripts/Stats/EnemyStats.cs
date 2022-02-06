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

    int randomChanse;

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
        randomChanse = Random.Range(0,1);

        if(droppebleEquipmentItems != null)
        {
            droppebleEquipmentItems.SpawnRandomObject(equipmentDropLocation.transform);
        }

        if (droppebleConsumableItems != null)
        {
            if(randomChanse==1)
                droppebleConsumableItems.SpawnRandomObject(consumableDropLocation.transform);
        }

        Destroy(gameObject);
    }

}
