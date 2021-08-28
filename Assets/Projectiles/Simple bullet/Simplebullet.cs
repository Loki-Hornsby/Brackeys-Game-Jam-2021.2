using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simplebullet : MonoBehaviour{
    Animator Anim;
    public int lifetime;
    public int damage;

    public void destroySelf(){
        Destroy(this.gameObject);
    }

    void decay(){
        Anim.SetTrigger("Die");
    }

    void Start(){
        Anim = GetComponent<Animator>();
        Invoke("decay", lifetime);
    }

    public void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "Player"){
            this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            Invoke("decay", 0);
            col.gameObject.GetComponent<Health>().UpdateHealth(-damage);
        }
    }
}
