using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private int count;

    [SerializeField]
    private Rect area;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private Enemy enemyPrefab;

    void Start()
    {
        for (int i=0; i< count; i++)
        {
            var enemy = Instantiate(enemyPrefab, new Vector3(
                Random.Range(area.xMin, area.xMax), 
                Random.Range(area.yMin, area.yMax)),
                Quaternion.identity);

            enemy.FleeFrom = player;
        }
    }

}
