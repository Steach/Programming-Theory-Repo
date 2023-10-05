using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private Vector3 spawnPosition;
    private float spawnLimitPos = 40;
    private Quaternion spawnRotation;
    private float yPos = 0;
    private int enemyCount;
    private int id = 0;
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
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, RandomRotation());

        Enemy enemy = newEnemy.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.GetID(id);
            id++;
        }
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
        if (enemyCount <= 1)
        {
            SpawnEnemy();
        }
    }

    private Quaternion RandomRotation()
    {
        float spawnPositionY = Random.Range(-1, 1);
        spawnRotation = new Quaternion(0, spawnPositionY, 0, 1);
        return spawnRotation;
    }

    /*public void IdentificationEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("TargetBody");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<Enemy>();
            int id = enemy.
        }
    }*/
}
