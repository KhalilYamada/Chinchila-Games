using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LineDrawer : MonoBehaviour
{
    [HideInInspector]
    public LineRenderer lineRend; //pega o próprio line renderer

    [HideInInspector]
    private Vector2 mousePos; //Associa a posição do mouse

    [HideInInspector]
    public int qualVertex; //Acho que precisa mudar o nome, diz em qual dos lugares a posição vai ser associada

    [SerializeField]
    public LineManager lineManagerScript;

    [SerializeField]
    public List<WasClicked> tilesList = new List<WasClicked>();



    



    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        lineRend.positionCount = 0;

    }


    private void Update()
    {
        CanMove();
    }


    public void SetNewPoint()
    {
        lineRend.positionCount = qualVertex + 1;

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lineRend.SetPosition(qualVertex, new Vector3(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y), 0f));
        qualVertex++;
    }

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


    public void CanMove()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            RaycastHit2D[] hitU = Physics2D.RaycastAll(tilesList.Last().GetComponent<Transform>().position, transform.TransformDirection(Vector3.up), 2);
            RaycastHit2D[] hitD = Physics2D.RaycastAll(tilesList.Last().GetComponent<Transform>().position, transform.TransformDirection(Vector3.down), 2);
            RaycastHit2D[] hitL = Physics2D.RaycastAll(tilesList.Last().GetComponent<Transform>().position, transform.TransformDirection(Vector3.left), 2);
            RaycastHit2D[] hitR = Physics2D.RaycastAll(tilesList.Last().GetComponent<Transform>().position, transform.TransformDirection(Vector3.right), 2);



            for (int i = 1; i < hitU.Length; i++)
            {
                hitU[i].collider.GetComponent<SpriteRenderer>().color = Color.blue;
            }


            for (int i = 1; i < hitD.Length; i++)
            {
                hitD[i].collider.GetComponent<SpriteRenderer>().color = Color.blue;
            }

            for (int i = 1; i < hitL.Length; i++)
            {
                hitL[i].collider.GetComponent<SpriteRenderer>().color = Color.blue;
            }

            for (int i = 1; i < hitR.Length; i++)
            {
                hitR[i].collider.GetComponent<SpriteRenderer>().color = Color.blue;
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

