using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextWritingEffect : MonoBehaviour
{
    public float delayBetweenCharacters = 0.1f;
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
            yield return new WaitForSeconds(delayBetweenCharacters);
        }
    }
}
