using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour{
    public audiohandle audiohandle;
    public Animator Anim;
    public Animator screenfadeanimator;

    public Image fill;
    public Gradient gradient;
    public Slider slider;

    [System.NonSerialized] public int _Health;
    [System.NonSerialized] public int MaxVal;

    void loadmenu(){
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void UpdateHealth(int val){
        if ((_Health + val) > 0){
            Anim.SetTrigger("Hurt");

            _Health += val;
        } else {
            this.GetComponent<PlayerMove>().enabled = false;
            this.GetComponent<Health>().enabled = false;
            Debug.Log("GameOver - set trigger in animation");

            screenfadeanimator.ResetTrigger("Fade_in");
            screenfadeanimator.SetTrigger("Fade_out");

            StartCoroutine(audiohandle.FadeOut(2f));

            Invoke("loadmenu", 3f);

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
