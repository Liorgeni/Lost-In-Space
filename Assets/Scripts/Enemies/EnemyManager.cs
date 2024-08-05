using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public GameObject enemy;
    
    private float randomXPos;

    public int enemiesNumber = 5;
    public int count = 5;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        count = 5;
        CreateEnemies(count);
    }

    void Update()
    {
        if (count <= 0)
        {
            enemiesNumber += 1;
            CreateEnemies(enemiesNumber);
            count = enemiesNumber;
        }
    }

    public void CreateEnemies(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            float randomXPos = Random.Range(-8f, 8f);
            Instantiate(enemy, new Vector2(randomXPos, 3), transform.rotation);
        }
    }
}
