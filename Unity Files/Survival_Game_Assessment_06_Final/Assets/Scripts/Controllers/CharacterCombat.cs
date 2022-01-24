using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 0.2f;
    private float attackCooldown = 0f;
    CharacterStats myStats;

    public float attackDelay = 0.6f;

    public event System.Action OnAttack;

    private void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        if(attackCooldown > 0)
            attackCooldown -= Time.deltaTime;
    }

    public void Attack(CharacterStats targetStats)
    {
        if(attackCooldown <= 0f)
        {
            StartCoroutine(DoDamage(targetStats, attackDelay));
            attackCooldown = 1f / attackSpeed;

            if(OnAttack != null)
            {
                OnAttack();
            }

        }
    }

    IEnumerator DoDamage(CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);

        stats.TakeDamage(myStats.damage.GetValue());
    }

}
