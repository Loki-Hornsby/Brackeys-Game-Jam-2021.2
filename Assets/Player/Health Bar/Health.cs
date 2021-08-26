using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour{
    public Animator Anim;

    public Image fill;
    public Gradient gradient;
    public Slider slider;

    [System.NonSerialized] public int _Health;
    [System.NonSerialized] public int MaxVal;

    public void UpdateHealth(int val){
        if ((_Health + val) > 0){
            Anim.SetTrigger("Hurt");

            _Health += val;
        } else {
            this.GetComponent<PlayerMove>().enabled = false;
            this.GetComponent<Health>().enabled = false;
            Debug.Log("GameOver - set trigger in animation");

            Anim.SetTrigger("Kill");

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
