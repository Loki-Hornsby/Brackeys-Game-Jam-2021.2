using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour{
    [Header("Modifiers")]
    public int Amount;
    public Vector2 Size;

    public int BranchAmountRange;
    public int BranchSizeRange;
    [Space(10)]

    [Header("Edges")]
    public GameObject BottomLeftCorner;
    public GameObject BottomRightCorner;
    public GameObject TopLeftCorner;
    public GameObject TopRightCorner;
    [Space(10)]
    public GameObject LeftWall;
    public GameObject RightWall;
    public GameObject TopWall;
    public GameObject BottomWall;
    [Space(10)]

    [Header("Levels")]
    public List<GameObject> Level1_tiles = new List<GameObject>();
    private List<GameObject> tiles = new List<GameObject>();
    
    public List<GameObject> Level1_enemies = new List<GameObject>();
    public List<GameObject> Level1_props = new List<GameObject>();

    private GameObject Corners(int x, int y){
        // Bottom left Corner
        if (x == 0 && y == 0){
            return BottomLeftCorner;
        } else 

        // Bottom right Corner
        if (x == Amount-1f && y == 0){
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

    GameObject PickEnemy(){
        return Level1_enemies[Random.Range(0, Level1_enemies.Count)];
    }

    void Start() {
        // Tiles
        GameObject Centre = new GameObject("Centre");
        Centre.transform.position = new Vector2((Amount/2f)-0.5f, (Amount/2f)-0.5f);
        
        for (int x = 0; x < Amount; x++){
            for (int y = 0; y < Amount; y++){
                GameObject obj_ = Instantiate(
                    Level1_tiles[Random.Range(0, Level1_tiles.Count)], 
                    new Vector2(
                        (x*(Size.x/1.6f)), 
                        (y*(Size.y/1.6f))), 
                    Quaternion.identity);

                obj_.transform.localScale = Size;
                obj_.name = x.ToString() + ", " + y.ToString();
                obj_.transform.parent = this.transform;
                tiles.Add(obj_);

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

                if (Walls(x, y) != null){
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
        int enemy_count = Random.Range(1, 200);

        for (int e = 0; e < enemy_count; e++){
            GameObject enemy_ = PickEnemy();

            GameObject obj_ = Instantiate(
                    enemy_, 
                    tiles[Random.Range(0, tiles.Count)].transform.position, 
                    Quaternion.identity);
        }
    }
}
