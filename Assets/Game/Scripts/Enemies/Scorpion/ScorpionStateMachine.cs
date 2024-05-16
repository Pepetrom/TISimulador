using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class ScorpionStateMachine : MonoBehaviour
{
    IScorpionInterface state;
    public Transform target;
    public float speed;
    public float underGroundTime;
    public GameObject player;
    private Rigidbody playerRb;
    public float lookingRadius;
    public float timeToLookOver;
    public GameObject mesh;

    private void Start()
    {
        playerRb = player.GetComponent<Rigidbody>();
        SetState(new UnderGroundState(this));
    }
    private void FixedUpdate()
    {
        state?.OnUpdate();
    }
    public void SetState(IScorpionInterface state)
    {
        this.state?.OnExit();
        this.state = state;
        this.state?.OnEnter();
    }
    #region Metodos Auxiliares
    public Vector3 TargetDir()
    {
        Vector3 dir = target.position - transform.position;
        return dir;
    }
    public void ScorpionMove(Vector3 dir)
    {
        transform.position += dir * speed * Time.fixedDeltaTime;
    }
    public bool IsNearTarget()
    {
        return (TargetDir().magnitude < lookingRadius);
    }
    public bool IsPlayerMoving()
    {
        if (playerRb == null) return false;
        const float movementThreshold = 0.1f;
        return playerRb.velocity.magnitude > movementThreshold;
    }
    public void ChangeColor(Color newColor)
    {
        MeshRenderer renderer = mesh.gameObject.GetComponent<MeshRenderer>();
        renderer.material.color = newColor;
    }
    #endregion
}
