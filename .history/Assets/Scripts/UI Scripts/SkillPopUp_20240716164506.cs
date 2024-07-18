using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPopUp : MonoBehaviour
{
    public string skill;
    public Sprite skillTexture;

    public SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitSkillPopup(string skillName, Sprite skillTexture){

    }
}
