using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> enemies;

    public void recalcEnemy()
    {
        enemies.AddRange(FindObjectsOfType<Enemy>());
    }

    public void AddMeToArray(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    public void DeleteMeToArray(Enemy enemy)
    {
        enemies.Remove(enemy);
    }

    public Transform TakeEnemy(Transform gunTransform, float radius)
    {
        foreach(var enemy in enemies)
        {
            if (Vector3.Distance(enemy.transform.position, gunTransform.transform.position) <= radius)
            {
                return enemy.transform;
            }

            return null;
        }
        return null;
    }
}
