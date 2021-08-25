using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour{
    public int _Ammo;

    public GameObject Text;

    public void UpdateAmmo(int val){
        if ((_Ammo + val) > 0){
            _Ammo += val;
        } else {
            _Ammo = 0;
        }

        Text.GetComponent<UnityEngine.UI.Text>().text = _Ammo.ToString();
    }

    void Start(){
        _Ammo = 0;

        UpdateAmmo(0);
    }
}
