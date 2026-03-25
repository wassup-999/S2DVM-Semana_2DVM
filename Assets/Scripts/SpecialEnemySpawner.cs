using UnityEngine;

public class SpecialEnemySpawner : MonoBehaviour
{
    public static SpecialEnemySpawner Instance;
    public GameObject specialEnemyPrefab;
    public float counter;
    public float spawnInterval = 10f;
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
        SpawnEnemies();
    }
    public void SpawnEnemies()
    {
        counter+= Time.deltaTime;
        if (counter >= spawnInterval)
        {
            Instantiate(specialEnemyPrefab, transform.position, Quaternion.identity);
            currentEnemies += 1;
            counter = 0f;
        }
        for(int i = 0; i<currentEnemies; i++)
        {
            if (currentEnemies >= maxEnemies)
            {
                counter *= 0;
            }
        }
        if(currentEnemies <= maxEnemies)
        {
            counter *= 1;
        }
    }
}
