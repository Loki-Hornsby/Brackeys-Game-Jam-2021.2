using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class SoapBottle : MonoBehaviour{
    private GameObject[] Player;

    Animator Anim;
    bool Disabled;

    public float moveSpeed;
    Rigidbody2D rb;
    private bool FacingRight = false;

    void Start(){
        Disabled = false;

        Player = GameObject.FindGameObjectsWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    void flip(){
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Update(){
        if (!Disabled){
            // Flipping code!
            if (Player[0].transform.position.x < rb.position.x && FacingRight){
                flip();

                FacingRight = false;
            }

            if (Player[0].transform.position.x > rb.position.x && !FacingRight){
                flip();

                FacingRight = true;
            }

            // Movement
            rb.position = Vector2.MoveTowards(rb.transform.position, Player[0].transform.position, moveSpeed * Time.deltaTime);
        }

        // Attack
        if (Vector3.Distance(rb.position, Player[0].transform.position) < 20f & !Disabled){
            Anim.ResetTrigger("Attack");
            Anim.SetTrigger("Attack");

            Disabled = true;
        }   
    }
}
