using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class EnemyBase : ScriptableObject{
    public string Name;

    public virtual void Use(){
        // Use Item
        // Something may or may not happy 
        Debug.Log("Used " + Name);
    }
}
