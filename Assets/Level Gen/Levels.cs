using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour{
    [Space(10)] public Generation script_Generation;

    [Space(10)] [Header("Level1")]
    public List<GameObject> L1_tiles = new List<GameObject>();
    public List<GameObject> L1_enemies = new List<GameObject>();
    public List<GameObject> L1_props = new List<GameObject>();

    [Space(10)] [Header("Level2")]
    public List<GameObject> L2_tiles = new List<GameObject>();
    public List<GameObject> L2_enemies = new List<GameObject>();
    public List<GameObject> L2_props = new List<GameObject>();

    [Space(10)] [Header("Level3")]
    public List<GameObject> L3_tiles = new List<GameObject>();
    public List<GameObject> L3_enemies = new List<GameObject>();
    public List<GameObject> L3_props = new List<GameObject>();

    void Start(){
        script_Generation.Gen(L1_tiles, L1_enemies, L1_props);
    }

    void Update(){
        
    }
}
