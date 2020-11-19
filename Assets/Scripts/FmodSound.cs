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
    public GameObject[] soundMute;
    public GameObject menuConfig;

    void Start()
    {
        Musicas = FMODUnity.RuntimeManager.GetBus("bus:/Mestre/Musicas");
        Efeitos = FMODUnity.RuntimeManager.GetBus("bus:/Mestre/Efeitos");
        sliders[0].GetComponent<Slider>().value = PlayerPrefs.GetFloat("volumeMusica");
        sliders[1].GetComponent<Slider>().value = PlayerPrefs.GetFloat("volumeEfeitos");
        if (PlayerPrefs.GetInt("musicMuted", 1) == 0) soundMute[0].SetActive(true);
        if (PlayerPrefs.GetInt("efeitosMuted", 1) == 0) soundMute[1].SetActive(true);
    }

    void Update()
    {
        Musicas.setVolume(PlayerPrefs.GetFloat("volumeMusica"));
        Efeitos.setVolume(PlayerPrefs.GetFloat("volumeEfeitos"));
        Mute();
    }

    public void MusicVolumeLevel(float newMusicVolume)
    {
        MusicVolume = newMusicVolume;
        PlayerPrefs.SetFloat("volumeMusica", newMusicVolume);
        PlayerPrefs.SetInt("musicMuted", 1);
    }

    public void EfeitosVolumeLevel(float newEfeitosVolume)
    {
        EfeitosVolume = newEfeitosVolume;
        PlayerPrefs.SetFloat("volumeEfeitos", newEfeitosVolume);
        PlayerPrefs.SetInt("efeitosMuted", 1);

    }

    public void Mute()
    {
        if (menuConfig.activeInHierarchy)
        {
            if (soundMute[0].activeInHierarchy)
            {
                MusicVolume = 0f;
                PlayerPrefs.SetFloat("volumeMusica", 0f);
                PlayerPrefs.SetInt("musicMuted", 0);
                sliders[0].GetComponent<Slider>().enabled = false;
            }
            else
            {
                PlayerPrefs.SetFloat("volumeMusica", sliders[0].GetComponent<Slider>().value);
                PlayerPrefs.SetInt("musicMuted", 1);
                sliders[0].GetComponent<Slider>().enabled = true;
            }

            if (soundMute[1].activeInHierarchy)
            {
                EfeitosVolume = 0f;
                PlayerPrefs.SetFloat("volumeEfeitos", 0f);
                PlayerPrefs.SetInt("efeitosMuted", 0);
                sliders[1].GetComponent<Slider>().enabled = false;
            }
            else
            {
                PlayerPrefs.SetInt("efeitosMuted", 1);
                PlayerPrefs.SetFloat("volumeEfeitos", sliders[1].GetComponent<Slider>().value);
                sliders[1].GetComponent<Slider>().enabled = true;
            }
        }
    }
}
