using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomObserver : MonoBehaviour
{
    public EnemyAStateController[] enemies;
    public Transform[] limits;
    private void Start()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].roomObserver = this;
        }
    }
    public void PlayerInRoom()
    {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].energy = enemies[i].maxEnergy;
                enemies[i].SetState(new FollowState(enemies[i]));
            }              
    }
}
