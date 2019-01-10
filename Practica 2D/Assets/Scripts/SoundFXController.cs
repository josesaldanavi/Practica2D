using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXController : MonoBehaviour {

    //vamos a traer los efectos de sonido
    public AudioClip[] audioClip;
    AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // audio[0]
    public void ChoqueCoche()
    {
        audio.clip = audioClip[0];
        audio.Play();
    }

    public void TerminoJuego()
    {
        audio.clip = audioClip[1];
        audio.Play();
    }
}
