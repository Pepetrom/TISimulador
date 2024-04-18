using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAStateController : MonoBehaviour
{
    IEnemyAController state;
    public Transform target;
    public float speed;
    public float energy;
    public float maxEnergy;
    [SerializeField] float recharbleRate;
    [SerializeField] float maxDistancetoSee;

    private void Start()
    {
        SetState(new PatrolState(this));
        energy = maxEnergy;
    }
    private void FixedUpdate()
    {
        state?.OnUpdate();
    }
    public void SetState(IEnemyAController state)
    {
        this.state?.OnExit();
        this.state = state;
        this.state.OnEnter();
    }
    public void Move(Vector3 dir)
    {
        energy -= Time.fixedDeltaTime;
        transform.position += dir * speed * Time.fixedDeltaTime;
    }
    public float RechargeEnergy()
    {
        return energy += Time.fixedDeltaTime * recharbleRate;
    }
    public Vector3 TargetDir()
    {
        Vector3 dir = target.position - transform.position;
        return dir;
    }
    public bool CanSeeTarget()
    {
        return (TargetDir().magnitude < maxDistancetoSee);
    }

}
