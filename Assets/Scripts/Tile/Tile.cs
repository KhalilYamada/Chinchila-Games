using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Tile : MonoBehaviour
{

    /// <summary>
    /// 
    /// Para que um tile seja considerado "Inicial" ele precisa que a boolean seja marcada no inspector
    /// e também seja ativada a boolean "isOcupied", adicionei no void start, mas para garantir
    /// acionar no inspector também
    /// 
    /// 
    /// 
    /// </summary>

    [Header("Permições")]
    public bool isClose = false; //Se eu posso entrar nesse tile, ou seja, está próximo o suficiente, por padrão é falso pois "nenhum bloco está perto no início"
    public bool isOcupied; //Se esse tile já está ocupado por alguma das linhas
    public bool isLastTile; //Se esse tile for o último


    [Header("Todos os tiles")]
    public Tile[] allTilesList;


    [Header("Qual Linha")]
    public int linhaNoTile;
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
            linhaNoTile = qualLinhaTileInicial;

            isOcupied = true;
            isClose = true;

            lineScript[qualLinhaTileInicial].SetInitialPoint(transform);
            lineScript[qualLinhaTileInicial].lineTilesList.Add(thisTile);
            lineScript[qualLinhaTileInicial].CanMove();
        }
    }

    private void OnMouseDown()
    {
        if(isInitialTile == true)
        {
            ChangeLine();
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

        linhaNoTile = LineDrawer.thisLine; //PRECISO DEFINIR UM VALOR DEFAULT PRA VARIAVEL DE LINHA NO TILE

        lineScript[LineDrawer.thisLine].lineTilesList.Last().isLastTile = true;

        lineScript[LineDrawer.thisLine].SetNewPoint();
        lineScript[LineDrawer.thisLine].lineTilesList.Add(thisTile);  
        lineScript[LineDrawer.thisLine].CanMove();
    }


    private void Saiu()
    {
        //PRECISO RESETAR O VALOR DEFAULT DA VARIÁVEL DE LINHA NO TILE

        lineScript[LineDrawer.thisLine].lineTilesList.Last().linhaNoTile = 10;

        lineScript[LineDrawer.thisLine].lineTilesList.Last().isOcupied = false;

        lineScript[LineDrawer.thisLine].lineRend.positionCount = lineScript[LineDrawer.thisLine].lineRend.positionCount - 1;
        lineScript[LineDrawer.thisLine].qualVertex = lineScript[LineDrawer.thisLine].qualVertex - 1;
        lineScript[LineDrawer.thisLine].lineTilesList.Remove(lineScript[LineDrawer.thisLine].lineTilesList.Last());

        CleanMoves();

        if(isInitialTile == false)
        {
            lineScript[LineDrawer.thisLine].lineTilesList[lineScript[LineDrawer.thisLine].lineTilesList.Count() - 2].isLastTile = true;
        }

        lineScript[LineDrawer.thisLine].CanMove();
    }

    public void ChangeLine()
    {
        LineDrawer.thisLine = qualLinhaTileInicial;

        CleanMoves();
        if (lineScript[LineDrawer.thisLine].lineTilesList.Count() - 2 >= 0)
        {
            lineScript[LineDrawer.thisLine].lineTilesList[lineScript[LineDrawer.thisLine].lineTilesList.Count() - 2].isLastTile = true;
        }
        lineScript[LineDrawer.thisLine].CanMove();
    }

    public void CleanMoves() //Serve para "resetar" quais tiles o jogador pode mover para
    {
        for (int i = 0; i < allTilesList.Length; i++)
        {
            allTilesList[i].isClose = false;
            allTilesList[i].isLastTile = false;
        }
    }//Quando mudar de linha (ou seja, mudar da linha "prova adaptada" para a "mudar aluno de sala"), executar novamente o código "CanMove()"
}