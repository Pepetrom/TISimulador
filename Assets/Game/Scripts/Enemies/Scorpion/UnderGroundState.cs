using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderGroundState : IScorpionInterface
{
    ScorpionStateMachine controller;
    float time;
    float underGroundTimeRate;
    Vector3 dir;
    Vector3 underGroundPosition;
    public UnderGroundState(ScorpionStateMachine controller)
    {
        this.controller = controller;
    }

    public void OnEnter()
    {
        Debug.Log("Entrei na terra");
        underGroundPosition = controller.transform.position;
        underGroundPosition.y = -0.1f;
        controller.transform.position = underGroundPosition;
        time = Time.time;
        underGroundTimeRate = 0;
        controller.ChangeColor(Color.blue);
    }

    public void OnExit()
    {
        Debug.Log("Saí da terra");
    }

    public void OnUpdate()
    {
        underGroundTimeRate += Time.deltaTime;
        if(Time.time > time)
        {
            dir = Random.onUnitSphere;
            dir.y = 0;
            time = Time.time + 1;
        }
        controller.ScorpionMove(dir);
        if(underGroundTimeRate >= controller.underGroundTime)
        {
            controller.SetState(new LookingOverState(controller));
        }
    }
}
