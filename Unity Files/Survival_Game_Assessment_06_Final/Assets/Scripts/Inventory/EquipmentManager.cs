using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager Instance;

    private void Awake()
    {
        if (Instance != null)
            return;

        Instance = this;
    }
    #endregion

    Equipment[] currentEquipment;
    public SkinnedMeshRenderer targetMesh;
    SkinnedMeshRenderer[] currentMeshes;

    public delegate void OnEquipmentChanged(Equipment newEquipment, Equipment oldEquipment);
    public event OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;

    private void Start()
    {
        inventory = Inventory.Instance;

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
        currentMeshes = new SkinnedMeshRenderer[numSlots];
    }

    public void Equip (Equipment newEquipment)
    {
        int slotIndex = (int)newEquipment.equipmentSlot;

        Equipment oldEquipment = null;

        if(currentEquipment[slotIndex] != null)
        {
            oldEquipment = currentEquipment[slotIndex];
            inventory.Add(oldEquipment);
        }

        if(onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newEquipment,oldEquipment);
        }

        currentEquipment[slotIndex] = newEquipment;

        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newEquipment.mesh);
        newMesh.transform.parent = targetMesh.transform;

        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;
        currentMeshes[slotIndex] = newMesh;
    }

    public void Unequip(int slotIndex)
    {
        if(currentEquipment[slotIndex] != null)
        {

            if(currentMeshes[slotIndex] != null)
            {
                Destroy(currentMeshes[slotIndex].gameObject);
            }

            Equipment oldEquipment = currentEquipment[slotIndex];
            inventory.Add(oldEquipment);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldEquipment);
            }
        }
    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }
    }

}
