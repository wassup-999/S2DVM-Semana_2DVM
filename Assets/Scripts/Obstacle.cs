using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject Prefabobstacle;
    public BoxCollider obstacleCollider;   
    public int RiseValue;
    public float DetectRange = 3;
    public Transform Enemy;

    public bool isNear = false;
    void Start()
    {

    }
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isNear = true;         
            if(DetectRange >= Vector3.Distance(transform.position, Enemy.position))
            {
                DetectEnemyNear();
            }

        }        
    }
    public void DetectEnemyNear()
    {
         Prefabobstacle.transform.position = new Vector3(transform.position.x, transform.position.y + RiseValue, transform.position.z);
    }
    

}
