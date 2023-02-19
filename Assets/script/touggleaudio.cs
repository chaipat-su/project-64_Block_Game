using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touggleaudio : MonoBehaviour
{
    [SerializeField] private bool _toggleMusic, _onMusic;

    public void Toggle(){
        if(_onMusic) dontdesaudio.instance.onMusic();
        if(_toggleMusic) dontdesaudio.instance.ToggleMusic();
    }
}
