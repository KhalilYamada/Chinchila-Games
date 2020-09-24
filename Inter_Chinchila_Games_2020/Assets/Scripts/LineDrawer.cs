using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineDrawer : MonoBehaviour
{

    [HideInInspector] public LineRenderer lineRend;
    private Vector2 mousePos;

    [HideInInspector]public int qualVertex;

    public LineManager lineManagerScript;



    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        lineRend.positionCount = 0;
    }

    public void SetNewPoint()
    {
        lineRend.positionCount = qualVertex + 1;

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lineRend.SetPosition(qualVertex, new Vector3(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y), 0f));
        qualVertex++;
    }

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
    }
}
