using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] canon;
    public GameObject[] tower;

    public void InstantiateObject(GameObject obj, Transform t)
    {
        Instantiate(obj, t.position, Quaternion.identity);
    }

}

