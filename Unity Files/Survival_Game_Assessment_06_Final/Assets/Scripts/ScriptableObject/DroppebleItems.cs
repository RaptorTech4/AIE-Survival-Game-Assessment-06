using UnityEngine;

[CreateAssetMenu(fileName = "New Droppable Objects", menuName = "Inventory/Droppable Objects")]
public class DroppebleItems : ScriptableObject
{

    public GameObject[] droppableObjects;

    public void SpawnRandomObject(Transform SpawnLocation)
    {
        int i = Random.Range(0, droppableObjects.Length - 1);

        Instantiate(droppableObjects[i], SpawnLocation.position,SpawnLocation.rotation);
    }
}
