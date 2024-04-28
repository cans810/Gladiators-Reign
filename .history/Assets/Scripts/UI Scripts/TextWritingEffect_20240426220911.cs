using System.Collections;
using TMPro;
using UnityEngine;

public class TextWritingEffect : MonoBehaviour
{
    public float delayBetweenCharacters = 0.005f;
    private TextMeshProUGUI textComponent;
    private string fullText;
    private string currentText = "";

    public void AnimateText(string text){
        textComponent = GetComponent<TextMeshProUGUI>();
        textComponent.text = "";
        fullText = text;

        StartCoroutine(WriteTextCoroutine());
    }

    private IEnumerator WriteTextCoroutine()
    {
        int framesPerCharacter = 2; // Adjust this value to control perceived speed (lower for faster)
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i + 1);
            textComponent.text = currentText;

            for (int j = 0; j < framesPerCharacter; j++)
            {
                yield return null; // Wait for the next frame
            }
        }
    }
}
