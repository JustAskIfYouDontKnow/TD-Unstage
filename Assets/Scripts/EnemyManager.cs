using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> enemyList;

    public void recalcEnemy()
    {
        enemyList.AddRange(FindObjectsOfType<Enemy>());
    }

    public void AddMeToArray(Enemy _enemy)
    {
        enemyList.Add(_enemy);
    }

    public void DeleteMeToArray(Enemy _enemy)
    {
        enemyList.Remove(_enemy);
    }

    public Transform TakeEnemy(Transform tGun, float radius)
    {
        foreach(var obj in enemyList)
        {
            if (Vector3.Distance
            (obj.transform.position, tGun.transform.position) <= radius)
            {
                return obj.transform;
            }
        }
        return null;
    }
}
