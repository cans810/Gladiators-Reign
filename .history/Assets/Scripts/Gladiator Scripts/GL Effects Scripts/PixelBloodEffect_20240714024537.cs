using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelBloodEffect : MonoBehaviour
{
    public int numberOfParticles = 20;
    public float lifetime = 0.7f;
    public float minSpeed = 1f;
    public float maxSpeed = 3f;
    public Color bloodColor;
    public float gravityModifier = 1f; // Adjust this value to control gravity strength

    private ParticleSystem particleSys;

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

        // Set up collision
        var collision = particleSys.collision;
        collision.enabled = true;
        collision.type = ParticleSystemCollisionType.World;
        collision.mode = ParticleSystemCollisionMode.Collision3D;
        collision.dampen = 0.5f;
        collision.bounce = 0.3f;

        // Ensure the particle system does not play on start
        particleSys.Stop();
    }

    public void Emit(Transform bodyPartToBleed)
    {
        transform.position = bodyPartToBleed.position;
        particleSys.Emit(numberOfParticles);
    }
}
