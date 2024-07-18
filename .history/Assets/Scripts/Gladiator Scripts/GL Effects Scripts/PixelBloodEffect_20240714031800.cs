using System.Collections;
using UnityEngine;

public class PixelBloodEffect : MonoBehaviour
{
    private int numberOfParticles = 100;
    private float lifetime = 100f;
    private float minSpeed = 1f;
    private float maxSpeed = 3f;
    private Color bloodColor = Color.red;
    private float gravityModifier = 1f;

    private ParticleSystem particleSys;
    private ParticleSystem.Particle[] particles;

    void Start()
    {
        // Create a new ParticleSystem
        particleSys = gameObject.AddComponent<ParticleSystem>();

        // Get the main module of the ParticleSystem to modify its properties
        var main = particleSys.main;
        main.startLifetime = lifetime;
        main.startSpeed = new ParticleSystem.MinMaxCurve(minSpeed, maxSpeed);
        main.startSize = 0.05f; // Small size to represent a pixel
        main.startColor = bloodColor;
        main.gravityModifier = gravityModifier;
        main.simulationSpace = ParticleSystemSimulationSpace.World;

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
    }

    public void Emit(GameObject onGameObject)
    {
        Transform headPos = onGameObject.GetComponent<GladiatorManager>().GetBodyPartPos("head");
        Transform footPos = onGameObject.GetComponent<GladiatorManager>().GetBodyPartPos("right_foot");

        transform.position = headPos.position;
        particleSys.Emit(numberOfParticles);

        float maxFallDistance = Vector3.Distance(headPos.position, footPos.position);

        StartCoroutine(CheckParticleGroup(maxFallDistance));
    }

    private IEnumerator CheckParticleGroup(float maxFallDistance)
    {
        Vector3 startPosition = transform.position;
        float distanceTraveled = 0;

        while (distanceTraveled < maxFallDistance)
        {
            distanceTraveled = Vector3.Distance(startPosition, transform.position);
            yield return null;
        }

        // Stop all particles
        int numParticlesAlive = particleSys.GetParticles(particles);
        for (int i = 0; i < numParticlesAlive; i++)
        {
            particles[i].velocity = Vector3.zero;
            particles[i].remainingLifetime = Mathf.Infinity;
        }
        particleSys.SetParticles(particles, numParticlesAlive);
    }
}