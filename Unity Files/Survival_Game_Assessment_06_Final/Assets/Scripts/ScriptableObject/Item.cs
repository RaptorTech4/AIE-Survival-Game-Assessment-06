using UnityEngine;


[CreateAssetMenu(fileName = "New Item",menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    [Header("Modifier")]
    public int armorModifier;
    public int damageModifier;
    public int healthModifier;

    public virtual void Use()
    {

    }

    public void RemoveFromInventory()
    {
        Inventory.Instance.Remove(this);
    }

}
