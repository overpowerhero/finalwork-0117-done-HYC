using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    //HYC 1/09
    // enemyPrefab[enemy_indexer]
    public GameObject[] enemyPrefab;
    // public GameObject enemyPrefab;


    public int enemyCount;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        


    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Animal>().Length;
        if (enemyCount == 0) 
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber); 
        }
    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        int enemy_indexer = Random.Range(0, enemyPrefab.Length);//這邊到時問老師，如何一次產生不同種雞
        for (int i = 0; i < enemiesToSpawn ; i++)
        {
            Instantiate(enemyPrefab[enemy_indexer], GenerateSpawnPosition(),
            enemyPrefab[enemy_indexer].transform.rotation);
           
            //Instantiate(enemyPrefab, GenerateSpawnPosition(),
            //enemyPrefab.transform.rotation);
        }
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-30, 30);
        float spawnPosZ = Random.Range(-55, 55);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
