using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoItem : MonoBehaviour{
    // 0: pickup state
    // 1: fire state
    [System.NonSerialized] 
    public int state = 0;

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            if (state == 0){
                state = 1;

                other.gameObject.GetComponent<Ammo>().AmmoList.Add(this.gameObject);
                this.gameObject.SetActive(false);
            }
        }

        if (state == 1){
            if (other.gameObject.tag == "Enemy"){
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
