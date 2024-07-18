using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacialAnimsController : MonoBehaviour
{
    FacialFeatureManager ffManager;
    GLAttributes gLAttributes;

    // eye stuff
    public string eyeState;

    [SerializeField] private float blinkDuration = 0.1f;
    [SerializeField] private float minBlinkInterval = 2f;
    [SerializeField] private float maxBlinkInterval = 7f;

    // Start is called before the first frame update
    void Start()
    {
        gLAttributes = GetComponent<GLAttributes>();
        ffManager = GetComponent<FacialFeatureManager>();

        eyeState = "eyeNormal";



        StartCoroutine(BlinkRoutine());
    }

    private IEnumerator BlinkRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minBlinkInterval, maxBlinkInterval));
            yield return StartCoroutine(BlinkAnim());
        }
    }

    private IEnumerator BlinkAnim()
    {
        // Blink
        eyeState = "eyeBlink";
        UpdateEyeSprite();

        // Wait for blink duration
        yield return new WaitForSeconds(blinkDuration);

        // Return to normal
        eyeState = "eyeNormal";
        UpdateEyeSprite();
    }

    private void UpdateEyeSprite()
    {
        if (ffManager != null && ffManager.eyes != null && ffManager.textures != null)
        {
            Sprite eyeSprite = ffManager.textures.GetSprite(gLAttributes.race + "Eyes", eyeState);
            if (eyeSprite != null)
            {
                ffManager.eyes.GetComponent<SpriteRenderer>().sprite = eyeSprite;
            }
            else
            {
                Debug.LogWarning($"Eye sprite not found for race: {gLAttributes.race}, state: {eyeState}");
            }
        }
        else
        {
            Debug.LogError("FFManager, eyes, or textures is null");
        }
    }
}
