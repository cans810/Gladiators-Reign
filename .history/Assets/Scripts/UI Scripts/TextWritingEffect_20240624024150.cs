using System.Collections;
using TMPro;
using UnityEngine;

public class TextWritingEffect : MonoBehaviour
{
    public float baseDelayBetweenCharacters = 0.2f;
    public float initialDelay = 1f;

    public TextMeshProUGUI textComponent;
    private string fullText;

    private bool isAnimating = false;
    private Coroutine currentCoroutine;

    private void Awake()
    {
        if (textComponent == null)
        {
            textComponent = GetComponent<TextMeshProUGUI>();
        }
    }

    public void AnimateText(string text)
    {
        if (isAnimating)
        {
            // If already animating, stop the current coroutine
            StopAnimating();
        }

        textComponent.text = "";
        fullText = text;
        currentCoroutine = StartCoroutine(WriteTextCoroutine());
    }

    private IEnumerator WriteTextCoroutine()
    {
        isAnimating = true;

        yield return new WaitForSeconds(initialDelay);

        float elapsedTime = 0f;
        int charIndex = 0;

        while (charIndex < fullText.Length)
        {
            elapsedTime += Time.deltaTime;
            int charsToAdd = (int)(elapsedTime / baseDelayBetweenCharacters);

            if (charsToAdd > 0)
            {
                charIndex += charsToAdd; // update the number of characters based on the elapsed time and speed.
                charIndex = Mathf.Min(charIndex, fullText.Length); // ensure we don't exceed the text length.
                textComponent.text = fullText.Substring(0, charIndex);
                elapsedTime -= charsToAdd * baseDelayBetweenCharacters; // reset the elapsed time.
            }

            yield return null;
        }

        isAnimating = false;
    }

    public void StopAnimating()
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
            isAnimating = false;
        }
    }

    // Method to check if the animation is still running
    public bool IsAnimating()
    {
        return isAnimating;
    }
}
