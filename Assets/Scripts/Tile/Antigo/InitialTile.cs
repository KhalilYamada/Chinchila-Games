using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialTile : MonoBehaviour
{
    /// <summary>
    /// 
    /// Ultrapassado
    /// 
    /// </summary>



    [Header("Qual linha isso está associado")]
    public int escolheLinha;



    [Header("Scripts")]
    public LineDrawer myLine;



    private void Start()
    {
        //myLine.lineRend.SetPosition(0, new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), 0f));
        
    }

    private void OnMouseDown()
    {
        LineDrawer.thisLine = escolheLinha;
        
        

        myLine.CanMove();
    }
}
