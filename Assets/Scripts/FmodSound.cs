using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FmodSound : MonoBehaviour
{
    FMOD.Studio.Bus Musicas;
    FMOD.Studio.Bus Efeitos;
    float MusicVolume;
    float EfeitosVolume;
    public GameObject[] sliders;

    void Awake()
    {
        Musicas = FMODUnity.RuntimeManager.GetBus("bus:/Mestre/Musicas");
        Efeitos = FMODUnity.RuntimeManager.GetBus("bus:/Mestre/Efeitos");
        sliders[0].GetComponent<Slider>().value = PlayerPrefs.GetFloat("volumeMusica");
        sliders[1].GetComponent<Slider>().value = PlayerPrefs.GetFloat("volumeEfeitos");
        //MusicVolume = PlayerPrefs.GetFloat("volumeMusica");
        //EfeitosVolume = PlayerPrefs.GetFloat("volumeEfeitos");
    }

    void Update()
    {
        Musicas.setVolume(PlayerPrefs.GetFloat("volumeMusica"));
        Efeitos.setVolume(PlayerPrefs.GetFloat("volumeEfeitos"));
    }

    public void MusicVolumeLevel(float newMusicVolume)
    {
        MusicVolume = newMusicVolume;
        PlayerPrefs.SetFloat("volumeMusica", newMusicVolume);
    }

    public void EfeitosVolumeLevel(float newEfeitosVolume)
    {
        EfeitosVolume = newEfeitosVolume;
        PlayerPrefs.SetFloat("volumeEfeitos", newEfeitosVolume);

    }
}
