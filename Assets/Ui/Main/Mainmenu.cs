using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour{
    public void Load(){
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
