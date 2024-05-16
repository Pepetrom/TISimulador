using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingOverState : IScorpionInterface
{
    ScorpionStateMachine controller;
    Vector3 lookingOverPosition;
    float timeToLookOverRate;

    public LookingOverState(ScorpionStateMachine controller)
    {
        this.controller = controller;
    }

    public void OnEnter()
    {
        timeToLookOverRate = 0;
        lookingOverPosition = controller.transform.position;
        lookingOverPosition.y = 1f;
        controller.transform.position = lookingOverPosition;
        Debug.Log("Comecei a olhar");
        controller.ChangeColor(Color.yellow);
    }

    public void OnExit()
    {
        Debug.Log("Parei de olhar");
    }

    public void OnUpdate()
    {
        timeToLookOverRate += Time.deltaTime;
        Debug.Log("To olhando hein");
        if (controller.IsPlayerMoving() && controller.IsNearTarget())
        {
            controller.SetState(new FollowingState(controller));
        }
        if(controller.IsPlayerMoving() == false && timeToLookOverRate >= controller.timeToLookOver)
        {
            controller.SetState(new UnderGroundState(controller));
        }
    }
}
