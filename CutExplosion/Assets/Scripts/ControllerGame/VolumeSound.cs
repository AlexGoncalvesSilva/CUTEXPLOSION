using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSound : MonoBehaviour
{

    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackGroundPref = "BackGroundPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    private int firstPlayInt;
    public float BackGroundFloat, SoundEffectsFloat;
    public Slider BackGroundSlider, SoundEffectsSlider;
    private AudioSource BackGroundAudio;
    private AudioSource SoundEffectsAudio;

    public static VolumeSound instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        BackGroundAudio = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0)
        {
            BackGroundFloat = 1f;
            SoundEffectsFloat = 1f;
            BackGroundSlider.value = BackGroundFloat;
            SoundEffectsSlider.value = SoundEffectsFloat;
            PlayerPrefs.SetFloat(BackGroundPref, BackGroundFloat);
            PlayerPrefs.SetFloat(SoundEffectsPref, SoundEffectsFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            BackGroundFloat = PlayerPrefs.GetFloat(BackGroundPref);
            BackGroundSlider.value = BackGroundFloat;
            SoundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);
            SoundEffectsSlider.value = SoundEffectsFloat;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BackGroundPref, BackGroundSlider.value);
        PlayerPrefs.SetFloat(SoundEffectsPref, SoundEffectsSlider.value);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        BackGroundAudio.volume = BackGroundSlider.value;
    }
}
