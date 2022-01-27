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


        Destroy(gameObject);
    }

}
