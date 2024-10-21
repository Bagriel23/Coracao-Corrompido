using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MonologueScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI monologueText;
    [SerializeField] private float typingSpeed = 0.05f;

    private string fullText = "A floresta, nossa mae, grita em agonia...\n\n" +
                              "Queimadas sem fim destruiram suas raizes, e agora, das cinzas, um mal acordou.\n\n" +
                              "Um espirito sem nome, forjado no fogo, alimentado pelo odio, corrompeu cada folha, cada sombra.\n\n" +
                              "Me chamo Isaia. Sou filha desta terra. Os espiritos ancestrais me abençoaram com a forca para lutar.\n\n" +
                              "Se eu falhar, tudo o que resta da Amazonia sera consumido.\n\n" +
                              "Eu nao posso falhar.";
    void Start()
    {
        monologueText.text = "";
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (char letter in fullText.ToCharArray())
        {
            monologueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Terrain");
    }
}
