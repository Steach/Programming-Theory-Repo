using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject[] spawnPositionOdjects;
    [SerializeField] private GameObject[] playerSpawnPosition;
    [SerializeField] private GameObject player;
    private Vector3 spawnPosition;
    private Quaternion spawnRotation;
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
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, spawnRotation);

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
        spawnRotation = spawnPositionOdjects[id].transform.rotation;
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

    private void PlayerSpawner()
    {
        int spawnPlace = Random.Range(0, playerSpawnPosition.Length);
        player.transform.position = playerSpawnPosition[spawnPlace].transform.position;
        player.transform.rotation = playerSpawnPosition[spawnPlace].transform.rotation;
    }
}
