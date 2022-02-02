using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 0.2f;
    private float attackCooldown = 0f;
    const float combatCooldown = 5f;
    float lastAttackTime;

    CharacterStats myStats;
    CharacterStats opponentStats;

    public float attackDelay = 0.6f;
    public bool InCombat { get; private set; }
    public event System.Action OnAttack;


    private void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        if (attackCooldown > 0)
            attackCooldown -= Time.deltaTime;

        if (Time.deltaTime - attackCooldown > combatCooldown)
        {
            InCombat = false;
        }
    }

    public void Attack(CharacterStats targetStats)
    {
        if (attackCooldown <= 0f)
        {
            opponentStats = targetStats;
            if (OnAttack != null)
            {
                OnAttack();
            }

            attackCooldown = 1f / attackSpeed;
            InCombat = true;
            lastAttackTime = Time.time;
        }
    }


    public void Attackhit_AnimationEvent()
    {
        opponentStats.TakeDamage(myStats.damage.GetValue());

        if (opponentStats.currentHealf <= 0)
        {
            InCombat = false;
        }
    }

}
