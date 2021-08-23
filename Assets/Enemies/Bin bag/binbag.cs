using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class binbag : MonoBehaviour{
    public GameObject Bin_Juice;
    private GameObject[] Player;

    public Animator Anim;
    bool Dead;

    public float moveSpeed;
    Rigidbody2D rb;
    private bool FacingRight = false;

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
        if (!Anim.GetBool("Dead")){
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

            // Explosion Death
            if (Vector3.Distance(rb.position, Player[0].transform.position) < 5f){
                rb.position = Vector2.MoveTowards(rb.transform.position, Player[0].transform.position, moveSpeed * Time.deltaTime);

                Destroy(this.gameObject.GetComponent<CircleCollider2D>());
                Destroy(this.gameObject, 10f);

                Instantiate(
                    Bin_Juice,
                    Player[0].gameObject.transform.position, 
                    Quaternion.identity);

                Anim.SetTrigger("KILL");

                flip();

                Anim.SetBool("Dead", true);
            }   
        }
    }
}
