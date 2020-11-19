﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Saves : MonoBehaviour
{
    public GameObject[] bloaqueadores;
    void PassouCena1()
    {
        if(PlayerPrefs.GetInt("Finished " + SceneManager.GetSceneByName("Fase 1 Prot"),1) == 1)
        {
            bloaqueadores[0].SetActive(false);
        }
    }

    void PassouCena2()
    {
        if (PlayerPrefs.GetInt("Finished " + SceneManager.GetSceneByName("Fase 2 Prot"), 1) == 1)
        {
            bloaqueadores[1].SetActive(false);
        }
    }

}
