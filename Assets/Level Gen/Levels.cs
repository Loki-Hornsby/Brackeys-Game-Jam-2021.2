using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour{
    [Space(10)] public Generation script_Generation;
    [System.NonSerialized] public int level;

    public List<GameObject> tiles = new List<GameObject>();
    public List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> props = new List<GameObject>();

    void Start(){
        script_Generation.Gen(tiles, enemies, props);
    }

    void Update(){
        
    }
}
