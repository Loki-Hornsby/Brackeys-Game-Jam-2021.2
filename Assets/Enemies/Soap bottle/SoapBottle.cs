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

    public GameObject Bullet;
    public int bulletAmount;
    public int RechargeDelay;

    private Vector2 position;

    void updatePosition(){
        position = Player[0].transform.position + new Vector3(Random.Range(-10,10), Random.Range(-10,10), 0);
    }

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

    public void reEnable(){
        Disabled = false;
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
            rb.position = Vector2.MoveTowards(rb.position, position, moveSpeed * Time.deltaTime);
        }

        // Attack
        if (Vector3.Distance(rb.position, Player[0].transform.position) < 20f & !Disabled){
            Anim.ResetTrigger("Attack");
            Anim.SetTrigger("Attack");

            Invoke("reEnable", RechargeDelay);

            for (int i = 0; i < bulletAmount; i++){
                GameObject bullet = Instantiate(Bullet, this.transform.position + new Vector3(Random.Range(-10,10), Random.Range(-10,10), 0), Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().AddForce((Player[0].transform.position - this.transform.position).normalized*40f, ForceMode2D.Impulse);
            }

            Disabled = true;
        }   
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"){
            Player[0].GetComponent<Health>().UpdateHealth(-2);
        }
    }
}
