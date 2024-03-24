using UnityEngine;

public class Puzzle1 : MonoBehaviour
{
    public GameObject[] objects;
    public int[] ids;
    private int lastDestroyed = 0;
    public Gate gate;

    void Start()
    {
        if (objects.Length != ids.Length)
        {
            Debug.LogError("O número de objetos não coincide com o número de IDs!");
            return;
        }
    }

    public void HandleObjectCollision(GameObject pobject)
    {
        for (int i = 0; i < ids.Length; i++)
        {
            if (pobject == objects[i])
            {
                if (ids[i] == lastDestroyed + 1)
                {
                    Destroy(pobject);
                    lastDestroyed = ids[i];
                    if (lastDestroyed == ids[ids.Length - 1])
                    {
                        Debug.Log("Puzzle resolvido!");
                        gate.Open();
                        GameManager.gm.AddScore(10);
                    }
                }
                break;
            }
        }
    }
}
