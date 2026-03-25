using UnityEngine;
using UnityEngine.AI;
public class AgentSImpleController : MonoBehaviour
{
    public Transform Target;
    public NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //agent.SetAreaCost(0, 10);
        //agent.SetAreaCost(1, 5);
    }

    
    void Update()
    {
        if (Target != null)
        {
            agent.SetDestination(Target.position); //Setea el objetivo del agente
            agent.speed = (Random.Range(2f, 4f));
        }
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        if (agent.path == null) return;
        Vector3[] corners = agent.path.corners;
        for (int i = 0; i < corners.Length - 1; i++) 
        {
            Gizmos.DrawLine(corners[i],corners[i + 1]);
            Gizmos.DrawSphere(corners[i], 0.2f);
        }
    }
}
