using UnityEngine;

public class FacialAnimsController : MonoBehaviour
{
    private Animator animator;
    private float blinkTimer;
    private float blinkInterval;
    private float blinkDuration = 0.1f; // Duration of a blink

    [SerializeField]
    private float minBlinkInterval = 2f;
    [SerializeField]
    private float maxBlinkInterval = 7f;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found!");
            enabled = false;
            return;
        }
        SetRandomBlinkInterval();
    }

    void Update()
    {
        blinkTimer += Time.deltaTime;
        if (blinkTimer >= blinkInterval)
        {
            StartBlink();
        }
    }

    void StartBlink()
    {
        animator.SetBool("IsBlinking", true);
        Invoke("EndBlink", blinkDuration);
        SetRandomBlinkInterval();
        blinkTimer = 0;
    }

    void EndBlink()
    {
        animator.SetBool("IsBlinking", false);
    }

    void SetRandomBlinkInterval()
    {
        blinkInterval = Random.Range(minBlinkInterval, maxBlinkInterval);
    }
}