using UnityEngine;

public class Puzzle1 : MonoBehaviour
{
    // Array para armazenar os objetos e seus IDs
    public GameObject[] objetos;
    public int[] ids;

    // Variável para rastrear o último ID destruído
    private int ultimoIDdestruido = 0;

    void Start()
    {
        // Verifica se os arrays têm o mesmo tamanho
        if (objetos.Length != ids.Length)
        {
            Debug.LogError("O número de objetos não coincide com o número de IDs!");
            return;
        }
    }

    public void HandleObjectCollision(GameObject objeto)
    {
        // Verifica se o objeto colidido está na lista de objetos do puzzle
        for (int i = 0; i < objetos.Length; i++)
        {
            if (objeto == objetos[i])
            {
                // Verifica se o objeto pode ser destruído com base no ID
                if (ids[i] == ultimoIDdestruido + 1)
                {
                    // Destrói o objeto
                    Destroy(objeto);
                    ultimoIDdestruido = ids[i]; // Atualiza o último ID destruído
                    Debug.Log("Objeto de ID " + ids[i] + " destruído!");

                    // Verifica se todos os objetos foram destruídos
                    if (ultimoIDdestruido == ids[ids.Length - 1])
                    {
                        Debug.Log("Puzzle resolvido!");
                        // Aqui você pode adicionar qualquer outra ação que desejar quando o puzzle for resolvido
                    }
                }
                else
                {
                    Debug.Log("Não é possível destruir este objeto ainda. É necessário destruir o objeto de ID " + (ultimoIDdestruido + 1) + " primeiro.");
                }
                break;
            }
        }
    }
}
