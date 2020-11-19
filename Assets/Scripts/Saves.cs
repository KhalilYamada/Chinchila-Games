using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Saves : MonoBehaviour
{
    public GameObject[] bloaqueadores;
    public GameObject[] medalhas;

    public void Start()
    {
        PlayerPrefs.SetInt("Dicas", 0);
    }

    private void Update()
    {
        PassouCena();
    }

    void PassouCena()
    {
        if(PlayerPrefs.GetInt("Finished Fase 1 Prot") == 1)
        {
            bloaqueadores[0].SetActive(false);
            medalhas[0].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Finished Fase 2 Prot") == 1)
        {
            bloaqueadores[1].SetActive(false);
            medalhas[1].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Finished Fase 3 Prot") == 1)
        {
            medalhas[2].SetActive(true);
        }
    }

}
