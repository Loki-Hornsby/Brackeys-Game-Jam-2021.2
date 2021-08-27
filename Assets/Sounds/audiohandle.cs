using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiohandle : MonoBehaviour{
    public static AudioSource source;

    void Start(){
        source = GetComponent<AudioSource>();
    }

    public static IEnumerator FadeOut (float FadeTime) {
        float startVolume = source.volume;
 
        while (source.volume > 0) {
            source.volume -= startVolume * Time.deltaTime / FadeTime;
 
            yield return null;
        }
 
        source.Stop ();
        source.volume = startVolume;
    }
}
