using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public RectTransform barLength;
    private float length;

    public Slider slider;

    public Gradient gradient;
    public Image fill;

    void Start()
    {
        barLength = gameObject.GetComponent<RectTransform>();
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        length = health * 6f;

        barLength.offsetMax = new Vector2(length, barLength.offsetMax.y);

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    } 
}
