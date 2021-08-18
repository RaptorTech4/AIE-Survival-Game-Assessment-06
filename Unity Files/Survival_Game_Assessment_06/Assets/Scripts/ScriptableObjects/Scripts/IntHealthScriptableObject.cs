using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthValue", menuName = "ScriptableObjects/Presets/Health")]
public class IntHealthScriptableObject : ScriptableObject
{
    public int Value;
    public int MaxValue;

    public void AddToValue(int AddedValue)
    {
        Value = Value + AddedValue;
        if(Value>MaxValue)
        {
            Value = MaxValue;
        }
    }
}
