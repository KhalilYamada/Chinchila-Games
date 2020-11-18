using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{

    public GameObject []objetos;
    public GameObject []apagarEVoltar;

    public void Update()
    {
            IsConfigActive();
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
        objetos[0].SetActive(false);
    }


    /*public void VoltaMenu()
    {
        Invoke("VoltarMenu", 1);
    }
    public void VoltarMenu()
    {
        if (objetos[0].activeInHierarchy == true)
        objetos[2].GetComponent<Image>().color = new Color(255, 255, 255, 1f);
        objetos[3].GetComponent<Image>().color = new Color(255, 255, 255, 1f);
    }*/

    public void IsConfigActive()
    {
        if (objetos[4].activeInHierarchy == true)
        {
            foreach (GameObject gameObject in apagarEVoltar)
            {
                for (int i = 0; i < apagarEVoltar.Length; i++)
                {
                    apagarEVoltar[i].GetComponent<Button>().enabled = false;
                }
            }
            Time.timeScale = 0;
        }
        else
        {
            for (int i = 0; i < apagarEVoltar.Length; i++)
            {
                apagarEVoltar[i].GetComponent<Button>().enabled = true;
            }
            Time.timeScale = 1;
        }
    }
}

