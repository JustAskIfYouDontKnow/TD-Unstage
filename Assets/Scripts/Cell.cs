
using UnityEngine;
public class Cell : MonoBehaviour
{
    public Material mainMaterial;
    public Material overMaterial;
    public bool isBuild;
    public Material cantBuildMaterial;

    private Spawner _spawner;

    private void Start()
    {
        _spawner = FindObjectOfType<Spawner>(); 
    }
    
    //Пока указатель мыши находится на объекте, применяем к нему заданный материал
    private void OnMouseOver()
    {
        if (isBuild == false)
        {
            GetComponent<Renderer>().material = cantBuildMaterial;
            return;

        }

        GetComponent<Renderer>().material = overMaterial;

    }
    //Если указатель не на объекте - меняем материал на базовый
    private void OnMouseExit()
    {
        GetComponent<Renderer>().material = mainMaterial;
    }

    
    private void OnMouseDown()
    {
        if(isBuild)
        {
            isBuild = false;
            //Костыль для теста
            _spawner.InstantiateObject(_spawner.canon[0], transform);
        }
    }
}
