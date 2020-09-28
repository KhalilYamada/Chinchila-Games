using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialTile : MonoBehaviour
{

    public int escolheLinha;

    private void OnMouseEnter()
    {
        LineDrawer.thisLine = escolheLinha;
    }
}
