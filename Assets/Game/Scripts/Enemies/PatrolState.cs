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
        time = Time.time;
    }

    public void OnExit()
    {
    }

    public void OnUpdate()
    {
        if (Time.time > time)
        {
            dir = Random.onUnitSphere;
            time = Time.time + 1;
        }
        controller.Move(dir);
        if (controller.energy < 0)
        {
            controller.SetState(new RestState(controller));
        }
        if (controller.CanSeeTarget())
        {
            controller.roomObserver?.PlayerInRoom();
            controller.SetState(new FollowState(controller));
        }
    }
}
