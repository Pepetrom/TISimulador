using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public int scoreValue;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Coin"))
        {
            if (collision.collider.GetComponent<Treasure>().cursed)
            {
                GameManager.gm.cursed = true;
                GameManager.gm.anubisRoom.enemies[0].speed = 6;
                GameManager.gm.anubisRoom.enemies[1].speed = 6;
            }
            Destroy(collision.gameObject);
            GameManager.gm.AddScore(scoreValue);
        }
    }
}
