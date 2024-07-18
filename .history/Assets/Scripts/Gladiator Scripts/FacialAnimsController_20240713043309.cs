using UnityEngine;
using System.Collections;

public class FacialAnimsController : MonoBehaviour
{
    private FacialFeatureManager ffManager;
    private GLAttributes gLAttributes;

    public string eyeState;
    public bool canLookAround;

    [SerializeField] private float blinkDuration = 0.1f; // Reduced from 0.4f for more natural blink
    [SerializeField] private float minBlinkInterval = 2f;
    [SerializeField] private float maxBlinkInterval = 7f;

    [SerializeField] private float stareDuration = 2.5f;
    [SerializeField] private float minStareInterval = 5f;
    [SerializeField] private float maxStareInterval = 10f;

    private void Start()
    {
        gLAttributes = GetComponent<GLAttributes>();
        ffManager = GetComponent<FacialFeatureManager>();

        eyeState = "eyeNormal";
        canLookAround = true;

        //StartCoroutine(BlinkRoutine());
        StartCoroutine(LookAroundRoutine());
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
        string previousState = eyeState;
        eyeState = "eyeBlink";
        UpdateEyeSprite();

        yield return new WaitForSeconds(blinkDuration);

        eyeState = previousState;
        UpdateEyeSprite();
    }

    private IEnumerator LookAroundRoutine()
    {
        while (true)
        {
            if (canLookAround)
            {
                yield return new WaitForSeconds(Random.Range(minStareInterval, maxStareInterval));
                yield return StartCoroutine(LookAroundAnim());
            }
            else
            {
                eyeState = "eyeNormal";
                UpdateEyeSprite();
                yield return new WaitForSeconds(1f); // Wait a bit before checking again
            }
        }
    }

    private IEnumerator LookAroundAnim()
    {
        Debug.Log("Starting LookAroundAnim");

        eyeState = Random.value < 0.5f ? "eyeRight" : "eyeLeft";
        Debug.Log($"Setting eyeState to {eyeState}");
        UpdateEyeSprite();

        yield return new WaitForSeconds(stareDuration);

        eyeState = "eyeNormal";
        Debug.Log("Setting eyeState to eyeNormal");
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