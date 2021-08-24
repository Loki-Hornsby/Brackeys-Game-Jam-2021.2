using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour{
    public void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "Player"){
            col.gameObject.GetComponent<Health>().UpdateHealth(-50);
        }
    }

    public void kill(){
        Destroy(this.gameObject);
    }
}
