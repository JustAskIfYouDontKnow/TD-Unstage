using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform lookAtObject;
    private void FixedUpdate()
    {
        transform.LookAt(lookAtObject);
    }
}
