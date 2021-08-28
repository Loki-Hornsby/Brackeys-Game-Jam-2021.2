using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour{
    [Space(10)] public Generation script_Generation;
    [System.NonSerialized] public int level;

    public List<GameObject> tiles = new List<GameObject>();
    public List<GameObject> props = new List<GameObject>();

    private List<List<GameObject>> Rarity_List = new List<List<GameObject>>();

    public List<GameObject> r_1 = new List<GameObject>();
    public List<GameObject> r_2 = new List<GameObject>();
    public List<GameObject> r_3 = new List<GameObject>();
    public List<GameObject> r_4 = new List<GameObject>();
    public List<GameObject> r_5 = new List<GameObject>();
    public List<GameObject> r_6 = new List<GameObject>();
    public List<GameObject> r_7 = new List<GameObject>();
    public List<GameObject> r_8 = new List<GameObject>();
    public List<GameObject> r_9 = new List<GameObject>();
    public List<GameObject> r_10 = new List<GameObject>();

    void Start(){
        Rarity_List.Add(r_1);
        Rarity_List.Add(r_2);
        Rarity_List.Add(r_3);
        Rarity_List.Add(r_4);
        Rarity_List.Add(r_5);
        Rarity_List.Add(r_6);
        Rarity_List.Add(r_7);
        Rarity_List.Add(r_8);
        Rarity_List.Add(r_9);
        Rarity_List.Add(r_10);
        
        script_Generation.Gen(tiles, Rarity_List, props);
    }

    void Update(){
        
    }
}
