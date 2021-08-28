using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kills : MonoBehaviour{
    public Generation generation;
    [System.NonSerialized] public int _kills;
    [System.NonSerialized] public int killsrequired;
    [System.NonSerialized] public bool AllowDoor;

    void Start(){
        AllowDoor = false;
    }

    void Update(){
        if (killsrequired == 0){
            killsrequired = Random.Range(0, generation.enemy_count/2); // divide by 2 because some enemies are invincible
            Debug.Log(killsrequired + "Kills needed - if you've found this then well done");
        }

        if (_kills >= killsrequired && AllowDoor == false){
            AllowDoor = true;
        }
    }
}
