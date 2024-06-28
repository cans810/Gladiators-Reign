using System.Collections;
using TMPro;
using UnityEngine;
using System;

public class TextWritingEffect : MonoBehaviour
{
    public float baseDelayBetweenCharacters = 0.2f;
    public float initialDelay = 1f;

    public TextMeshProUGUI textComponent;
    private string fullText;

    public bool finished;

    // Define events for start and end of animation
    public event Action OnTextAnimationStart;
    public event Action OnTextAnimationEnd;

    private void Awake()
    {
        if (textComponent == null)
        {
            textComponent = GetComponent<TextMeshProUGUI>();
        }

        finished = false;
    }

    public void AnimateText(string text)
    {
        textComponent.text = "";
        fullText = text;
        StartCoroutine(WriteTextCoroutine());
    }

    private IEnumerator WriteTextCoroutine()
    {
        finished = false;

        yield return new WaitForSeconds(initialDelay);

        // Invoke start event
        OnTextAnimationStart?.Invoke();

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

        finished = true;

        // Invoke end event
        OnTextAnimationEnd?.Invoke();
    }
}
