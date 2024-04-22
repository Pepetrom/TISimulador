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
            }
            Destroy(collision.gameObject);
            GameManager.gm.AddScore(scoreValue);
        }
    }
}
