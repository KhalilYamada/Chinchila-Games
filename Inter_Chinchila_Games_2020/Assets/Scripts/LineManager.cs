using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    [SerializeField]
    public List<WasClicked> tilesList = new List<WasClicked>();

    public void AtualizaContagem()
    {
        for (int i = 0; i < tilesList.Count - 1; i++)
        {
            tilesList[i].canRemove = false;
        }
    }

    public void AtualizaContagemRemove()
    {
        tilesList[tilesList.Count - 1].canRemove = true;
    }
}
