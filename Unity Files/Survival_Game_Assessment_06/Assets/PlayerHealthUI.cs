using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{

    public FloatScriptableObject _health;
    public Item NewItem;
 
    Text _PlayerHealthUI;

    private void Start()
    {
        _PlayerHealthUI = GetComponent<Text>();
    }

    private void FixedUpdate()
    {
        _PlayerHealthUI.text = "Player Health : " + _health.Value;

        NewItem.Start(11);
    }
}
