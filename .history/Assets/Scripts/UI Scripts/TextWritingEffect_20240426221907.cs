using System.Collections;
using TMPro;
using UnityEngine;

public class TextWritingEffect : MonoBehaviour
{
    public float delayBetweenCharacters = 0.002f; // Adjust this delay as needed
    private TextMeshProUGUI textComponent;
    private string fullText;
    private string currentText = "";

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
        float timeSinceLastUpdate = 0f;
        int charactersWritten = 0;

        while (charactersWritten < fullText.Length)
        {
            timeSinceLastUpdate += Time.deltaTime;
            while (timeSinceLastUpdate >= delayBetweenCharacters)
            {
                if (charactersWritten < fullText.Length)
                {
                    charactersWritten++;
                    currentText = fullText.Substring(0, charactersWritten);
                    textComponent.text = currentText;
                }
                timeSinceLastUpdate -= delayBetweenCharacters;
            }
            yield return null; // Wait until next frame
        }
    }
}