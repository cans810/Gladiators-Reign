using System.Collections;
using TMPro;
using UnityEngine;

public class TextWritingEffect : MonoBehaviour
{
    public float delayBetweenCharacters = 0.1f;
    public float spaceDelayMultiplier = 0.5f; // Additional delay multiplier for spaces
    private Texh textComponent;
    private string fullText;
    private string currentText = "";

    private void Start()
    {
        textComponent = GetComponent<TMP_Text>();
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
