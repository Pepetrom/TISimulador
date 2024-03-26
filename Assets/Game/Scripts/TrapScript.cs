using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    bool canDie;
    public Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Activate();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && canDie)
        {
            PlayerController.pc.Die();
        }
    }
    public void Activate()
    {
        animator.SetTrigger("Activate");
    }
    public void StartDamage()
    {
        canDie = true;
    }
    public void EndDamage()
    {
        canDie = false;
    }
}
