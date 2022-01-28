using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemInfoUI : MonoBehaviour
{

    #region Singleton
    public static ItemInfoUI Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        Instance = this;
    }

    #endregion Singleton

    #region UI 
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text armorText;
    [SerializeField] TMP_Text damigeText;
    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text maxHealthText;

    [SerializeField] Button UseButton;

    #endregion

    Item item;

    private void Start()
    {
        nameText.text = "...";
        armorText.text = "0";
        damigeText.text = "0";
        healthText.text = "0";
        maxHealthText.text = "0";
        UseButton.interactable = false;
    }

    public void UpdateItemInfo(Item activeItem)
    {
        item = activeItem;

        if (item == null)
        {
            nameText.text = "...";
            armorText.text = "0";
            damigeText.text = "0";
            healthText.text = "0";
            maxHealthText.text = "0";

            UseButton.interactable = false;
        }
        else
        {
            nameText.text = activeItem.name;
            armorText.text = activeItem.armorModifier.ToString();
            damigeText.text = activeItem.damageModifier.ToString();
            if(activeItem.RefullHealth)
            {
                healthText.text = "MAX HEALTH";

            }
            else
            {
                healthText.text = activeItem.healthModifier.ToString();
            }
            maxHealthText.text = activeItem.maxHealthModifier.ToString();

            UseButton.interactable = true;
        }
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }

}
