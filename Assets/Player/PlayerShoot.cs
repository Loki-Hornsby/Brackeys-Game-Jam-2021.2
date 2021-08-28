using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour{
    public AudioSource Sound;
    public AudioClip pew_pew;
    public Ammo Ammo;
    public GameObject Shootpos;

    void Update(){
        if (Input.GetMouseButtonDown(0)){
            if (Ammo.AmmoAmount > 0){
                Sound.PlayOneShot(pew_pew, 1f);

                Camera cam = Camera.main;
                Vector3 mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));

                GameObject Bulletprefab = Ammo.AmmoList[Random.Range(0, Ammo.AmmoList.Count)];
                GameObject Bullet = Bulletprefab; //Instantiate(Bulletprefab, Shootpos.transform.position, Quaternion.identity);

                if (Bullet != null){
                    Bullet.transform.position = Shootpos.transform.position;
                    Bullet.SetActive(true);

                    Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
                    rb.AddForce((mousePos - Bullet.transform.position).normalized*40f, ForceMode2D.Impulse);

                    Destroy(Bullet, 50f);
                }

                Ammo.AmmoList.Remove(Bulletprefab);
            } else {
                Debug.Log("Make Empty Sound");
            }
        }
    }
}
