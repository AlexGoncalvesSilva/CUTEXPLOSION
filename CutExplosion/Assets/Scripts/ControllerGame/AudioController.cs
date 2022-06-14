using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    private AudioSource audioSource;

    public AudioClip coinSound;
    public AudioClip dashSound;
    public AudioClip downSound;
    public AudioClip jumpSound;
    public AudioClip deadSound;
    public AudioClip gameOverSound;
    public AudioClip bolhaSound;
    public AudioClip arrowSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySFX(AudioClip sfx)
    {
        audioSource.PlayOneShot(sfx);
    }
}
