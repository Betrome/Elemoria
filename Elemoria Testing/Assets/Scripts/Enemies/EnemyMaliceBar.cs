using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMaliceBar : MonoBehaviour
{
    private float length;
    public Slider slider;

    public Gradient gradient;
    public Image fill;

    public void SetMaxMalice(float malice)
    {
        slider.maxValue = malice;
        slider.value = 0.0f;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetMalice(float malice)
    {
        slider.value = malice;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    } 
}
