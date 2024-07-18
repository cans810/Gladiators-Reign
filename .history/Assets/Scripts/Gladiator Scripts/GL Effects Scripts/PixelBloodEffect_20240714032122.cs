using System.Collections;
using UnityEngine;

public class PixelBloodEffect : MonoBehaviour
{
    private int numberOfParticles = 100;
    private float lifetime = 100f;
    private float minSpeed = 1f;
    private float maxSpeed = 3f;
    public Color bloodColor;
    private float gravityModifier = 1f;

    private ParticleSystem particleSys;
    private ParticleSystem.Particle[] particles;

    void Start()
    {
        // ... (keep the Start method as is)
    }

    public void Emit(GameObject onGameObject)
    {
        Transform headPos = onGameObject.GetComponent<GladiatorManager>().GetBodyPartPos("head");
        Transform footPos = onGameObject.GetComponent<GladiatorManager>().GetBodyPartPos("right_foot");

        transform.position = headPos.position;
        particleSys.Emit(numberOfParticles);

        float maxFallDistance = Vector3.Distance(headPos.position, footPos.position);

        StartCoroutine(CheckParticleGroup(maxFallDistance, headPos.position));
    }

    private IEnumerator CheckParticleGroup(float maxFallDistance, Vector3 startPosition)
    {
        float averageDistanceTraveled = 0;

        while (averageDistanceTraveled < maxFallDistance)
        {
            yield return new WaitForSeconds(0.1f); // Check every 0.1 seconds to reduce performance impact

            int numParticlesAlive = particleSys.GetParticles(particles);
            Vector3 averagePosition = Vector3.zero;

            for (int i = 0; i < numParticlesAlive; i++)
            {
                averagePosition += particles[i].position;
            }

            if (numParticlesAlive > 0)
            {
                averagePosition /= numParticlesAlive;
                averageDistanceTraveled = Vector3.Distance(startPosition, averagePosition);
            }
        }

        // Stop all particles
        int finalParticleCount = particleSys.GetParticles(particles);
        for (int i = 0; i < finalParticleCount; i++)
        {
            particles[i].velocity = Vector3.zero;
            particles[i].remainingLifetime = Mathf.Infinity;
        }
        particleSys.SetParticles(particles, finalParticleCount);
    }
}