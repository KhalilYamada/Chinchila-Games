using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{

    public GameObject []objetos;
    public int []alpha;
    public Animator[] Animators;

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


    public void VoltaMenu()
    {
        Invoke("VoltarMenu", 1);
    }
    public void VoltarMenu()
    {
        if (objetos[0].activeInHierarchy == true)
        objetos[2].GetComponent<Image>().color = new Color(255, 255, 255, 1f);
        objetos[3].GetComponent<Image>().color = new Color(255, 255, 255, 1f);
    }
}

