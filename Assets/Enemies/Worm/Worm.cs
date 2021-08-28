using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Worm : MonoBehaviour{
    private GameObject[] Player;

    Animator Anim;
    bool Dead;

    public float moveSpeed;
    Rigidbody2D rb;
    private bool FacingRight = false;

    public int damage;

    void Start(){
        Dead = false;

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
        if (!Dead){
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
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"){
            Anim.SetTrigger("Die");
            Destroy(GetComponent<BoxCollider2D>());
            Destroy(rb);
            Player[0].gameObject.GetComponent<Health>().UpdateHealth(-damage);
            this.gameObject.transform.parent = Player[0].transform;

            Dead = true;
        }
    }
}
