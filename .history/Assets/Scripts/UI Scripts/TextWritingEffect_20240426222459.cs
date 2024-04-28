using System.Collections;
using TMPro;
using UnityEngine;

public class TextWritingEffect : MonoBehaviour
{
    [Tooltip("Base delay in seconds between character updates.")]
    public float baseDelayBetweenCharacters = 0.05f; // This is the slowest speed.

    [Tooltip("Factor to speed up the text display.")]
    public int speedMultiplier = 1; // Increase this to show more characters per frame.

    private TextMeshProUGUI textComponent;
    private string fullText;

    private void Awake() {
        textComponent = GetComponent<TextMeshProUGUI>();
    }

    public void AnimateText(string text) {
        textComponent.text = "";
        fullText = text;
        StartCoroutine(WriteTextCoroutine());
    }

    private IEnumerator WriteTextCoroutine()
    {
        float elapsedTime = 0f;
        int charIndex = 0;

        while (charIndex < fullText.Length)
        {
            elapsedTime += Time.deltaTime;
            int charsToAdd = (int)(elapsedTime / (baseDelayBetweenCharacters / speedMultiplier));

            if (charsToAdd > 0) {
                charIndex += charsToAdd; // Update the number of characters based on the elapsed time and speed.
                charIndex = Mathf.Min(charIndex, fullText.Length); // Ensure we don't exceed the text length.
                textComponent.text = fullText.Substring(0, charIndex);
                elapsedTime -= charsToAdd * (baseDelayBetweenCharacters / speedMultiplier); // Reset the elapsed time.
            }

            yield return null; // Wait until next frame
        }
    }
}