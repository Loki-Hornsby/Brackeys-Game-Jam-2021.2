using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinJuice : MonoBehaviour {
    bool hurtplayer = false;
    Health Health;

    void hurt(){
        if (hurtplayer){
            Health.UpdateHealth(-1);
        }
    }

    void Start(){
        InvokeRepeating("hurt", 0f, 0.1f);
    }

    public void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "Player"){
            Health = col.gameObject.GetComponent<Health>();
            hurtplayer = true;
        }
    }

    public void OnTriggerExit2D(Collider2D col){
        if (col.tag == "Player"){
            hurtplayer = false;
        }
    }
}
