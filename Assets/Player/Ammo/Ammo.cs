using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour{
    public int AmmoAmount;
    [System.NonSerialized]
    public List<GameObject> AmmoList = new List<GameObject>();

    public GameObject Text;

    void Update(){
        AmmoAmount = AmmoList.Count;
        Text.GetComponent<UnityEngine.UI.Text>().text = AmmoAmount.ToString();
    }
}
