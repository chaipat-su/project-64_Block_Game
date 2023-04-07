using System;
using UnityEngine;


public class Audioset : MonoBehaviour
{
    private static readonly string bgPerf = "BackgroundPref";
    private static readonly string sfxPref = "SoundEffectsPref";
    private float bgSliderfloat,
        sfxsliderfloat;

    public AudioSource bgAudio;
    public AudioSource[] sfxAudio;
    

    void Awake() {
        ContinuesettingsChanged(); 
     }

    private void ContinuesettingsChanged() {
        bgSliderfloat = PlayerPrefs.GetFloat(bgPerf);
        sfxsliderfloat = PlayerPrefs.GetFloat(sfxPref);

        bgAudio.volume = bgSliderfloat;
        for (int i = 0; i < sfxAudio.Length; i++) {
            sfxAudio[i].volume = sfxsliderfloat;
        }
     }

}
