using System.Collections;
using TMPro;
using UnityEngine;

public class TextWritingEffect : MonoBehaviour
{
    public float delayBetweenCharacters = 0.04f;
    public float spaceDelay = 0.10f; // Additional delay multiplier for spaces
    private TextMeshProUGUI textComponent;
    private string fullText;
    private string currentText = "";

    private void Start()
    {
    }

    public void AnimateText(string text){
        textComponent = GetComponent<TextMeshProUGUI>();
        textComponent.text = text;
        textComponent.text = "";

        fullText = textComponent.text;
        StartCoroutine(WriteTextCoroutine());
    }

    private IEnumerator WriteTextCoroutine()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i + 1);
            textComponent.text = currentText;

            // Check if the current character is a space
            if (fullText[i] == ' ')
                yield return new WaitForSeconds(spaceDelay);
            else
                yield return new WaitForSeconds(delayBetweenCharacters);
        }
    }
}
