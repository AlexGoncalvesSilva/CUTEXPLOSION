using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeMusicGame : MonoBehaviour
{

    private float BackGroundFloat;
    private AudioSource BackGroundAudio;
    private float EffectsGroundFloat;
    private AudioSource EffectsSoundsAudio;

    // Start is called before the first frame update
    void Start()
    {
        BackGroundAudio = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        EffectsSoundsAudio = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        BackGroundAudio.volume = VolumeSound.instance.BackGroundSlider.value;
        EffectsSoundsAudio.volume = VolumeSound.instance.SoundEffectsSlider.value;
    }
}
