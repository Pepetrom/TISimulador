using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyAController
{
    EnemyAStateController controller;
    float time;
    Vector3 dir;
    public PatrolState(EnemyAStateController controller)
    {
        this.controller = controller;
    }
    public void OnEnter()
    {
        Debug.Log("Start Patrol");
        time = Time.time;
    }

    public void OnExit()
    {
    }

    public void OnUpdate()
    {
        if(Time.time > time)
        {
            dir = Random.onUnitSphere;
            dir.y = 0;
            time = Time.time + 1;
        }
        controller.Move(dir);
        if(controller.energy < 0)
        {
            controller.SetState(new RestState(controller));
        }
        if (controller.CanSeeTarget())
        {
            controller.SetState(new FollowState(controller));
        }
        Debug.Log("Patrolling");
    }
}
