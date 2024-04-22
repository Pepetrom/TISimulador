using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomObserver : MonoBehaviour
{
    public EnemyAStateController[] enemies;
    private void Start()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].roomObserver = this;
        }
    }
    public void PlayerInRoom()
    {
        if (GameManager.gm.cursed)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].energy = enemies[i].maxEnergy * 2;
                enemies[i].SetState(new FollowState(enemies[i]));
            }         
        }
        else
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].energy = enemies[i].maxEnergy;
                enemies[i].SetState(new FollowState(enemies[i]));
            }
        }        
    }
}
