using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; private set; }

    public Transform startPoint; //Reference to the startting point where enemies will be spawned
    public List<Wave> waveList; // List of waves that determine the type, count, and rate of enemy

    private int enemyCount = 0;


    public void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    void Start()
    {
        // Start the enemy spawning coroutine when the game starts
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Coroutine to spawn enemies according to the wave config
    IEnumerator SpawnEnemy()
    {
        foreach(Wave wave in waveList) // Loop through each wave in the wave list
        {
            for(int i=0; i < wave.count; i++) // Spawn the number of enemies specified in the wave
            {
                // Instantiate an enemy at the start point with default rotation
                GameObject.Instantiate(wave.enemyPrefab, startPoint.position, Quaternion.identity);
                enemyCount++;
                if(i!= wave.count - 1)
                {
                    // Wait for a specified duration before spawning next enemey
                    yield return new WaitForSeconds(wave.rate);
                }
                
            }
            // wait until all enemies from the current wave are defeated before starting next wave
            while (enemyCount > 0)
            {
                yield return null;
            }
        }
        yield return null; // Couroutine is complete, yield
    }

    public void DecreaseEnemyCount()
    {
        if (enemyCount> 0)
        {
            enemyCount--;
        }
    }
}
