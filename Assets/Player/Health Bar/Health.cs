using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour{
    public Animator Anim;

    public Image fill;
    public Gradient gradient;
    public Slider slider;

    private int _Health;
    private int MaxVal;

    public void UpdateHealth(int val){
        if ((_Health + val) > 0){
            Anim.SetTrigger("Hurt");

            _Health += val;
        } else {
            Anim.SetTrigger("Kill");

            Debug.Log("GameOver - set trigger in animation");

            _Health = 0;
        }

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
