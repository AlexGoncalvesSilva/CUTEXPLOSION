using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeMusicGame : MonoBehaviour
{

    private float BackGroundFloat;
    private AudioSource BackGroundAudio;
    private float EffectsSoundsFloat;
    private AudioSource EffectsSoundsAudio;

    // Start is called before the first frame update
    void Start()
    {
        BackGroundAudio = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        EffectsSoundsAudio = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
     
    }

    // Update is called once per frame
    public void UpdateSound()
    {
        BackGroundAudio.volume = VolumeSound.instance.BackGroundSlider.value;
        EffectsSoundsAudio.volume = VolumeSound.instance.SoundEffectsSlider.value;
    }
}
