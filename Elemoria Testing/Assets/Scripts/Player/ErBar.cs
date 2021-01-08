using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErBar : MonoBehaviour
{
    public RectTransform barLength;
    private float length;

    public Slider[] sliders;

    void Start()
    {
        barLength = gameObject.GetComponent<RectTransform>();
    }

    public void SetMaxRadiation(float er)
    {
        length = er * 6f;

        barLength.offsetMax = new Vector2(length, barLength.offsetMax.y);

        float i = 0f;
        foreach(Slider slider in sliders)
        {
            slider.minValue = er * i;
            slider.maxValue = er * (i + 1f);
            slider.value = slider.minValue;
            i++;
        } 
    }

    public void SetRadiation(float er)
    {
        foreach(Slider slider in sliders)
        {
            slider.value = er;
        }  
    } 
}
