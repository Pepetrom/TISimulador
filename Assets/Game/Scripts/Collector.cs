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
            Destroy(collision.gameObject);
            GameManager.gm.AddScore(scoreValue);
        }
    }
}
