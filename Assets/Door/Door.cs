using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour{
    public void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "Player"){
            Debug.Log("Fade out");
            Debug.Log("Load New Level");
            Debug.Log("Fade in");
        }
    }
}
