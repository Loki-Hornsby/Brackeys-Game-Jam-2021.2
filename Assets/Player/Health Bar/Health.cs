using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour{
    public Image fill;
    public Gradient gradient;
    public Slider slider;

    private int _Health;
    private int MaxVal;

    public void UpdateHealth(int val){
        _Health += val;

        slider.maxValue = MaxVal;
        slider.value = _Health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    void Start() {
        _Health = 100;
        MaxVal = 100;

        UpdateHealth(0);
    }
}
