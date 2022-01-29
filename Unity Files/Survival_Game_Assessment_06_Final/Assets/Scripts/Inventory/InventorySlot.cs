using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

    public Image icon;
    public Button removeButton;

    Item item;

    public void SetItemActive()
    {
        ItemInfoUI.Instance.UpdateItemInfo(item);
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
        item.UpdateRandomItemValus();
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;

    }

    public void OnRemoveButton()
    {
        Inventory.Instance.Remove(item);
    }
}
