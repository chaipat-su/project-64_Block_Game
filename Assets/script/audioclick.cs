using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioclick : MonoBehaviour
{
    public AudioSource Saudio;
    
    public void playButton(){
        Saudio.Play();
    }
}
