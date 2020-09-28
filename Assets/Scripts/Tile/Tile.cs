using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Tile : MonoBehaviour
{
    [Header("Permições")]
    public bool isClose = false; //Se eu posso entrar nesse tile, ou seja, está próximo o suficiente, por padrão é falso pois "nenhum bloco está perto no início"
    public bool isOcupied; //Se esse tile já está ocupado por alguma das linhas
    public bool isLastTile; //Se esse tile for o último


    [Header("Todos os tiles")]
    public Tile[] tilesList;


    [Header("Qual Linha")]
    public int linhaNoTile;
    private int linhaDefault = 10;
    public int qualLinhaTileInicial;
    public bool isInitialTile;


    [Header("Scripts")] 
    public LineDrawer[] lineScript;
    private Tile thisTile;



    private void Start()
    {
        thisTile = GetComponent<Tile>();
        if (isInitialTile == true)
        {
            lineScript[qualLinhaTileInicial].SetInitialPoint(transform);
            lineScript[qualLinhaTileInicial].tilesList.Add(thisTile);
            lineScript[qualLinhaTileInicial].CanMove();
        }
    }

    private void OnMouseDown()
    {
        if(isInitialTile == true)
        {
            LineDrawer.thisLine = qualLinhaTileInicial;
        }
    }

    private void OnMouseEnter()
    {
        if ((isClose == true && isOcupied == false) && isInitialTile == false)
        {
            Entrou();
        }
        else if (LineDrawer.thisLine == linhaNoTile && isOcupied == true && isLastTile == true)
        {
            Saiu();
        }
    }

    private void Entrou()
    {
        isOcupied = true;

        CleanMoves();

       // linhaNoTile = LineDrawer.thisLine; //PRECISO DEFINIR UM VALOR DEFAULT PRA VARIAVEL DE LINHA NO TILE

        lineScript[LineDrawer.thisLine].tilesList.Last().isLastTile = true;

        lineScript[LineDrawer.thisLine].SetNewPoint();
        lineScript[LineDrawer.thisLine].tilesList.Add(thisTile);  
        lineScript[LineDrawer.thisLine].CanMove();
    }


    private void Saiu()
    {
        //PRECISO RESETAR O VALOR DEFAULT DA VARIÁVEL DE LINHA NO TILE

        //linhaNoTile = linhaDefault;

        lineScript[LineDrawer.thisLine].tilesList.Last().isOcupied = false;

        lineScript[LineDrawer.thisLine].lineRend.positionCount = lineScript[LineDrawer.thisLine].lineRend.positionCount - 1;
        lineScript[LineDrawer.thisLine].qualVertex = lineScript[LineDrawer.thisLine].qualVertex - 1;
        lineScript[LineDrawer.thisLine].tilesList.Remove(lineScript[LineDrawer.thisLine].tilesList.Last());

        CleanMoves();

        lineScript[LineDrawer.thisLine].tilesList[lineScript[LineDrawer.thisLine].tilesList.Count() - 2].isLastTile = true;



        lineScript[LineDrawer.thisLine].CanMove();
    }


    public void CleanMoves() //Serve para "resetar" quais tiles o jogador pode mover para
    {
        for (int i = 0; i < tilesList.Length; i++)
        {
            tilesList[i].isClose = false;
            tilesList[i].isLastTile = false;
        }
    }//Quando mudar de linha (ou seja, mudar da linha "prova adaptada" para a "mudar aluno de sala"), executar novamente o código "CanMove()"
}