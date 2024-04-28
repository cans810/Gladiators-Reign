using System.Collections;
using TMPro;
using UnityEngine;

public class TextWritingEffect : MonoBehaviour
{
    public float delayBetweenCharacters = 0.005f;
    public float spaceDelay = 0.007f; // Additional delay multiplier for spaces
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
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i + 1);
            textComponent.text = currentText;

            // Check if the current character is a space
            yield return new WaitForSeconds(delayBetweenCharacters);
        }
    }
}
