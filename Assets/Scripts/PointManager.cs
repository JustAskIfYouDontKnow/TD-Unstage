using UnityEngine;

public class PointManager : MonoBehaviour
{
    public Transform[] ways;
    private int[] wayIndex;
    public int childCount;
    public bool Draw;
    

    void Start()
    {
        childCount = transform.childCount;//Ищем всех детей на объекте, у которого висит этот скрипт
        ways = new Transform[childCount];//Объявляем размер массивов
        wayIndex = new int[childCount];

        for (int i = 0; i < childCount; i++)
        {
            wayIndex[i] = transform.GetChild(i).GetComponent<Point>().index;//Берем индекс вейпоинта
            ways[i] = transform.GetChild(wayIndex[i]);//Передаем в наш массив вейпоинтов индекс вейпотинта
        }

        if (Draw)
            DrawLine();
    }
    void DrawLine()
    {
        for (int i = 0; i < childCount - 1; i++)
        {
            Debug.DrawLine(ways[i].transform.position, ways[i + 1].transform.position, Color.magenta, 100);
        }
    }

    public Transform GetNextPoint(int wayIndex)
    {
        return ways[wayIndex];
    }
    
}
