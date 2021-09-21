using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class Cell : MonoBehaviour, IPointerClickHandler, IDropHandler
{
    public Material initMaterial;
    
    public Material overMaterial;
    
    public Material unavailableMaterial;
    
    public bool isBuild;

    private Spawner _spawner;


    private void Start()
    {
        _spawner = FindObjectOfType<Spawner>();
    }

    //Пока указатель мыши находится на объекте, применяем к нему заданный материал
   private void OnMouseOver()
    {
        if (!isBuild)
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
   

    public void OnPointerClick(PointerEventData eventData)
    {
       
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!isBuild)
        {
            GetComponent<Renderer>().material = unavailableMaterial;
            return;
        }
        
        if (eventData.pointerDrag != null)
        {
            Debug.Log("Drop");
            var obj = eventData.pointerDrag.GetComponent<Item>();
            _spawner.InstantiateObject(obj, transform);
            Destroy(obj.gameObject);
        }
        isBuild = false;
    }
}