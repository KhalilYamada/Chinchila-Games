using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [Header("Permições")]
    public bool isClose = false; //Se eu posso entrar nesse tile, ou seja, está próximo o suficiente, por padrão é falso pois "nenhum bloco está perto no início"
    public bool isOcupied; //Se esse tile já está ocupado por alguma das linhas
    public bool isLastCube; //Se esse tile for o último

    [Header("Todos os cubos")]
    public Tile[] tilesList;


    [Header("Qual Linha")]
    public int linhaNoTile;


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
        else if (LineDrawer.thisLine == linhaNoTile)
        {

        }
    }



    private void Entrou()
    {
        isOcupied = true;

        CleanMoves();


        linhaNoTile = LineDrawer.thisLine;

        

        lineScript[LineDrawer.thisLine].SetNewPoint();
        lineScript[LineDrawer.thisLine].tilesList.Add(thisTile); //estamos adaptando ainda, então está dando erro pela dessassociação        
        lineScript[LineDrawer.thisLine].CanMove();
    }


    private void Saiu()
    {

    }


    private void CleanMoves()
    {
        for (int i = 0; i < tilesList.Length; i++)
        {
            tilesList[i].isClose = false;
        }
    }//Quando mudar de linha (ou seja, mudar da linha "prova adaptada" para a "mudar aluno de sala"), executar novamente o código "CanMove()"
}