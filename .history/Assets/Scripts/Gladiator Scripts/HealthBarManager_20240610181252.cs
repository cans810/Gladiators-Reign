using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarManager : MonoBehaviour
{
    public GladiatorManager glManager;
    public GameObject healthBarObject;
    public SpriteRenderer healthBarImage;
    private float maxHealthWidth;
    private float initialHealthWidth;

    // Start is called before the first frame update
    void Start()
    {
        // Get the initial width of the health bar
        maxHealthWidth = healthBarImage.size.x;
        initialHealthWidth = healthBarImage.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (state.gotHit)
        {
            healthBarImage.gameObject.SetActive(true);
            
            float fillAmount = (float)attributes.HP / (float)attributes.max_HP;
            
            healthBarImage.size = new Vector2(initialHealthWidth * fillAmount, healthBarImage.size.y);
        }
        else
        {
            healthBarImage.gameObject.SetActive(false);
        }
    }
}
