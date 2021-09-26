using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DynamikInterface : UserInterface
{
    public GameObject inventoryPrefab;
    public int X_Start;
    public int Y_Start;
    public int X_Space_Between_Item;
    public int Y_Space_Between_Item;
    public int Number_Of_Colums;

    public override void CreateSlots()
    {
        itemsDisplayed = new Dictionary<GameObject, InventorySlot>();
        for (int i = 0; i < inventory.Container.Items.Length; i++)
        {
            var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);

            AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
            AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
            AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragStart(obj); });
            AddEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); });
            AddEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); });

            itemsDisplayed.Add(obj, inventory.Container.Items[i]);
        }
    }

    private Vector3 GetPosition(int i)
    {
        return new Vector3((X_Start + (X_Space_Between_Item * (i % Number_Of_Colums))), (Y_Start + (-Y_Space_Between_Item * (i / Number_Of_Colums))), 0f);
    }
}
