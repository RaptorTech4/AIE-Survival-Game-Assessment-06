using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item/Bace")]
public class Enemie : ScriptableObject
{

    public float speed;
    public float health;
    public GameObject enemieModel;
    public int XP;

    float _speed;
    float _health;
    GameObject _enemieModel;
    int _XP;

    public void Reset()
    {

    }

    public void Oncrete()
    {
        _speed = speed;
        _health = health;
        _enemieModel = enemieModel;
        _XP = XP;
    }
}
