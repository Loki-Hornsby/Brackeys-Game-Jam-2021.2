using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile1 : MonoBehaviour{
    public void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "Player"){
            col.gameObject.GetComponent<PlayerMove>().moveSpeed = col.gameObject.GetComponent<PlayerMove>().moveSpeed/2;
        }
    }

    public void OnTriggerExit2D(Collider2D col){
        if (col.tag == "Player"){
            col.gameObject.GetComponent<PlayerMove>().moveSpeed = col.gameObject.GetComponent<PlayerMove>().moveSpeed*2;
        }
    }
}
