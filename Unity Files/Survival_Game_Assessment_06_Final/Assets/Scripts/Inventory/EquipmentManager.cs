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

    public Equipment[] defaultEquipment;

    Equipment[] currentEquipment;
    public SkinnedMeshRenderer targetMesh;
    public Transform rightHandTargetMesh;
    public Transform leftHandTargetMesh;
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
        EquipDefaultItems();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }
    }

    #region Equipment
    public void Equip(Equipment newEquipment)
    {
        int slotIndex = (int)newEquipment.equipmentSlot;
        Equipment oldEquipment = Unequip(slotIndex);

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newEquipment, oldEquipment);
        }

        SetEquipmentBlendShapes(newEquipment, 100);

        currentEquipment[slotIndex] = newEquipment;
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newEquipment.mesh);
        
        newMesh.transform.parent = targetMesh.transform;
        newMesh.bones = targetMesh.bones;

        if (newEquipment.handHeld)
        {

            if (newEquipment.rightHand)
            {
                newMesh.rootBone = rightHandTargetMesh;
            }
            else if (newEquipment.leftHand)
            {
                newMesh.rootBone = leftHandTargetMesh;
            }
        }
        else
        {
            newMesh.rootBone = targetMesh.rootBone;

        }



        currentMeshes[slotIndex] = newMesh;
    }

    public Equipment Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {

            if (currentMeshes[slotIndex] != null)
            {
                Destroy(currentMeshes[slotIndex].gameObject);
            }

            Equipment oldEquipment = currentEquipment[slotIndex];
            //SetEquipmentBlendShapes(oldEquipment, 0);


            inventory.Add(oldEquipment);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldEquipment);
            }

            return oldEquipment;

        }
        return null;
    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
        EquipDefaultItems();
    }
    #endregion Equipment


    void EquipDefaultItems()
    {
        foreach (Equipment item in defaultEquipment)
        {
            Equip(item);
        }
    }

    void SetEquipmentBlendShapes(Equipment item, int weight)
    {

        foreach (EquipmentMeshRegion blendShape in item.coverdMeshRegions)
        {
            targetMesh.SetBlendShapeWeight((int)blendShape, (float)weight);
        }
    }

}
