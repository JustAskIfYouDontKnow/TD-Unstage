using UnityEngine;
using UnityEngine.Serialization;

public class Cell : MonoBehaviour
{
    public Material initMaterial;
    
    public Material overMaterial;
    
    public bool isBuildMaterial;
    public Material unavailableMaterial;

    private Spawner _spawner;


    private void Start()
    {
        _spawner = FindObjectOfType<Spawner>();
    }

    //Пока указатель мыши находится на объекте, применяем к нему заданный материал
    private void OnMouseOver()
    {
        if (isBuildMaterial == false)
        {
            GetComponent<Renderer>().material = unavailableMaterial;
            return;
        }

        GetComponent<Renderer>().material = overMaterial;
    }

    //Если указатель не на объекте - меняем материал на базовый
    private void OnMouseExit()
    {
        GetComponent<Renderer>().material = initMaterial;
    }


    private void OnMouseDown()
    {
        if (isBuildMaterial == false)
        {
            GetComponent<Renderer>().material = unavailableMaterial;
            return;
        }

        isBuildMaterial = false;

        //Костыль для теста
        _spawner.InstantiateObject(_spawner.canon[0], transform);
    }
}