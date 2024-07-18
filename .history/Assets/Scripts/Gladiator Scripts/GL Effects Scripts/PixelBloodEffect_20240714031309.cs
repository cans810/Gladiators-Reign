using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelBloodEffect : MonoBehaviour
{
    public int numberOfParticles = 100;
    public float lifetime = 1f;
    public float minSpeed = 1f;
    public float maxSpeed = 3f;
    public Color bloodColor = Color.red;
    public float gravityModifier = 1f; // Adjust this value to control gravity strength

    private ParticleSystem particleSys;
    private ParticleSystem.Particle[] particles;
    private bool[] stoppedParticles;

    void Start()
    {
        // Create a new ParticleSystem
        particleSys = gameObject.AddComponent<ParticleSystem>();

        // Get the main module of the ParticleSystem to modify its properties
        var main = particleSys.main;
        main.startLifetime = lifetime;
        main.startSpeed = new ParticleSystem.MinMaxCurve(minSpeed, maxSpeed); // Adjusted to use MinMaxCurve
        main.startSize = 0.05f; // Small size to represent a pixel
        main.startColor = bloodColor;
        main.gravityModifier = gravityModifier; // Add gravity to the particles

        // Set up emission
        var emission = particleSys.emission;
        emission.rateOverTime = 0;
        emission.SetBursts(new ParticleSystem.Burst[]
        {
            new ParticleSystem.Burst(0f, numberOfParticles)
        });

        // Set up shape
        var shape = particleSys.shape;
        shape.shapeType = ParticleSystemShapeType.Cone;
        shape.angle = 25f;
        shape.radius = 0.1f;

        // Set up renderer
        var renderer = particleSys.GetComponent<ParticleSystemRenderer>();
        renderer.material = new Material(Shader.Find("Particles/Standard Unlit"));
        renderer.renderMode = ParticleSystemRenderMode.Billboard;

        // Ensure the particle system does not play on start
        particleSys.Stop();

        // Initialize particle array with max possible particles
        particles = new ParticleSystem.Particle[particleSys.main.maxParticles];

        stoppedParticles = new bool[particleSys.main.maxParticles];
    }

    public void Emit(GameObject onGameObject)
    {
        Transform headPos = onGameObject.GetComponent<GladiatorManager>().GetBodyPartPos("head");
        Transform footPos = onGameObject.GetComponent<GladiatorManager>().GetBodyPartPos("right_foot");

        transform.position = headPos.position;
        particleSys.Emit(numberOfParticles);

        float maxFallDistance = Vector3.Distance(headPos.position, footPos.position);

        StartCoroutine(CheckParticles(maxFallDistance));
    }

    private IEnumerator CheckParticles(float maxFallDistance)
    {
        Vector3 startPosition = transform.position;

        while (particleSys.particleCount > 0)
        {
            int numParticlesAlive = particleSys.GetParticles(particles);
            bool anyParticleMoving = false;

            for (int i = 0; i < numParticlesAlive; i++)
            {
                if (!stoppedParticles[i])
                {
                    float distanceTraveled = Vector3.Distance(startPosition, particles[i].position);

                    if (distanceTraveled >= maxFallDistance || particles[i].velocity.y >= 0)
                    {
                        particles[i].velocity = Vector3.zero;
                        particles[i].remainingLifetime = Mathf.Infinity;
                        stoppedParticles[i] = true;
                    }
                    else
                    {
                        anyParticleMoving = true;
                    }
                }
            }

            particleSys.SetParticles(particles, numParticlesAlive);

            if (!anyParticleMoving)
            {
                break;
            }

            yield return null;
        }
    }
}
