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
    public GameObject BottomL;
    public GameObject BottomR;
    public GameObject TopL;
    public GameObject TopR;

    public List<GameObject> Level1 = new List<GameObject>();

    void Start() {
        GameObject Centre = new GameObject("Centre");
        Centre.transform.position = new Vector2((Amount/2f)-0.5f, (Amount/2f)-0.5f);

        for (int x = 0; x < Amount; x++){
            for (int y = 0; y < Amount; y++){
                GameObject obj_ = Instantiate(
                    Level1[Random.Range(0, Level1.Count)], 
                    new Vector2(
                        (x*(Size.x/1.6f)), 
                        (y*(Size.y/1.6f))), 
                    Quaternion.identity);

                obj_.transform.localScale = Size;
                obj_.name = x.ToString() + ", " + y.ToString();
                obj_.transform.parent = this.transform;

                // Bottom left
                if (x == 0 && y == 0){
                    GameObject corner = Instantiate(
                        BottomL, 
                        new Vector2(
                            (x*(Size.x/1.6f)), 
                            (y*(Size.y/1.6f))), 
                        Quaternion.identity);
                }

                // Bottom right
                if (x == Amount-1f && y == 0){
                    GameObject corner = Instantiate(
                        BottomR, 
                        new Vector2(
                            (x*(Size.x/1.6f)), 
                            (y*(Size.y/1.6f))), 
                        Quaternion.identity);
                }

                // Top right
                if (x == Amount-1f && y == Amount-1f){
                    GameObject corner = Instantiate(
                        TopR, 
                        new Vector2(
                            (x*(Size.x/1.6f)), 
                            (y*(Size.y/1.6f))),  
                        Quaternion.identity);
                }

                // Top left
                if (x == 0 && y == Amount-1f){
                    GameObject corner = Instantiate(
                        TopL, 
                        new Vector2(
                            (x*(Size.x/1.6f)), 
                            (y*(Size.y/1.6f))), 
                        Quaternion.identity);
                }
            }
        }
    }
}
