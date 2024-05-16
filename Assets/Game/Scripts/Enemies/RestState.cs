using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestState : IEnemyAController
{
    EnemyAStateController controller;
    float time;
    
    public RestState(EnemyAStateController controller)
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
        controller.RechargeEnergy();
        if(controller.energy >= controller.maxEnergy)
        {
            controller.SetState(new PatrolState(controller));
        }
    }
}
