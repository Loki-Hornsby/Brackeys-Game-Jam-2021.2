using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour{
    public AudioSource Sound;
    public AudioClip open;
    public AudioClip locked;

    public Animator Anim;
    public Animator screenFade;

    GameObject Player;
    bool OpenDoor = false; 

    void Loadlvl(){
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Fade(){
        screenFade.ResetTrigger("Fade_in");
        screenFade.ResetTrigger("Fade_out");
        screenFade.SetTrigger("Fade_out");

        Invoke("Loadlvl",5); // isn't loading correctly
    }

    void Update(){
        if (OpenDoor){
            Anim.SetTrigger("Open");
            
            Player.GetComponent<Health>()._Health = Random.Range(100,100000);
            Player.GetComponent<Health>().MaxVal = Player.GetComponent<Health>()._Health + Random.Range(100,100000);
            Player.GetComponent<Health>().UpdateHealth(0);
            //Remove 8 items from ammo
        }
    }

    public void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "Player"){
            if (col.gameObject.GetComponent<Ammo>().AmmoAmount >= 8){
                Player = col.gameObject;

                Sound.PlayOneShot(open, 1f);

                OpenDoor = true;
            } else {
                Sound.PlayOneShot(locked, 0.1f); // forgot to reduce compression on sound software so this will have to do
            }

            //Debug.Log("Fade out");
            //Debug.Log("Destroy Scene");
            //Debug.Log("Load New Level");
            //Debug.Log("Fade in");
        }
    }
}
