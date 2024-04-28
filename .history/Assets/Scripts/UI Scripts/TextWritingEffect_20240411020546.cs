using System.Collections;
using TMPro;
using UnityEngine;

public class TextWritingEffect : MonoBehaviour
{
    public float delayBetweenCharacters = 0.02f;
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
    float accumulatedDelay = 0f;

    for (int i = 0; i < fullText.Length; i++)
    {
        currentText = fullText.Substring(0, i + 1);
        textComponent.text = currentText;

        // Check if the current character is a space and add extra delay
        if (fullText[i] == ' ')
            accumulatedDelay += delayBetweenCharacters * spaceDelayMultiplier;
        else
            accumulatedDelay += delayBetweenCharacters;

        // Wait for the accumulated delay
        yield return new WaitForSeconds(accumulatedDelay);
    }
}

}
