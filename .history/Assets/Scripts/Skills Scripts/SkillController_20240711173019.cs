using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    public string skillName;

    public string skillDescription;
    public string 

    public List<GameObject> outgoingSkills;
    private List<LineRenderer> lineRenderers;

    void Start()
    {
        skillName = gameObject.name;

        lineRenderers = new List<LineRenderer>();
        DrawLinesToOutgoingSkills();
    }

    void Update()
    {
        // Update line positions if skills or this object moves
        UpdateLinePositions();
    }

    void DrawLinesToOutgoingSkills()
    {
        foreach (GameObject skill in outgoingSkills)
        {
            if (skill != null)
            {
                // Create a new GameObject for the line
                GameObject lineObj = new GameObject("Line to " + skill.name);
                lineObj.transform.SetParent(transform);

                // Add a LineRenderer component
                LineRenderer line = lineObj.AddComponent<LineRenderer>();

                // Configure the LineRenderer
                line.startWidth = 0.1f;
                line.endWidth = 0.1f;
                line.positionCount = 2;
                line.useWorldSpace = true;

                // Set the line color (you can adjust this as needed)
                line.startColor = Color.white;
                line.endColor = Color.white;

                // Set the line material (you may want to create a specific material for this)
                line.material = new Material(Shader.Find("Sprites/Default"));

                // Add to our list of line renderers
                lineRenderers.Add(line);
            }
        }

        // Initial position update
        UpdateLinePositions();
    }

    void UpdateLinePositions()
    {
        for (int i = 0; i < outgoingSkills.Count; i++)
        {
            if (outgoingSkills[i] != null && i < lineRenderers.Count)
            {
                Vector3 startPosition = transform.position;
                Vector3 endPosition = outgoingSkills[i].transform.position;

                lineRenderers[i].SetPosition(0, startPosition);
                lineRenderers[i].SetPosition(1, endPosition);
            }
        }
    }
}