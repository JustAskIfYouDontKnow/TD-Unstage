using UnityEngine;

public class Gun : MonoBehaviour
{
    public bool rotation;
    public bool enemyFind;
    EnemyManager enemyManager;
    Transform targetEnemyTransform;
    public float viewRadius = 1f;
    public float rotationSpeed = 1f;

    private void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
    }
    void FixedUpdate()
    {
        if (enemyFind)
        {
            targetEnemyTransform = enemyManager.TakeEnemy(transform, viewRadius);
            if (targetEnemyTransform != null)
            {
                enemyFind = false;
            }
        }
        if (rotation)
        {
            if (targetEnemyTransform != null)//���� ��������� ����
            {
                if (Vector3.Distance(targetEnemyTransform.position, transform.position) < viewRadius)//���� �� � ������� �����
                {
                    Vector3 direction = targetEnemyTransform.transform.position - transform.position;//��������� ������ ��������
                    Quaternion rotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);//������������, ��������� Quaternion
                                                                                                                       // transform.rotation = Quaternion.Lerp(transform.rotation, targetEnemyTransform.rotation, Time.deltaTime * rotationSpeed);
                }
                else
                {
                    enemyFind = true;
                }
            }

        }
    }
}
