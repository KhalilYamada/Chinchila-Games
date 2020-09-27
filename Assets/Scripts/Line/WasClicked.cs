using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasClicked : MonoBehaviour
{
    public LineDrawer lineScript;
    [HideInInspector]public bool hasEntered;
    public bool canRemove = false;
    
    public LineManager lineManagerScript;

    private WasClicked esse;

    private void Start()
    {
        esse = GetComponent<WasClicked>();
    }

    private void OnMouseEnter()
    {
        if (!hasEntered)
        {
            lineScript.SetNewPoint();
            hasEntered = true;
            lineScript.tilesList.Add(esse);
            canRemove = true;
            lineScript.AtualizaContagem();

        }
        else if(lineScript.lineRend.positionCount > 1 && canRemove == true)
        {
            lineScript.lineRend.positionCount = lineScript.lineRend.positionCount - 1;
            lineScript.qualVertex = lineScript.qualVertex - 1;
            hasEntered = false;
            lineScript.tilesList.Remove(esse);
            lineScript.AtualizaContagemRemove();
        }
    }
}
