using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite : MonoBehaviour{
    // 0: pickup state
    // 1: fire state
    [System.NonSerialized] 
    public int state = 0;
    GameObject ply;

    Animator Anim;

    public GameObject boomBoom;

    void Start(){
        Anim = this.gameObject.GetComponent<Animator>();
    }

    public void spawnBoom(){
        Instantiate(boomBoom, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            if (state == 0){
                state = 1;

                other.gameObject.GetComponent<Ammo>().AmmoList.Add(this.gameObject);
                this.gameObject.SetActive(false);
                ply = other.gameObject;
            }
        }

        if (state == 1){
            Anim.SetTrigger("Die");

            if (other.gameObject.tag == "Enemy"){
                Destroy(other.gameObject);
                    
                ply.GetComponent<kills>()._kills += 1;
            }
        }
    }
}
