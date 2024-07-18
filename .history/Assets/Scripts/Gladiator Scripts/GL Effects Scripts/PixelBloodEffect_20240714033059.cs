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
        main.playOnAwake = false;

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

        // Initialize particle array with max possible particles
        particles = new ParticleSystem.Particle[particleSys.main.maxParticles];

        particleSys.Stop();
    }

    public void Emit(GameObject onGameObject)
    {
        Transform headPos = onGameObject.GetComponent<GladiatorManager>().GetBodyPartPos("head");

        transform.position = headPos.position;
        particleSys.Clear();
        particleSys.Play();
        StartCoroutine(StopParticlesAfterDelay(0f));
    }

    private IEnumerator StopParticlesAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Pause the particle system
        particleSys.Pause();

        // Get all particles
        int numParticlesAlive = particleSys.GetParticles(particles);

        // Set their velocities to zero and remaining lifetime to infinity
        for (int i = 0; i < numParticlesAlive; i++)
        {
            particles[i].velocity = Vector3.zero;
            particles[i].remainingLifetime = Mathf.Infinity;
        }

        // Apply the changes back to the particle system
        particleSys.SetParticles(particles, numParticlesAlive);

        // Ensure the particle system stays paused
        particleSys.Pause();

        Debug.Log("Particles stopped after 1 second");
    }
}