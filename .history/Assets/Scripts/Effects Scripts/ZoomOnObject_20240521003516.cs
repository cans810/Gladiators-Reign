using System.Collections;
using UnityEngine;

public class CameraZoomController : MonoBehaviour
{
    private Vector3 originalPosition;
    private float originalFOV;
    private Coroutine zoomCoroutine;

    public float zoomDuration = 1.0f;  // Duration of the zoom effect
    public float targetFOV = 30f;      // Target field of view for the zoom

    void Start()
    {
        originalPosition = Camera.main.transform.position;
        originalFOV = Camera.main.fieldOfView;
    }

    public void ZoomToGameObject(GameObject target)
    {
        if (zoomCoroutine != null)
        {
            StopCoroutine(zoomCoroutine);
        }
        zoomCoroutine = StartCoroutine(ZoomToTarget(target.transform));
    }

    public void ResetCamera()
    {
        if (zoomCoroutine != null)
        {
            StopCoroutine(zoomCoroutine);
        }
        zoomCoroutine = StartCoroutine(ResetCameraPosition());
    }

    private IEnumerator ZoomToTarget(Transform target)
    {
        Vector3 targetPosition = target.position + new Vector3(0, 2, -5);  // Adjust as needed
        float startTime = Time.time;

        while (Time.time < startTime + zoomDuration)
        {
            float t = (Time.time - startTime) / zoomDuration;
            Camera.main.transform.position = Vector3.Lerp(originalPosition, targetPosition, t);
            Camera.main.fieldOfView = Mathf.Lerp(originalFOV, targetFOV, t);
            yield return null;
        }

        Camera.main.transform.position = targetPosition;
        Camera.main.fieldOfView = targetFOV;
    }

    private IEnumerator ResetCameraPosition()
    {
        float startTime = Time.time;
        Vector3 startPosition = Camera.main.transform.position;
        float startFOV = Camera.main.fieldOfView;

        while (Time.time < startTime + zoomDuration)
        {
            float t = (Time.time - startTime) / zoomDuration;
            Camera.main.transform.position = Vector3.Lerp(startPosition, originalPosition, t);
            Camera.main.fieldOfView = Mathf.Lerp(startFOV, originalFOV, t);
            yield return null;
        }

        Camera.main.transform.position = originalPosition;
        Camera.main.fieldOfView = originalFOV;
    }
}
