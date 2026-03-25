using UnityEngine;
using UnityEngine.AI;

public class FlyingEnemyAgent : MonoBehaviour
{
    public Transform Target;
    private NavMeshAgent agent;
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();           
    }

    
    void Update()
    {
        if(Target != null)
        {
            agent.SetDestination(Target.position);
        }
    }

    
}
