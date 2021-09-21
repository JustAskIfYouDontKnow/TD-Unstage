using UnityEngine;
using UnityEngine.EventSystems;

namespace Test_scripts
{
    public class DragDropGameObject : MonoBehaviour, IDragHandler, IDropHandler
    {
        public float height;
        private Camera _mainCamera;

        [SerializeField]
        private uint _distance;

        private void Start()
        {
            if (Camera.main.GetComponent<PhysicsRaycaster>() == null)
                Debug.Log("Camera doesn't have a physics raycaster.");
            _mainCamera = Camera.main;
        }
        
        
        //Через скалярное произведение векторов, мы можем двигать наш объект по плоскости
        //При этом не важно, какой угол обзора и тип у камеры (Perspective/orthographic)
        //Объект следует строго за указателем мыши/тапа
        //На самом деле, я ваще хуй знает че тут происходит, в будущем надо этот момент оптимизировать
        //Ощущение, что можно сделать все проще не покидает меня


        public void OnDrag(PointerEventData eventData)
        {
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            var planeNormal = -_mainCamera.transform.forward;
            var t = Vector3.Dot(transform.position - ray.origin, planeNormal) / Vector3.Dot(ray.direction, planeNormal);
            var point = ray.origin + ray.direction * t;
            transform.position = new Vector3(point.x, height, point.z);
        }

        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log(("Drop"));
            if(Physics.Raycast(transform.position, Vector3.down, out var hit,_distance))
            {
                if (hit.collider.transform.GetComponent<Cell>())
                {
                    Debug.Log("hit!");
                    transform.SetParent(hit.collider.transform);
                    transform.localPosition = Vector3.zero;
                }
                else 
                {
                    transform.localPosition = Vector3.zero;
                }
            }
            
        }
        
    }
}