using System.Collections;
using UnityEngine;

public class PixelBloodEffect : MonoBehaviour
{
    private int numberOfParticles = 20;
    private float lifetime = 15f;
    private float minSpeed = 1f;
    private float maxSpeed = 3f;
    public Color bloodColor;
    private float gravityModifier = 9.81f;

    private ParticleSystem particleSys;
    private ParticleSystem.Particle[] particles;
    private Vector3[] velocities;
    private bool isSimulating = false;

    void Start()
    {
        // Create a new ParticleSystem
        particleSys = gameObject.AddComponent<ParticleSystem>();

        // Get the main module of the ParticleSystem to modify its properties
        var main = particleSys.main;
        main.startLifetime = lifetime;
        main.startSpeed = 0;
        main.startSize = 0.05f; // Small size to represent a pixel
        main.startColor = bloodColor;
        main.gravityModifier = 0;
        main.simulationSpace = ParticleSystemSimulationSpace.World;
        main.playOnAwake = false;

        // Disable emission
        var emission = particleSys.emission;
        emission.enabled = false;

        // Set up shape
        var shape = particleSys.shape;
        shape.enabled = false;

        // Set up renderer
        var renderer = particleSys.GetComponent<ParticleSystemRenderer>();
        renderer.material = new Material(Shader.Find("Particles/Standard Unlit"));
        renderer.renderMode = ParticleSystemRenderMode.Billboard;

        // Initialize particle array and velocities
        particles = new ParticleSystem.Particle[numberOfParticles];
        velocities = new Vector3[numberOfParticles];
    }

    public void Emit(GameObject onGameObject)
    {
        Transform headPos = onGameObject.GetComponent<GladiatorManager>().GetBodyPartPos("head");
        transform.position = headPos.position;

        for (int i = 0; i < numberOfParticles; i++)
        {
            particles[i].position = transform.position;
            particles[i].startColor = bloodColor;
            particles[i].startSize = 0.05f;
            particles[i].remainingLifetime = lifetime;

            float speed = Random.Range(minSpeed, maxSpeed);
            float angle = Random.Range(-25f, 25f);
            velocities[i] = Quaternion.Euler(0, 0, angle) * Vector3.up * speed;
        }

        particleSys.SetParticles(particles, numberOfParticles);
        isSimulating = true;
        StartCoroutine(StopParticlesAfterDelay(0.4f));
    }

    private void Update()
    {
        if (isSimulating)
        {
            for (int i = 0; i < numberOfParticles; i++)
            {
                velocities[i] += Vector3.down * gravityModifier * Time.deltaTime;
                particles[i].position += velocities[i] * Time.deltaTime;
            }
            particleSys.SetParticles(particles, numberOfParticles);
        }
    }

    private IEnumerator StopParticlesAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        isSimulating = false;

        for (int i = 0; i < numberOfParticles; i++)
        {
            velocities[i] = Vector3.zero;
            particles[i].remainingLifetime = Mathf.Infinity;
        }

        particleSys.SetParticles(particles, numberOfParticles);

        Debug.Log("Particles stopped after delay");
    }
}