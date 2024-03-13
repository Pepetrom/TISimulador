using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Trap", menuName = "ScriptableObjects/Traps", order = 1)]
public class TrapDanger : ScriptableObject
{
    [SerializeField] float duration = 0;
    [SerializeField] float damage = 0;
    [SerializeField] int cicles = 1;
    public int getCicles { get { return cicles; } }
    public float getDuration { get { return duration; } }

    public int actualCicle = 0;
}
