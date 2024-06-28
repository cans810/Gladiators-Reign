using System.Collections;
using TMPro;
using UnityEngine;

public class TextWritingEffect : MonoBehaviour
{
    public float baseDelayBetweenCharacters = 1f;
    public float initialDelay = 1f;

    public TextMeshProUGUI textComponent;
    private string fullText;

    private void Awake()
    {
        if (textComponent == null)
        {
            textComponent = GetComponent<TextMeshProUGUI>();
        }
    }

    public void AnimateText(string text)
    {
        textComponent.text = "";
        fullText = text;
        StartCoroutine(WriteTextCoroutine());
    }

    private IEnumerator WriteTextCoroutine()
    {
        yield return new WaitForSeconds(initialDelay);

        float elapsedTime = 0f;
        int charIndex = 0;

        while (charIndex < fullText.Length)
        {
            elapsedTime += Time.deltaTime;

            while (elapsedTime >= baseDelayBetweenCharacters && charIndex < fullText.Length)
            {
                textComponent.text += fullText[charIndex];
                charIndex++;
                elapsedTime -= baseDelayBetweenCharacters; // subtract the delay for each character added
            }

            yield return null;
        }
    }
}
