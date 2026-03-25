using UnityEngine;

public class SmallEnemySpawner : MonoBehaviour
{
    public static SmallEnemySpawner Instance;
    public GameObject smallEnemyPrefab;
    public float counter;
    public float spawnInterval = 7f;
    public int currentEnemies = 0;
    public int maxEnemies = 5;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }   

    void Start()
    {
        
    }

   
    void Update()
    {
        SpawnSmallEnemy();
        
    }
    public void SpawnSmallEnemy()
    {
            counter += Time.deltaTime;
        if (counter >= spawnInterval)
        {
                
                Instantiate(smallEnemyPrefab, transform.position, Quaternion.identity);
                currentEnemies += 1;
                counter = 0f;
        }
        for(int i = 0; i < currentEnemies; i++)
        {
            if(currentEnemies >= maxEnemies)
            {
                counter *=0;
            }
            
        }
        if(currentEnemies<=maxEnemies)
        {
            counter *= 1;
        }

    }   
}
