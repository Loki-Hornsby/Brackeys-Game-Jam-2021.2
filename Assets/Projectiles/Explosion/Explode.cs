using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Explode : MonoBehaviour{
    GameObject[] Ply;
    AudioSource audio;
    public AudioClip BOOOM;

    void Start(){
        audio = GetComponent<AudioSource>();
        Ply = GameObject.FindGameObjectsWithTag("Player");
        audio.PlayOneShot(BOOOM, 1f);
    }

    public void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "Player"){
            col.gameObject.GetComponent<Health>().UpdateHealth(-50);
        }

        if (col.tag == "Enemy"){
            Ply[0].GetComponent<kills>()._kills += 1;
            Destroy(col.gameObject);
        }
    }

    public void kill(){
        Destroy(this.gameObject);
    }
}
