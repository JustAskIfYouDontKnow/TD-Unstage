using UnityEngine;

public class Spawner : MonoBehaviour
{
    public void InstantiateObject(Item item, Transform t)
    {
        var prefab = Resources.Load(item.path+item.prefabName);
        Instantiate(prefab, t.position, Quaternion.identity);
    }

}

