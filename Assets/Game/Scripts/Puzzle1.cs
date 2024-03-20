using UnityEngine;

public class Puzzle1 : MonoBehaviour
{
    // Array para armazenar os objetos e seus IDs
    public GameObject[] objetos;
    public int[] ids;

    // Vari�vel para rastrear o �ltimo ID destru�do
    private int ultimoIDdestruido = 0;

    void Start()
    {
        // Verifica se os arrays t�m o mesmo tamanho
        if (objetos.Length != ids.Length)
        {
            Debug.LogError("O n�mero de objetos n�o coincide com o n�mero de IDs!");
            return;
        }
    }

    public void HandleObjectCollision(GameObject objeto)
    {
        // Verifica se o objeto colidido est� na lista de objetos do puzzle
        for (int i = 0; i < objetos.Length; i++)
        {
            if (objeto == objetos[i])
            {
                // Verifica se o objeto pode ser destru�do com base no ID
                if (ids[i] == ultimoIDdestruido + 1)
                {
                    // Destr�i o objeto
                    Destroy(objeto);
                    ultimoIDdestruido = ids[i]; // Atualiza o �ltimo ID destru�do
                    Debug.Log("Objeto de ID " + ids[i] + " destru�do!");

                    // Verifica se todos os objetos foram destru�dos
                    if (ultimoIDdestruido == ids[ids.Length - 1])
                    {
                        Debug.Log("Puzzle resolvido!");
                        // Aqui voc� pode adicionar qualquer outra a��o que desejar quando o puzzle for resolvido
                    }
                }
                else
                {
                    Debug.Log("N�o � poss�vel destruir este objeto ainda. � necess�rio destruir o objeto de ID " + (ultimoIDdestruido + 1) + " primeiro.");
                }
                break;
            }
        }
    }
}
