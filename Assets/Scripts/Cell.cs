using System.Collections;
using System.Collections.Generic;
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

    private void OnMouseOver()
    {
        if (CanBuild)
            GetComponent<Renderer>().material = OverMaterial;
        else
        {
            GetComponent<Renderer>().material = CantBildMaterial;
        }
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material = MainMaterial;
    }

    private void OnMouseDown()
    {
        if(CanBuild)
        {
            CanBuild = false;
            spawner.InstantiateObject(spawner.canon[0], transform);
        }
    }

    

}
