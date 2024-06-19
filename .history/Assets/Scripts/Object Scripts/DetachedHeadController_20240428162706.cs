using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachedHeadController : MonoBehaviour
{
    private Vector3 originalPosition;
    private bool shouldDestroy = false;
    public GameObject original;

    void Start()
    {
        GetComponent<SpriteRenderer>().sortingLayerName = fromEntity.GetComponent<Sprite>
        originalPosition = transform.position;
    }

    void Update()
    {
        if (transform.position.y < originalPosition.y && !shouldDestroy)
        {
            Destroy(GetComponent<Rigidbody2D>());

            shouldDestroy = true;

            //StartCoroutine(DestroyAfterDelay(4f));
        }
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(gameObject);
    }
}