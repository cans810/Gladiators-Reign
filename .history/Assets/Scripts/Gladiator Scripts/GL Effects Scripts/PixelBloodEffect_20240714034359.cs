using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelBloodEffect : MonoBehaviour
{
    public GameObject bloodParticlePrefab;
    public int numberOfParticles = 20;
    public float lifetime = 15f;
    public float minSpeed = 1f;
    public float maxSpeed = 3f;
    public Color bloodColor = Color.red;
    public float gravityScale = 1f;

    private List<GameObject> particles = new List<GameObject>();
    private bool isScattered = false;

    public void Emit(GameObject onGameObject)
    {
        Transform headPos = onGameObject.GetComponent<GladiatorManager>().GetBodyPartPos("head");
        transform.position = headPos.position;

        // Clear existing particles
        ClearParticles();

        // Create new particles
        for (int i = 0; i < numberOfParticles; i++)
        {
            GameObject particle = Instantiate(bloodParticlePrefab, transform.position, Quaternion.identity, transform);
            Rigidbody2D rb = particle.GetComponent<Rigidbody2D>();

            rb.gravityScale = 0; // No gravity initially
            
            particles.Add(particle);
        }

        isScattered = false;
    }

    public void ScatterParticles()
    {
        if (isScattered) return;

        foreach (GameObject particle in particles)
        {
            Rigidbody2D rb = particle.GetComponent<Rigidbody2D>();
            
            float speed = Random.Range(minSpeed, maxSpeed);
            Vector2 direction = Random.insideUnitCircle.normalized;
            rb.velocity = direction * speed;
            rb.gravityScale = gravityScale;
        }

        isScattered = true;
        StartCoroutine(StopParticlesAfterDelay(0.4f));
    }

    private IEnumerator StopParticlesAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        foreach (GameObject particle in particles)
        {
            if (particle != null)
            {
                Rigidbody2D rb = particle.GetComponent<Rigidbody2D>();
                rb.velocity = Vector2.zero;
                rb.gravityScale = 0;
            }
        }

        Debug.Log("Particles stopped after delay");
    }

    private void ClearParticles()
    {
        foreach (GameObject particle in particles)
        {
            if (particle != null)
            {
                Destroy(particle);
            }
        }
        particles.Clear();
    }

    private void OnDestroy()
    {
        ClearParticles();
    }
}