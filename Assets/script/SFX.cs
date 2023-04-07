using UnityEngine.UI;
using UnityEngine;

public class SFX : MonoBehaviour
{
    private static readonly string FirstPlay = "First Play";
    private static readonly string bgPerf = "BackgroundPref";
    private static readonly string sfxPref = "SoundEffectsPref";
    private int firstPlayint;
    public Slider bgSlider,
        sfxslider;
    private float bgSliderfloat,
        sfxsliderfloat;

    public AudioSource bgAudio;
    public AudioSource[] sfxAudio;

    void Start()
    {
        firstPlayint = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayint == 0)
        {
            bgSliderfloat = .125f;
            sfxsliderfloat = .75f;

            bgSlider.value = bgSliderfloat;
            sfxslider.value = sfxsliderfloat;
            PlayerPrefs.SetFloat(bgPerf, bgSliderfloat);
            PlayerPrefs.SetFloat(sfxPref, sfxsliderfloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else {
            bgSliderfloat = PlayerPrefs.GetFloat(bgPerf);
            bgSlider.value = bgSliderfloat;
            sfxsliderfloat = PlayerPrefs.GetFloat(sfxPref);
            sfxslider.value = sfxsliderfloat;
         }
    }

    public void SetSoundSave() {
        PlayerPrefs.SetFloat(bgPerf,bgSlider.value);
        PlayerPrefs.SetFloat(sfxPref,sfxslider.value);
    }

    void OnApplicationFocus(bool focus) {
        if (!focus) {
            SetSoundSave();
        }
    }

    public void UpdateSound() {
        bgAudio.volume = bgSlider.value;
        for (int i = 0; i < sfxAudio.Length; i++) {
            sfxAudio[i].volume = sfxslider.value;
        }
        
    }
}
