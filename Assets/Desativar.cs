using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desativar : MonoBehaviour
{
    public GameObject thisObject;

    void Update()
    {
        if(thisObject.activeInHierarchy == true)
        {
            Invoke("DesativarObjeto", 1);
        }
    }

    void DesativarObjeto()
    {
        thisObject.SetActive(false);
    }
}
