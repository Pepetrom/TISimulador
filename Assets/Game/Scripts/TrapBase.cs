using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBase : MonoBehaviour
{
    //Temp Visual
    public TrapDanger info;
    public Animator animator;
    bool started = false, damage = false;
    private void OnTriggerStay(Collider other)
    {
        if (!started)
        {
            StartCoroutine(TrapCicle());
        }
        if (damage)
        {
            Debug.Log("MORREU");
            damage = false;
        }
    }
    public void StartDamage()
    {
        damage = true;
    }
    public void EndDamage()
    {
        damage = false;
    }
    private IEnumerator TrapCicle()
    {
        started = true;
        animator.SetTrigger("cicle1");
        for (info.actualCicle = 0; info.actualCicle < info.getCicles; info.actualCicle++)
        {
            yield return new WaitForSeconds(info.getDuration);
            animator.SetTrigger("cicle"+info.actualCicle);
        }
        info.actualCicle = 0;
        yield return new WaitForSeconds(info.getDuration);
        started = false;
    }
}
