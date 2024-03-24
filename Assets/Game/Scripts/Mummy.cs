using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mummy : MonoBehaviour
{
    public NavMeshAgent nav;
    public Transform[] waypoints;
    public int actualWaypoint = 0;
    // Update is called once per frame
    private void Start()
    {
        nav.SetDestination(waypoints[actualWaypoint].position);
    }
    void FixedUpdate()
    {
        if(Vector3.Distance(transform.position, waypoints[actualWaypoint].position) < 1)
        {
            actualWaypoint++;
            if (actualWaypoint == waypoints.Length)
            {
                actualWaypoint = 0;
            }
            nav.SetDestination(waypoints[actualWaypoint].position);
        }     
    }

}
