
using UnityEngine;
public class Cell : MonoBehaviour
{
    public Material MainMaterial;
    public Material OverMaterial;
    public bool CanBuild;
    public Material CantBildMaterial;

    private Spawner spawner;

    private void Start()
    {
        spawner = FindObjectOfType<Spawner>(); 
    }
    
    //Пока указатель мыши находится на объекте, применяем к нему заданный материал
    private void OnMouseOver()
    {
        if (CanBuild)
            GetComponent<Renderer>().material = OverMaterial;
        
        else
        {
            GetComponent<Renderer>().material = CantBildMaterial;
        }
    }
    //Если указатель не на объекте - меняем материал на базовый
    private void OnMouseExit()
    {
        GetComponent<Renderer>().material = MainMaterial;
    }

    
    private void OnMouseDown()
    {
        if(CanBuild)
        {
            CanBuild = false;
            //Костыль для теста
            spawner.InstantiateObject(spawner.canon[0], transform);
        }
    }
}
