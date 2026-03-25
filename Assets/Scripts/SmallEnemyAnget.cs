using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;
public class SmallEnemyAnget : MonoBehaviour
{
    public Transform Target;
    public NavMeshAgent agent;
    
    void Start()
    {
        RandomStats();
        GetComponent<NavMeshAgent>();
        Target = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    
    void Update()
    {
        if(!agent.hasPath)
        {
            print("No existe cmaino");
        }
        if(Target != null)
        {
            agent.SetDestination(Target.position);
        }
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (agent.path == null) return;
        Vector3[] corners = agent.path.corners;
        for (int i = 0; i < corners.Length - 1; i++)
        {
            Gizmos.DrawLine(corners[i], corners[i + 1]);
            Gizmos.DrawSphere(corners[i], 0.2f);
        }       
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnDestroy();
            SmallEnemySpawner.Instance.currentEnemies-=1;
        }
    }
    public void OnDestroy()
    {
       Destroy(gameObject);     
    }
    
    public void RandomStats()
    {
        agent.speed = (Random.Range(1.5f, 4f));
        agent.acceleration = (Random.Range(4f, 8f));
        agent.angularSpeed = (Random.Range(120f, 360f));
        agent.stoppingDistance = (Random.Range(0.5f, 1f));

    }
}
