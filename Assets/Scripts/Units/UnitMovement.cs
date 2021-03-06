using UnityEngine;
using UnityEngine.AI;
using Mirror;

public class UnitMovement : NetworkBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    #region Server
    [ServerCallback]
    private void Update()
    {
        if (!agent.hasPath) { return; }
        if (agent.remainingDistance > agent.stoppingDistance) { return; }
        agent.ResetPath();
    }

    [Command]
    public void CmdMove(Vector3 position)
    {
        if (!NavMesh.SamplePosition(position, out NavMeshHit hit, 1f, NavMesh.AllAreas)) { return; }

        agent.SetDestination(hit.position);
    }

    #endregion

}
