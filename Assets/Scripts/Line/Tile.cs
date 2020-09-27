using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [Header("Permições")]
    public bool isClose = false; //Se eu posso entrar nesse tile, ou seja, está próximo o suficiente, por padrão é falso pois "nenhum bloco está perto no início"
    public bool isOcupied; //Se esse tile já está ocupado por alguma das linhas


    [Header("Qual Linha")]
    static int qualLinha;


    [Header("Scripts")] 
    public LineDrawer[] lineScript;
    private Tile thisTile;



    private void Start()
    {
        thisTile = GetComponent<Tile>();
    }



    private void OnMouseEnter()
    {
        if (isClose == true && isOcupied == false)
        {
            Entrou();
        }
    }



    private void Entrou()
    {
        isOcupied = true;
        isClose = false;
        lineScript[qualLinha].SetNewPoint();
        lineScript[qualLinha].tilesList.Add(thisTile); //estamos adaptando ainda, então está dando erro pela dessassociação
        lineScript[qualLinha].AtualizaContagem();
        lineScript[qualLinha].CanMove();
    }


    private void CleanMoves()
    {

    }
}