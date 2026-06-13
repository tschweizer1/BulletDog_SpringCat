using UnityEngine;

public class TurretSpawning : MonoBehaviour, TriggerableObject
{
    public GameObject objectToSpawn;
    public void Trigger()
    {
        Instantiate(objectToSpawn, transform.position, Quaternion.identity);
    }
}
