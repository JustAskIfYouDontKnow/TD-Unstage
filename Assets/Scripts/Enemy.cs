using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyManager _enemyManager;
    private PointManager _pointManager;
    public Transform nextPoint;


    public float speed;
    public float hp = 100f;

    public bool isWalk;
    public bool isRotation;
    private int _wayIndex;
    
    
    private void Start()
    {
        _pointManager = FindObjectOfType<PointManager>();
        _enemyManager = FindObjectOfType<EnemyManager>();

        _enemyManager.AddMeToArray(this);
    }


    void FixedUpdate()
    {
        nextPoint = _pointManager.GetNextPoint(_wayIndex);

        if (transform.position == nextPoint.position)
        {
           _wayIndex++;
        }

        if (_wayIndex == _pointManager.childCount)
        {
            _enemyManager.DeleteMeToArray(this);
            Destroy(gameObject);
        }

        if (isRotation)
        {
            Vector3 targetRotation = nextPoint.position - transform.position;
            transform.rotation = Quaternion.LookRotation(targetRotation*Time.deltaTime);
        }

        if (isWalk)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPoint.position, speed * Time.deltaTime);
        }

    }
}
