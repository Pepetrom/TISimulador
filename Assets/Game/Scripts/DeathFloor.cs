using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFloor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Morreu");
            GameManager.gm.ResetScene();
        }
        if (other.CompareTag("Moveable"))
        {
            other.GetComponent<Moveable>().Fell();
            other.transform.position = new Vector3(other.transform.position.x, -0.5f, other.transform.position.z);
        }
    }
}
