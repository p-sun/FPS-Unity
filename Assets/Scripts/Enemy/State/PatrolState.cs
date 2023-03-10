using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    public int waypointIndex = -1; // Start at -1, b/c NavMeshAgent.remainingDistance starts at 0
    public float timeToWait = 1f;
    private float waitTimer;

    public override void Enter()
    {
    }

    public override void Perform()
    {
        _PatrolCycle();
    }

    public override void Exit()
    {
    }

    private void _PatrolCycle()
    {
        if (enemy.Agent.remainingDistance < 0.2f)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer > timeToWait)
            {
                List<Transform> waypoints = enemy.path.waypoints;
                waypointIndex = (waypointIndex + 1) % waypoints.Count;
                enemy.Agent.SetDestination(waypoints[waypointIndex].position);
                waitTimer = 0;
            }
        }
    }
}
