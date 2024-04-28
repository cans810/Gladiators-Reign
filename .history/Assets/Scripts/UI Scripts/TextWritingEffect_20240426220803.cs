using System.Collections;
using TMPro;
using UnityEngine;

public class TextWritingEffect : MonoBehaviour
{
    public float delayBetweenCharacters = 0.0000001f;
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
    float targetTimeStep = 0.01f; // Adjust for desired speed (lower for faster)
    float elapsedTime = 0f;

    for (int i = 0; i < fullText.Length; i++)
    {
        currentText = fullText.Substring(0, i + 1);
        textComponent.text = currentText;

        elapsedTime += Time.deltaTime;
        while (elapsedTime < targetTimeStep)
        {
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        elapsedTime = 0f;
    }
}
}
