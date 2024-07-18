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

    private ParticleSystem particleSys;

    void Start()
    {
        // Create a new ParticleSystem
        particleSys = gameObject.AddComponent<ParticleSystem>();

        // Get the main module of the ParticleSystem to modify its properties
        var main = particleSys.main;
        main.startLifetime = lifetime;
        main.startSpeed = Random.Range(minSpeed, maxSpeed);
        main.startSize = 0.01f; // Small size to represent a pixel
        main.startColor = bloodColor;

        // Set up emission
        var emission = particleSys.emission;
        emission.rateOverTime = 0;
        emission.SetBursts(new ParticleSystem.Burst[]
        {
            new ParticleSystem.Burst(0f, numberOfParticles)
        });

        // Set up shape
        var shape = particleSys.shape;
        shape.shapeType = ParticleSystemShapeType.Sphere;
        shape.radius = 0.1f;

        // Set up renderer
        var renderer = particleSys.GetComponent<ParticleSystemRenderer>();
        renderer.material = new Material(Shader.Find("Particles/Standard Unlit"));
        renderer.renderMode = ParticleSystemRenderMode.Billboard;

        // Play the particle system
        particleSys.Play();
    }

    public void Emit(Vector3 position)
    {
        transform.position = position;
        particleSys.Emit(numberOfParticles);
    }
