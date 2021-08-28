using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour{
    [Header("Modifiers")]
    [System.NonSerialized] public int enemy_count;
    [System.NonSerialized] public int Amount;
    [System.NonSerialized] public Vector2 Size;

    public int BranchAmountRange;
    public int BranchSizeRange;

    [Header("Exit Door")]
    public GameObject ExitDoor;
    public AudioSource Door_Audiosrc;
    public Animator Door_fade;

    [Header("Edges")]
    public GameObject BottomLeftCorner;
    public GameObject BottomRightCorner;
    public GameObject TopLeftCorner;
    public GameObject TopRightCorner;
 
    public GameObject LeftWall;
    public GameObject RightWall;
    public GameObject TopWall;
    public GameObject BottomWall;

    [Header("Trash Pickups")]
    public List<GameObject> trashPickups = new List<GameObject>();

    public GameObject Player;

    private List<GameObject> tilePositions = new List<GameObject>();

    void Start(){
        Amount = Random.Range(10,40);
        int s = 40;
        Size = new Vector2(s, s);
        enemy_count = Random.Range(((Amount*Amount)/8), (Amount*Amount)/4);

        Debug.Log("Enemies: " + enemy_count);
    }

    private GameObject Corners(int x, int y){
        // Bottom left Corner
        if (x == 0 && y == 0){
            return BottomLeftCorner;
        } else 

        // Bottom right Corner
        if (x == Amount-1f && y == 0){
            // Player pos
            Player.transform.position = new Vector3(x*(Size.x/1.6f), y*(Size.x/1.6f) - 15, 0);

            return BottomRightCorner;
        } else 

        // Top right Corner
        if (x == Amount-1f && y == Amount-1f){
            return TopRightCorner;
        } else 

        // Top left Corner
        if (x == 0 && y == Amount-1f){
            return TopLeftCorner;
        } else

        return null;
    }

    private GameObject Walls(int x, int y){
        // Left Wall
        if (x == 0 && y > 0 && y < Amount){
            return LeftWall;
        } else

        // Right Wall
        if (x == Amount-1 && y > 0 && y < Amount){
            return RightWall;
        } else

        // Top Wall
        if (y == Amount-1 && x > 0 && x < Amount){
            return TopWall;
        } else

        // Bottom Wall
        if (y == 0 && x > 0 && x < Amount){
            return BottomWall;
        } else

        return null;
    }

    GameObject PickEnemy(List<List<GameObject>> raritys){
        int c = Random.Range(1, 100);

        if (c < 10){            // 10%
            c = 10;             // + 
        } else if (c < 20){     // 20%
            c = 9;              // +  
        } else if (c < 30){     // 30%
            c = 8;              // +  
        } else if (c < 40){     // 40%    
            c = 7;              // +  
        } else if (c < 50){     // 50%   
            c = 6;              // +  
        } else if (c < 60){     // 60%   
            c = 5;              // +  
        } else if (c < 70){     // 70%   
            c = 4;              // +  
        } else if (c < 80){     // 80%   
            c = 3;              // +
        } else if (c < 90){     // 90%   
            c = 2;              // +
        } else if (c < 100){    // 100%
            c = 1;
        }

        c -= 1; // cus lists start at 0

        return raritys[c][Random.Range(0, raritys[c].Count)];
    }

    public void Gen(List<GameObject> Tiles, List<List<GameObject>> rarities, List<GameObject> Props){
        GameObject Centre = new GameObject("Centre");
        Centre.transform.position = new Vector2((Amount/2)*(Size.x/1.6f), (Amount/2)*(Size.y/1.6f));
        
        for (int x = 0; x < Amount; x++){
            for (int y = 0; y < Amount; y++){
                // Tiles
                GameObject obj_ = Instantiate(
                    Tiles[Random.Range(0, Tiles.Count)], 
                    new Vector2(
                        (x*(Size.x/1.6f)), 
                        (y*(Size.y/1.6f))), 
                    Quaternion.identity);

                obj_.transform.localScale = Size;
                obj_.name = x.ToString() + ", " + y.ToString();
                obj_.transform.parent = this.transform;

                tilePositions.Add(obj_);

                // Corners
                if (Corners(x, y) != null){
                    GameObject tem = Instantiate(
                        Corners(x, y), 
                        new Vector2(
                            (x*(Size.x/1.6f)), 
                            (y*(Size.y/1.6f))), 
                        Quaternion.identity);

                    tem.transform.parent = this.transform;
                    tem.transform.localScale = Size/10f;
                } else

                // Walls
                if (Walls(x, y) != null){ // bassically remove wall infront of entrance point (bottom right corner)
                    GameObject tem = Instantiate(
                        Walls(x, y),
                        new Vector2(
                            (x*(Size.x/1.6f)), 
                            (y*(Size.y/1.6f))), 
                        Quaternion.identity);

                    tem.transform.parent = this.transform;
                    tem.transform.localScale = Size/10f;
                }
            }
        }

        // Enemies
        for (int e = 0; e < enemy_count; e++){
            GameObject enemy_ = PickEnemy(rarities);

            GameObject obj_ = Instantiate(
                    enemy_, 
                    tilePositions[Random.Range(0, tilePositions.Count)].transform.position, 
                    Quaternion.identity);
        }

        // Trash Pickups
        for (int e = 0; e < enemy_count*2; e++){
            GameObject item = trashPickups[Random.Range(0, trashPickups.Count)];

            GameObject obj_ = Instantiate(
                    item, 
                    tilePositions[Random.Range(0, 
                    tilePositions.Count)].transform.position + new Vector3(Random.Range(1, 10), 
                    Random.Range(1,10), 0), 
                    Quaternion.identity);
        }

        // Entrance trash pickups
        for (int e = 0; e < 10; e++){
            GameObject item = trashPickups[Random.Range(0, trashPickups.Count)];

            GameObject obj_ = Instantiate(
                    item, 
                    Player.transform.position + new Vector3(Random.Range(1, -80), 
                    Random.Range(40, 80), 0), 
                    Quaternion.identity);
        }

        // Door
        GameObject door = Instantiate(
            ExitDoor, 
            Centre.transform.position, 
            Quaternion.identity);

        door.GetComponent<Door>().Sound = Door_Audiosrc;
        door.GetComponent<Door>().screenFade = Door_fade;
    }
}
