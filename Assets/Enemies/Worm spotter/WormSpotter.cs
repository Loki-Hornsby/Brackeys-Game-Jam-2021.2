using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormSpotter : MonoBehaviour{
    Health Health;
    public GameObject Worm;
    Animator Animator;

    bool Attack = false;

    void inducePAIN(){
        if (Attack){
            Instantiate(Worm, 
                    this.transform.position, 
                    Quaternion.identity);
        }
    }

    public void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "Player"){
            Animator.ResetTrigger("Idle");
            Animator.SetTrigger("Attack");
            Attack = true;
        }
    }

    public void OnTriggerExit2D(Collider2D col){
        if (col.tag == "Player"){
            Animator.ResetTrigger("Attack");
            Animator.SetTrigger("Idle");
            Attack = false;
        }
    }

    void Start(){
        InvokeRepeating("inducePAIN", 0f, 0.5f);

        Animator = this.gameObject.GetComponent<Animator>();
    }
}
