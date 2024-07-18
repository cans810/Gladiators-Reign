using UnityEngine;
using System.Collections;

public class FacialAnimsController : MonoBehaviour
{
    private FacialFeatureManager ffManager;
    private GLAttributes gLAttributes;

    public string eyeState = "eyeNormal";
    public bool canLookAround = true;

    [SerializeField] private float blinkDuration = 0.1f;
    [SerializeField] private float minBlinkInterval = 15f;
    [SerializeField] private float maxBlinkInterval = 18f;

    [SerializeField] private float stareDuration = 2.5f;
    [SerializeField] private float minStareInterval = 9f;
    [SerializeField] private float maxStareInterval = 25f;

    [SerializeField] [Range(0f, 1f)] private float lookAroundChance = 0.7f;
    [SerializeField] [Range(0f, 1f)] private float returnToNormalChance = 0.3f;

    private void Start()
    {
        gLAttributes = GetComponent<GLAttributes>();
        ffManager = GetComponent<FacialFeatureManager>();

        StartCoroutine(BlinkRoutine());
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
            if (canLookAround && Random.value < lookAroundChance)
            {
                yield return new WaitForSeconds(Random.Range(minStareInterval, maxStareInterval));
                yield return StartCoroutine(LookAroundAnim());
            }
            else
            {
                yield return new WaitForSeconds(Random.Range(1f, 3f));
            }
        }
    }

    private IEnumerator LookAroundAnim()
    {
        eyeState = Random.value < 0.5f ? "eyeRight" : "eyeLeft";
        UpdateEyeSprite();

        yield return new WaitForSeconds(stareDuration);

        if (Random.value < returnToNormalChance)
        {
            eyeState = "eyeNormal";
            UpdateEyeSprite();
        }
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