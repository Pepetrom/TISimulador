using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingState : IScorpionInterface
{
    ScorpionStateMachine controller;
    public FollowingState(ScorpionStateMachine controller)
    {
        this.controller = controller;
    }
    public void OnEnter()
    {
        controller.ChangeColor(Color.red);
    }

    public void OnExit()
    {
        Debug.Log("Parei de te ver");
    }

    public void OnUpdate()
    {
        controller.ScorpionMove(controller.TargetDir().normalized);
        if(!controller.IsNearTarget())
        {
            controller.SetState(new UnderGroundState(controller));
        }
    }
}
