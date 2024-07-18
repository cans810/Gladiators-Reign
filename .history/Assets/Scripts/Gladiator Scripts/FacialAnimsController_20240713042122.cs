using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacialAnimsController : MonoBehaviour
{
    FacialFeatureManager ffManager;
    GLAttributes gLAttributes;

    // eye stuff
    public string eyeState;

    public bool canLookAround;

    [SerializeField] private float blinkDuration = 0.4f;
    [SerializeField] private float minBlinkInterval = 2f;
    [SerializeField] private float maxBlinkInterval = 7f;

    // Start is called before the first frame update
    void Start()
    {
        gLAttributes = GetComponent<GLAttributes>();
        ffManager = GetComponent<FacialFeatureManager>();

        eyeState = "eyeNormal";
        canLookAround = true;


        StartCoroutine(BlinkRoutine());
    }

    public void Update(){

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

    private IEnumerator LookAroundRoutine()
    {
        while (canLookAround)
        {
            // Look in a random direction
            lookDirection = Random.insideUnitCircle;
            eyeState = GetEyeStateFromDirection(lookDirection);
            UpdateEyeSprite();
            
            // Hold the look for a random duration
            yield return new WaitForSeconds(Random.Range(minLookDuration, maxLookDuration));
            
            // Look back to normal
            lookDirection = Vector2.zero;
            eyeState = "eyeNormal";
            UpdateEyeSprite();
            
            // Wait before looking around again
            yield return new WaitForSeconds(Random.Range(0.5f, 2f));
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
