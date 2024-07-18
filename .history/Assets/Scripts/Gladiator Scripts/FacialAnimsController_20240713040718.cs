using UnityEngine;

public class FacialAnimsController : MonoBehaviour
{
    private Animator animator;
    private float blinkTimer;
    private float blinkInterval;

    void Start()
    {
        animator = GetComponent<Animator>();
        SetRandomBlinkInterval();
    }

    void Update()
    {
        blinkTimer += Time.deltaTime;
        if (blinkTimer >= blinkInterval)
        {
            animator.SetTrigger("Blink");
            SetRandomBlinkInterval();
            blinkTimer = 0;
        }
    }

    void SetRandomBlinkInterval()
    {
        blinkInterval = Random.Range(3f, 7f); // Random blink interval between 3 and 7 seconds
    }
}
