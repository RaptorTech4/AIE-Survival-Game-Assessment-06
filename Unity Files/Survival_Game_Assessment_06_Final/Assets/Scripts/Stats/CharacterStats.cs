using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public int maxHealf = 100;
    public int currentHealf;

    public Stat damage;
    public Stat armor;

    public event System.Action<int, int> OnHealthChanged;

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
        
        if(damage > 0)
        {
            currentHealf -= damage;
        }
        else
        {
            currentHealf -= 5;
        }

        if(OnHealthChanged != null)
        {
            OnHealthChanged(maxHealf,currentHealf);
        }

        if(currentHealf <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {

    }

}
