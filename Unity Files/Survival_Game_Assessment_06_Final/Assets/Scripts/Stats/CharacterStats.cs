using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public int maxHealf = 100;
    public int currentHealf;

    public Stat damage;
    public Stat armor;

    private void Awake()
    {
        currentHealf = maxHealf;
    }

    public virtual void Start()
    {

    }

    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealf -= damage;
        if(currentHealf <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {

    }

}
