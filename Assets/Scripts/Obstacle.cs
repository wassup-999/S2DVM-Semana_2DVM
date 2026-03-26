using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject Prefabobstacle;
    public BoxCollider obstacleCollider;
    public int RiseValue;
    public int GetDownValue;
    public bool isRising = false;
    
    //Ibas a implementar un mecanismo de cuando se eleva se quede por un rato y luego vuelva a su posicion inicial  
    public float counter;
    public float TimegetDown = 4;
   
    void Start()
    {

    }
    void Update()
    {
        ObstacleMechanics();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + RiseValue, transform.position.z);
            isRising = true;
        }        
    }
    public void ObstacleMechanics()
    {
        if (isRising)
        {
            counter += Time.deltaTime;
            if (counter >= TimegetDown)
            {
                Prefabobstacle.transform.position = new Vector3(transform.position.x, transform.position.y + GetDownValue, transform.position.z);
                counter = 0;
                isRising = false;
            }
            
        }
            
    }
}
