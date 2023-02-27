using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbarscript : MonoBehaviour
{
public Gradient gradient;
public Image fill;
    public Slider slider;

    public void SetMaxHealth(int health) {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);

    }

    public void SetHealth(int health) {
        Debug.Log(health);
    slider.value = health;
    fill.color = gradient.Evaluate(slider.normalizedValue);
   }
}