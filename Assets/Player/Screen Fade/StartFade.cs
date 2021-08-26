using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFade : MonoBehaviour{
    public Animator Anim;

    void Start(){
        Anim.ResetTrigger("Fade_in");
        Anim.ResetTrigger("Fade_out");
        Anim.SetTrigger("Fade_in");
    }
}
