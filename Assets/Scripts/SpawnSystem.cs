using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject[] spawnPositionOdjects;
    [SerializeField] private GameObject[] playerSpawnPosition;
    [SerializeField] private GameObject player;
    private float spawnLimitPos = 40;
    private Vector3 spawnPosition;
    private Quaternion spawnRotation;
    private float yPos = 0;
    private int enemyCount;
    private int id = 0;
    private bool spawnedAllEnemies = false;
    // Start is called before the first frame update
    void Start()
    {
        PlayerSpawner();
    }

    // Update is called once per frame
    void Update()
    {
        FindEnemies();
    }

    private void SpawnEnemy()
    {
        GetSpawnPosition();
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, RandomRotation());

        Enemy enemy = newEnemy.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.GetID(id);
            id++;
        }
    }

    private void GetSpawnPosition()
    {
        spawnPosition = spawnPositionOdjects[id].transform.position;
    }

    private void FindEnemies()
    {
        if(!spawnedAllEnemies)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("TargetBody");
            enemyCount = enemies.Length;
            if (enemyCount < spawnPositionOdjects.Length)
            {
                SpawnEnemy();
            }
            else
            {
                spawnedAllEnemies = true;
            }
        }
    }

    private Quaternion RandomRotation()
    {
        float spawnPositionY = Random.Range(-1, 1);
        spawnRotation = new Quaternion(0, spawnPositionY, 0, 1);
        return spawnRotation;
    }

    private void PlayerSpawner()
    {
        int spawnPlace = Random.Range(0, playerSpawnPosition.Length);
        player.transform.position = playerSpawnPosition[spawnPlace].transform.position;
    }
}
