using System.Collections;
using TMPro;
using UnityEngine;

public class TextWritingEffect : MonoBehaviour
{
    public float delayBetweenCharacters = 0.04f;
    public float spaceDelayMultiplier = 10f; // Additional delay multiplier for spaces
    private TextMeshProUGUI textComponent;
    private string fullText;
    private string currentText = "";

    private void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        fullText = textComponent.text;
        textComponent.text = "";
        StartCoroutine(WriteText());
    }

    private IEnumerator WriteText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i + 1);
            textComponent.text = currentText;

            // Check if the current character is a space
            if (fullText[i] == ' ')
                yield return new WaitForSeconds(delayBetweenCharacters * spaceDelayMultiplier);
            else
                yield return new WaitForSeconds(delayBetweenCharacters);
        }
    }
}
