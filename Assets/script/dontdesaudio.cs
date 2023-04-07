using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdesaudio : MonoBehaviour{ 
    public static dontdesaudio instance;
    [SerializeField] private AudioSource _musicSource;
    
    void Awake() {

        if (instance == null)
        instance = this;
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(transform.gameObject);   
    }


    public void onMusic(){
        _musicSource.Play();
    }

    public void ToggleMusic(){
        _musicSource.Stop();
    }
    
    public void ChangeMasterVolume(float value) {
        AudioListener.volume = value;
    }
}
