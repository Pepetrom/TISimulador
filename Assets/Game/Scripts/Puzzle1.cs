using UnityEngine;

public class Puzzle1 : MonoBehaviour
{
    public GameObject[] objects;
    public int[] ids;
    private int lastDestroyed = 0;

    void Start()
    {
        if (objects.Length != ids.Length)
        {
            return;
        }
    }

    public void HandleObjectCollision(GameObject pobject)
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (pobject == objects[i])
            {
                if (ids[i] == lastDestroyed + 1)
                {
                    Destroy(pobject);
                    lastDestroyed = ids[i]; 
                    if (lastDestroyed == ids[ids.Length - 1])
                    {
                        Debug.Log("AHHHH VAI A MERDA, DEU CERTO PORRA!");
                    }
                }
                break;
            }
        }
    }
}
