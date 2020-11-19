using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public GameObject telaInicial;
    public GameObject []menus;
    public GameObject []apagarEVoltarBotoes;
    public GameObject []apagarEVoltarColliders;
    public GameObject[] apagarEVoltarObjects;

    public void Update()
    {
        DeactivateButtons();
        DeactivateColliders();
        DeactivateObjects();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Cena1()
    {
        SceneManager.LoadScene("Fase 1 Prot");
    }

    public void Cena2()
    {
        SceneManager.LoadScene("Fase 2 Prot");
    }

    public void Cena3()
    {
        SceneManager.LoadScene("Fase 3 Prot");
    }

    public void Quit()
    {
        Debug.Log("Saiu");
        Application.Quit();
    }


    public void Delay()
    {
        Invoke("DelayMenu", 1);
    }

    public void DelayMenu()
    {
        telaInicial.SetActive(false);
    }

    public void DoYouHaveClues()
    {
        if(PlayerPrefs.GetInt("Dicas") == 0)
        {
            menus[2].SetActive(true);
        }
        if (PlayerPrefs.GetInt("Dicas") != 0)
        {
            menus[3].SetActive(true);
        }
    }

    public void DeactivateButtons()
    {
            for (int i = 0; i < menus.Length; i++)
            {
                if (menus[i].activeInHierarchy == true)
                {
                        for (int e = 0; e < apagarEVoltarBotoes.Length; e++)
                        {
                            apagarEVoltarBotoes[e].GetComponent<Button>().enabled = false;
                        }
                    Time.timeScale = 0;
                break;
                }
                else
                {
                    for (int e = 0; e < apagarEVoltarBotoes.Length; e++)
                    {
                        apagarEVoltarBotoes[e].GetComponent<Button>().enabled = true;
                    }
                    Time.timeScale = 1;
                }
            }
    }
    public void DeactivateColliders()
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].activeInHierarchy == true)
            {
                for (int e = 0; e < apagarEVoltarColliders.Length; e++)
                {
                    apagarEVoltarColliders[e].GetComponent<BoxCollider>().enabled = false;
                }
                Time.timeScale = 0;
                break;
            }
            else
            {
                for (int e = 0; e < apagarEVoltarColliders.Length; e++)
                {
                    apagarEVoltarColliders[e].GetComponent<BoxCollider>().enabled = true;
                }
                Time.timeScale = 1;
            }
        }
    }

    public void DeactivateObjects()
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].activeInHierarchy == true)
            {
                for (int e = 0; e < apagarEVoltarObjects.Length; e++)
                {
                    apagarEVoltarObjects[e].SetActive(false);
                }
                Time.timeScale = 0;
                break;
            }
            else
            {
                for (int e = 0; e < apagarEVoltarObjects.Length; e++)
                {
                    apagarEVoltarObjects[e].SetActive(true);
                }
                Time.timeScale = 1;
            }
        }
    }
}

