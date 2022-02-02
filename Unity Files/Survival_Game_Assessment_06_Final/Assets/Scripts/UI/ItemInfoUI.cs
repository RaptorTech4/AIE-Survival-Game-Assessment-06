using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    [Header("Item Info")]
    [SerializeField] TMP_Text itemNameText;
    [SerializeField] TMP_Text itemArmorText;
    [SerializeField] TMP_Text itemDamigeText;
    [SerializeField] TMP_Text itemHealthText;
    [SerializeField] TMP_Text itemMaxHealthText;

    [SerializeField] Button UseButton;

    [Header("Player Status")]
    [SerializeField] PlayerStats playerStats;

    [SerializeField] TMP_Text playerArmorText;
    [SerializeField] TMP_Text playerDamigeText;
    [SerializeField] TMP_Text playerHealthText;
    [SerializeField] TMP_Text playerMaxHealthText;

    #endregion

    Item item;

    private void Start()
    {
        itemNameText.text = "...";
        itemArmorText.text = "0";
        itemDamigeText.text = "0";
        itemHealthText.text = "0";
        itemMaxHealthText.text = "0";
        UseButton.interactable = false;
        RefreasePlayerStats();
    }

    public void UpdateItemInfo(Item activeItem)
    {
        item = activeItem;

        if (item == null)
        {
            itemNameText.text = "...";
            itemArmorText.text = "0";
            itemDamigeText.text = "0";
            itemHealthText.text = "0";
            itemMaxHealthText.text = "0";

            UseButton.interactable = false;
        }
        else
        {
            itemNameText.text = activeItem.name;
            itemArmorText.text = activeItem.armorModifier.ToString();
            itemDamigeText.text = activeItem.damageModifier.ToString();
            if (activeItem.RefullHealth)
            {
                itemHealthText.text = "MAX HEALTH";

            }
            else
            {
                itemHealthText.text = activeItem.healthModifier.ToString();
            }
            itemMaxHealthText.text = activeItem.maxHealthModifier.ToString();

            UseButton.interactable = true;
        }
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();

            RefreasePlayerStats();
        }
    }

    public void RefreasePlayerStats()
    {
        if (playerStats != null)
        {
            playerArmorText.text = playerStats.armor.GetValue().ToString();
            playerDamigeText.text = playerStats.damage.GetValue().ToString();
            playerHealthText.text = playerStats.currentHealf.ToString();
            playerMaxHealthText.text = playerStats.maxHealf.ToString();
        }
    }

    public void UnequipAllItems()
    {
        EquipmentManager.Instance.UnequipAll();
    }
}
