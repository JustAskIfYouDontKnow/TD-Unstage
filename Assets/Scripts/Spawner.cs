using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] canon;
    public GameObject[] tower;

    
    //Метод, который принимает в себя объект и его параметры,
    //для последующего создания на сцене
    public void InstantiateObject(GameObject obj, Transform t)
    {
        Instantiate(obj, t.position, Quaternion.identity);
    }

}

