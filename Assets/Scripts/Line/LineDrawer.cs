using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.UIElements;

public class LineDrawer : MonoBehaviour
{
    [HideInInspector]
    public LineRenderer lineRend; //pega o próprio line renderer

    [HideInInspector]
    private Vector2 mousePos; //Associa a posição do mouse

    [HideInInspector]
    public int qualVertex = 2; //Acho que precisa mudar o nome, diz em qual dos lugares a posição vai ser associada

    [SerializeField]
    public List<Tile> tilesList = new List<Tile>();


    public static int thisLine; //Serve para identificarmos qual das linhas estamos mexendo no momento


    /// <summary>
    /// 
    /// PRECISO CRIAR O CÓDIGO QUE VAI SER UTILIZADO PARA TROCAR ENTRE AS LINHAS, OU SEJA, SE EU CLICAR
    /// EM ALGUM BOTÃO OU SLA ELE VAI DEFINIR O "THIS LINE" COMO O NÚMERO DESSA LINHA (NÚMERO QUE SERÁ
    /// ASSOCIADO NO INSPECTOR)
    /// 
    /// </summary>

    void Awake()
    {
        lineRend = GetComponent<LineRenderer>();
        lineRend.positionCount = 1;
    }

    public void SetInitialPoint(Transform trans)
    {
        lineRend.positionCount = qualVertex + 1;

        lineRend.SetPosition(qualVertex, new Vector3(Mathf.Round(trans.position.x), Mathf.Round(trans.position.y), 0f));

        qualVertex++;
    }

    public void SetNewPoint()
    {
        lineRend.positionCount = qualVertex + 1;

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lineRend.SetPosition(qualVertex, new Vector3(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y), 0f));
        qualVertex++;
    }

    public void CanMove() //Verifica e ativa os tiles próximos, permitindo se mover para eles
    { 
        RaycastHit2D[] hitU = Physics2D.RaycastAll(tilesList.Last().GetComponent<Transform>().position, transform.TransformDirection(Vector3.up), 2);
        RaycastHit2D[] hitD = Physics2D.RaycastAll(tilesList.Last().GetComponent<Transform>().position, transform.TransformDirection(Vector3.down), 2);
        RaycastHit2D[] hitL = Physics2D.RaycastAll(tilesList.Last().GetComponent<Transform>().position, transform.TransformDirection(Vector3.left), 2);
        RaycastHit2D[] hitR = Physics2D.RaycastAll(tilesList.Last().GetComponent<Transform>().position, transform.TransformDirection(Vector3.right), 2);


        for (int i = 1; i < hitU.Length; i++)
        {
            //hitU[i].collider.GetComponent<SpriteRenderer>().color = Color.blue;
            //está como sprite rederer somente para verificar se está colidindo ou não
            if (hitU[i].collider.GetComponent<Tile>() != null)
            {
                hitU[i].collider.GetComponent<Tile>().isClose = true;
            }
        }
        for (int i = 1; i < hitD.Length; i++)
        {
            //hitD[i].collider.GetComponent<SpriteRenderer>().color = Color.blue;
            //está como sprite rederer somente para verificar se está colidindo ou não
            if (hitD[i].collider.GetComponent<Tile>() != null)
            {
                hitD[i].collider.GetComponent<Tile>().isClose = true;
            }
        }

        for (int i = 1; i < hitL.Length; i++)
        {
            //hitL[i].collider.GetComponent<SpriteRenderer>().color = Color.blue;
            //está como sprite rederer somente para verificar se está colidindo ou não
            if (hitL[i].collider.GetComponent<Tile>() != null)
            {
                hitL[i].collider.GetComponent<Tile>().isClose = true;
            }
        }

        for (int i = 1; i < hitR.Length; i++)
        {
            //hitR[i].collider.GetComponent<SpriteRenderer>().color = Color.blue;
            //está como sprite rederer somente para verificar se está colidindo ou não
            if (hitR[i].collider.GetComponent<Tile>() != null)
            {
                hitR[i].collider.GetComponent<Tile>().isClose = true;
            }
        }
    }
}


    /*
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            qualVertex = 1;
            lineRend.positionCount = qualVertex;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {

            for (int i = 0; i < lineManagerScript.tilesList.Count -1; i++)
            {
                lineManagerScript.tilesList[i].canRemove = false;
                lineManagerScript.tilesList[i].hasEntered = false;
            }
            qualVertex = 0;
            lineRend.positionCount = qualVertex;
        }
    }*/

