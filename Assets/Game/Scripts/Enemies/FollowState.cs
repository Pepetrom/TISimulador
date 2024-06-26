using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : IEnemyAController
{
    EnemyAStateController controller;
    float time;
    Vector3 dir;
    public FollowState(EnemyAStateController controller)
    {
        this.controller = controller;
    }
    public void OnEnter()
    {
    }

    public void OnExit()
    {
    }

    public void OnUpdate()
    {
        controller.Move(controller.TargetDir().normalized);
        if(controller.energy < 0)
        {
            controller.SetState(new RestState(controller));
        }
    }
}
