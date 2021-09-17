using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyManager enemyManager;
    private PointManager pointManager;
    public Transform nextPoint;


    public float speed;
    public float hp = 100f;

    public bool walk;
    public bool rotation;
    int wayIndex;
    private void Start()
    {
        pointManager = FindObjectOfType<PointManager>();
        enemyManager = FindObjectOfType<EnemyManager>();

        enemyManager.AddMeToArray(this);
    }


    void FixedUpdate()
    {

        nextPoint = pointManager.GetNextPoint(wayIndex);//����� ��������� �������� PointManager

        if (transform.position == nextPoint.position)//���� ���� ������� == ������� ���������
        {
           wayIndex++;
        }//���� ���������

        if (wayIndex == pointManager.childCount)
        {
            enemyManager.DeleteMeToArray(this);
            Destroy(gameObject);
        }//���� ����� �� ����� - ������

        if (rotation)
        {
            Vector3 targetRotation = nextPoint.position - transform.position;//��������� ������ ��������
            transform.rotation = Quaternion.LookRotation(targetRotation*Time.deltaTime);//������������, ��������� Quaternion
        }

        if (walk)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPoint.position, speed * Time.deltaTime);//���� � ���������
        }

    }
}
