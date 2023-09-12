using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private Vector3 spawnPosition;
    private float spawnLimitPos = 40;
    private float yPos = 0.05f;
    private int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindEnemies();
    }

    private void SpawnEnemy()
    {
        RandomizePosition();
        Instantiate(enemy, spawnPosition, enemy.transform.rotation);
    }
    private void RandomizePosition()
    {
        float xRandPos = Random.Range(-spawnLimitPos, spawnLimitPos);
        float zRandPos = Random.Range(-spawnLimitPos, spawnLimitPos);
        spawnPosition = new Vector3(xRandPos, yPos, zRandPos);
    }

    private void FindEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("TargetBody");
        enemyCount = enemies.Length;
        if (enemyCount <= 0)
        {
            SpawnEnemy();
        }
    }
}
