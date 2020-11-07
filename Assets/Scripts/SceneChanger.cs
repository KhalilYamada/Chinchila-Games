using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
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
}

