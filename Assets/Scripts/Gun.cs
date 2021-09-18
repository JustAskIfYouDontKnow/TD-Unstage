using UnityEngine;

public class Gun : MonoBehaviour
{
    public bool isRotation;
    
    public bool isKeepLookingEnemy;
    
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
        if (isKeepLookingEnemy)
        {
            targetEnemyTransform = enemyManager.TakeEnemy(transform, viewRadius);
            if (targetEnemyTransform != null)
            {
                isKeepLookingEnemy = false;
                return;
            }
        }

        if (targetEnemyTransform != null)
        {
            if (Vector3.Distance(targetEnemyTransform.position, transform.position) < viewRadius) 
            {
                var direction = targetEnemyTransform.transform.position - transform.position; //��������� ������ ��������
                var rotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed); 
                // transform.rotation = Quaternion.Lerp(transform.rotation, targetEnemyTransform.rotation, Time.deltaTime * rotationSpeed);
            }
            else
            {
                isKeepLookingEnemy = true;
            }
        }
    }
    
}
