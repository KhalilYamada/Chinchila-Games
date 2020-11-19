using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Saves : MonoBehaviour
{
    public GameObject[] bloaqueadores;
    public GameObject[] medalhas;
    public GameObject[] cenasMenu;

    private static int e;

    public void Start()
    {
        e = 0;
        PlayerPrefs.SetInt("Dicas", 0);
        EstadoMenu();
    }

    private void Update()
    {
        PassouCena();
        SalvarEstadoMenu();
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

    void SalvarEstadoMenu()
    {
        for (int i = 0; i < cenasMenu.Length; i++)
        {
            if (cenasMenu[i].activeInHierarchy == true)
            {
                PlayerPrefs.SetInt("Cena " + i, 1);
            }
            else
                PlayerPrefs.SetInt("Cena " + i, 0);
        }
    }

    void EstadoMenu()
    {
        for (int i = 0; i < cenasMenu.Length; i++)
        {
            if (PlayerPrefs.GetInt("Cena " + i, 0) == 1)
            {
                cenasMenu[i].SetActive(true);
            }
            else
            {
                cenasMenu[i].SetActive(false);
                e++;
            }
            if (e == 4)
            {
                cenasMenu[0].SetActive(true);
                cenasMenu[1].SetActive(true);
            }
        }
    }

    private void OnApplicationQuit()
    {
        for (int i = 0; i < cenasMenu.Length; i++)
        {
            PlayerPrefs.DeleteKey("Cena " + i);
        }
    }

}
