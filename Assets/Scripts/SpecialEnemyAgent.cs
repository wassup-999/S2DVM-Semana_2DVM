using UnityEngine;
using UnityEngine.AI;

public class SpecialEnemyAgent : MonoBehaviour
{
    public Transform Target;
    public NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Target= GameObject.FindGameObjectWithTag("Player").transform; //Busca el objeto con la etiqueta "Player" y asigna su transform como objetivo
    }

    
    void Update()
    {
        if(Target != null)
        {
            agent.SetDestination(Target.position); //Setea el objetivo del agente
            //agent.speed = (Random.Range(2f, 4f));
        }
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (agent.path == null) return;
        Vector3[] corners = agent.path.corners;
        for (int i = 0; i < corners.Length - 1; i++) 
        {
            Gizmos.DrawLine(corners[i],corners[i + 1]);
            Gizmos.DrawSphere(corners[i], 0.2f);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Destroy");
            OnDestroy();
        }
    }
    public void OnDestroy()
    {
        Destroy(gameObject);
        SpecialEnemySpawner.Instance.currentEnemies-=1;
    }
}

