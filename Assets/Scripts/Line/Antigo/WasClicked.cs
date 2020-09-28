using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasClicked : MonoBehaviour
{

    /// <summary>
    /// 
    /// CÓDIGO DATADO, NÃO FOI DELETADO AINDA MAS ESTÁ EM DESUSO
    /// 
    /// </summary>
    


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
            hasEntered = true;
            canRemove = true;

            lineScript.SetNewPoint();
            //lineScript.tilesList.Add(esse);
            //lineScript.AtualizaContagem();

        }
        else if(lineScript.lineRend.positionCount > 1 && canRemove == true)
        {
            hasEntered = false;

            lineScript.lineRend.positionCount = lineScript.lineRend.positionCount - 1;
            lineScript.qualVertex = lineScript.qualVertex - 1;
            //lineScript.tilesList.Remove(esse);
            //lineScript.AtualizaContagemRemove();
        }
    }
}
