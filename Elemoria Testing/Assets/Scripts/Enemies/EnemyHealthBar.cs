using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    private float length;
    public Slider slider;

    public Gradient gradient;
    public Image fill;

    [SerializeField]
    private float updateSpeed = 0.25f;

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float preHealth, float health)
    {
        StartCoroutine(HealthChange(preHealth, health));
    } 
    
    private IEnumerator HealthChange(float pre, float post)
    {
        slider.value = pre;
        
        float elapsed = 0f;

        while(elapsed < updateSpeed)
        {
            elapsed += Time.deltaTime;
            slider.value = Mathf.Lerp(pre, post, elapsed/updateSpeed);
            fill.color = gradient.Evaluate(slider.normalizedValue);
            yield return null;
        }

        slider.value = post;
    }


}
