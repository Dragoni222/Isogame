using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject selectedObjectAttack;
    public GameObject selectedObjectMove;
    public UnitScript selectedUnit;
    public CellScript selectedCell;
    public GameObject unit;
    private BoardScript board;
    public GameObject hoveredTile;
    public GameObject hoverTileGeneral;
    public CellScript hoverTileGeneralScript;
    private int hoverRad;
    private bool hoverExtend = true;
    public List<Vector2> hoverPath;
    public List<UnitScript> units;
    public List<UnitScript> unitsToDrop;
    public int selectedUnitID = 0;
    public bool myTurn;
    TurnOrdererScript turnOrder;
    private void Start()
    {
        //units = new List<UnitScript>();
        turnOrder = GameObject.FindGameObjectWithTag("turnOrder").GetComponent<TurnOrdererScript>();
        selectedObjectAttack = null;
        selectedObjectMove = null;
        selectedUnit = null;
        selectedCell = null;
        hoveredTile = null;
        board = GameObject.FindGameObjectWithTag("Board").GetComponent<BoardScript>();
        
    }
    void Update()
    {


        if (myTurn)
        {
            hoverTileGeneral = ClickSelect(Camera.main, 0);
            if (hoverTileGeneral != null)
                hoverTileGeneralScript = hoverTileGeneral.GetComponent<CellScript>();
            if (turnOrder.attackPhase)
            {
                if (selectedUnit != null)
                {
                    if (!InRadius(selectedUnit.boardPosition, hoverTileGeneralScript.boardPos, selectedUnit.range) && selectedObjectAttack != null)
                    {
                        hoverExtend = false;
                    }
                    else if (selectedObjectAttack != null)
                    {
                        hoverExtend = true;

                    }
                    else if (selectedObjectMove != null)
                    {
                        hoverExtend = false;

                        hoverPath = UnitScript.Pathfind(board.allCells, selectedUnit.boardPosition, hoverTileGeneralScript.boardPos);
                        if (hoverPath != null && units.Contains(selectedUnit.GetComponent<UnitScript>()))
                        {
                            foreach (Vector2 cell in hoverPath)
                            {
                                board.allCells[(int)cell.x, (int)cell.y].GetComponent<CellScript>().highlightedHover = true;
                            }
                        }



                    }
                }
                else
                {
                    hoverExtend = false;
                }
                //Hover over
                if (hoveredTile != hoverTileGeneral)
                {
                    if (hoveredTile != null)
                    {
                        DehighlightAll(board, "yellow");
                        DehighlightAll(board, "green");
                        DehighlightAll(board, "red");
                    }




                    hoveredTile = hoverTileGeneral;
                    if (hoveredTile != null)
                    {
                        if (hoverExtend)
                            HighlightAllCellsInRadius(board, (int)hoveredTile.GetComponent<CellScript>().boardPos.x, (int)hoveredTile.GetComponent<CellScript>().boardPos.y, hoverRad, true, "red", false);
                        else if(hoveredTile.GetComponent<CellScript>().occupiedBy == null)
                            HighlightAllCellsInRadius(board, (int)hoveredTile.GetComponent<CellScript>().boardPos.x, (int)hoveredTile.GetComponent<CellScript>().boardPos.y, 0, true, "yellow", false);
                        else if( units.Contains(hoveredTile.GetComponent<CellScript>().occupiedBy.GetComponent<UnitScript>()))
                            HighlightAllCellsInRadius(board, (int)hoveredTile.GetComponent<CellScript>().boardPos.x, (int)hoveredTile.GetComponent<CellScript>().boardPos.y, 0, true, "green", false);
                        else
                            HighlightAllCellsInRadius(board, (int)hoveredTile.GetComponent<CellScript>().boardPos.x, (int)hoveredTile.GetComponent<CellScript>().boardPos.y, 0, true, "red", false);

                    }
                }
                else if (selectedObjectAttack && selectedObjectMove && hoveredTile != null)
                {
                    DehighlightAll(board, "yellow");
                    DehighlightAll(board, "red");
                }


                //On click, find an object that the ray from the camera hits. If on the board, highlight tile. 
                if (Input.GetButtonDown("leftclick"))
                {
                    DehighlightAll(board, "blue");
                    DehighlightAll(board, "red");
                    hoverRad = 0;
                    if (selectedObjectAttack != null)
                        selectedObjectAttack.GetComponent<CellScript>().highlightedAttack = false;
                    selectedObjectAttack = null;
                    if (selectedObjectMove != null)
                    {
                        if (hoverTileGeneral != null)
                        {
                            if (board.allCells[(int)hoverTileGeneralScript.boardPos.x, (int)hoverTileGeneralScript.boardPos.y].GetComponent<CellScript>().occupiedBy != null && selectedUnit == null)
                            {
                                //Initial click on unit (DO SAME THING IN BELOW PART)
                       
                                selectedUnit = board.allCells[(int)hoverTileGeneralScript.boardPos.x, (int)hoverTileGeneralScript.boardPos.y].GetComponent<CellScript>().occupiedBy.GetComponent<UnitScript>();

                                 HighlightAllCellsInRadius(board, (int)selectedUnit.boardPosition.x, (int)selectedUnit.boardPosition.y, selectedUnit.speed, false, "blue", false);


                            }
                            else if (selectedUnit != null && InRadius(selectedUnit.boardPosition, hoverTileGeneralScript.boardPos, selectedUnit.speed) && selectedUnit.boardPosition != hoverTileGeneralScript.boardPos)
                            {
                                //Clicking on square other than another player or off the board (PUT MOVE METHOD HERE)
                                if (units.Contains(selectedUnit.GetComponent<UnitScript>()))
                                {
                                    board.allCells[(int)selectedUnit.boardPosition.x, (int)selectedUnit.boardPosition.y].GetComponent<CellScript>().highlightedAttack = false;
                                    selectedUnit.StartCoroutine(selectedUnit.MoveToTile(hoverPath));
                                    turnOrder.hasMoved = true;
                                    selectedObjectMove = null;
                                    selectedUnit = null;
                                    selectedCell = null;
                                }
                                

                            }
                            selectedObjectMove = hoverTileGeneral;
                        }
                        else
                        {
                            selectedObjectMove = null;
                        }

                    }
                    else
                    {
                        if (hoverTileGeneral != null)
                        {
                            selectedObjectMove = hoverTileGeneral;
                            if (hoverTileGeneralScript.occupiedBy != null)
                            {
                                //Initial click on unit (DO SAME THING IN ABOVE PART)

                                selectedUnit = hoverTileGeneralScript.occupiedBy.GetComponent<UnitScript>();

                                HighlightAllCellsInRadius(board, (int)selectedUnit.boardPosition.x, (int)selectedUnit.boardPosition.y, selectedUnit.speed, false, "blue", false);

                            }
                        }



                    }

                }
                if (Input.GetButtonDown("rightclick"))
                {
                    Debug.Log("right click");
                    DehighlightAll(board, "blue");
                    hoverRad = 0;
                    if (selectedObjectMove != null)
                        selectedObjectMove.GetComponent<CellScript>().highlightedMove = false;
                    selectedObjectMove = null;
                    if (selectedObjectAttack != null)
                    {
                        if (hoverTileGeneral != null)
                        {
                            if (board.allCells[(int)hoverTileGeneralScript.boardPos.x, (int)hoverTileGeneralScript.boardPos.y].GetComponent<CellScript>().occupiedBy != null && selectedUnit == null)
                            {
                                //Initial click on unit (DO SAME THING IN BELOW PART)
                                DehighlightAll(board, "blue");
                                DehighlightAll(board, "red");
                                selectedUnit = board.allCells[(int)hoverTileGeneralScript.boardPos.x, (int)hoverTileGeneralScript.boardPos.y].GetComponent<CellScript>().occupiedBy.GetComponent<UnitScript>();

                                HighlightAllCellsInRadius(board, (int)selectedUnit.boardPosition.x, (int)selectedUnit.boardPosition.y, selectedUnit.range, false, "blue", false);

                                hoverRad = selectedUnit.aoeRadius;

                            }
                            else if (selectedUnit != null && InRadius(selectedUnit.boardPosition, hoverTileGeneralScript.boardPos, selectedUnit.range))
                            {
                                //Clicking on square other than another player or off the board (PUT ATTACK METHOD HERE)
                                if (units.Contains(selectedUnit.GetComponent<UnitScript>()))
                                {
                                    board.allCells[(int)selectedUnit.boardPosition.x, (int)selectedUnit.boardPosition.y].GetComponent<CellScript>().highlightedAttack = false;
                                    selectedUnit.Attack(board, (int)hoverTileGeneralScript.boardPos.x, (int)hoverTileGeneralScript.boardPos.y);
                                    turnOrder.hasAttacked = true;
                                    DehighlightAll(board, "blue");
                                    selectedObjectAttack = null;
                                    selectedUnit = null;
                                    selectedCell = null;
                                }
                                

                            }
                            selectedObjectAttack = hoverTileGeneral;
                        }
                        else
                        {
                            selectedObjectAttack = null;
                        }

                    }
                    else
                    {
                        if (hoverTileGeneral != null)
                        {
                            selectedObjectAttack = hoverTileGeneral;
                            if (hoverTileGeneralScript.occupiedBy != null)
                            {
                                //Initial click on unit (DO SAME THING IN ABOVE PART)
                                DehighlightAll(board, "blue");
                                DehighlightAll(board, "red");
                                selectedUnit = hoverTileGeneralScript.occupiedBy.GetComponent<UnitScript>();
                               
                                HighlightAllCellsInRadius(board, (int)selectedUnit.boardPosition.x, (int)selectedUnit.boardPosition.y, selectedUnit.range, false, "blue", false);

                                hoverRad = selectedUnit.aoeRadius;
                            }
                        }



                    }

                }
               
            }
            else if (turnOrder.spawnPhase)
            {
                if (hoveredTile != hoverTileGeneral)
                {
                    if (hoveredTile != null)
                    {
                        DehighlightAll(board, "yellow");
                    }




                    hoveredTile = hoverTileGeneral;
                    if (hoveredTile != null)
                    {
                        if (hoveredTile.GetComponent<CellScript>().occupiedBy == null)
                            HighlightAllCellsInRadius(board, (int)hoveredTile.GetComponent<CellScript>().boardPos.x, (int)hoveredTile.GetComponent<CellScript>().boardPos.y, 0, true, "yellow", false);
                        else
                        {
                            HighlightAllCellsInRadius(board, (int)hoveredTile.GetComponent<CellScript>().boardPos.x, (int)hoveredTile.GetComponent<CellScript>().boardPos.y, 0, true, "red", false);
                        }
                    }
                }


                if (Input.GetButtonDown("leftclick") && hoverTileGeneral != null)
                {
                    if(unitsToDrop[selectedUnitID].Respawn(hoverTileGeneralScript.boardPos, board))
                    {
                        turnOrder.hasPlaced = true;
                    }

                }
                if (Input.GetButtonDown("rightclick"))
                {
                    if(selectedUnitID + 1 < unitsToDrop.Count)
                        selectedUnitID++;
                    else
                        selectedUnitID = 0;
                    
                }
            }
            
        }
      


    }
    //returns Vector2 of board pos

    public GameObject ClickSelect(Camera mainCam, int layer)
    {
        int layerMask = 1 << layer;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 500, layerMask))
        {
            return hit.transform.gameObject;
        }
        return null;


    }

    public static List<CellScript> AllCellsInRadius(BoardScript board, int x, int y, int radius, bool includeCenter)
    {
        List<CellScript> finalList = new List<CellScript>();
  

        foreach (GameObject cell in board.allCells)
        {
            if (InRadius(cell.GetComponent<CellScript>().boardPos, new Vector2(x, y), radius))
            {
                finalList.Add(cell.GetComponent<CellScript>());
            }

        }
        if (!includeCenter)
            finalList.Remove(board.allCells[x, y].GetComponent<CellScript>());



        return finalList;
    }

    public void HighlightAllCellsInRadius(BoardScript board, int x, int y, int radius, bool includeCenter, string color, bool uncolor)
    {
        List<CellScript> cellsToHighlight = AllCellsInRadius(board, x, y, radius, includeCenter);

        foreach (CellScript cell in cellsToHighlight)
        {
            if (uncolor)
            {
                if (color == "blue")
                    cell.highlightedRange = false;
                else if (color == "red")
                    cell.highlightedAttack = false;
                else if (color == "yellow")
                    cell.highlightedHover = false;
                else if (color == "green")
                    cell.highlightedMove = false;
            }
            else
            {
                if (color == "blue")
                    cell.highlightedRange = true;
                else if (color == "red")
                    cell.highlightedAttack = true;
                else if (color == "yellow")
                    cell.highlightedHover = true;
                else if (color == "green")
                    cell.highlightedMove = true;
            }

        }



    }

    public static bool InRadius(Vector2 cell1, Vector2 cell2, int radius)
    {
        float dist = Vector2.Distance(cell1, cell2);
        if (dist <= radius)
        {
            return true;
        }
        return false;
    }
    public void DehighlightAll(BoardScript board, string color)
    {
        foreach(GameObject cell in board.allCells)
        {

            if (color == "blue")
                cell.GetComponent<CellScript>().highlightedRange = false;
            else if (color == "red")
                cell.GetComponent<CellScript>().highlightedAttack = false;
            else if (color == "yellow")
                cell.GetComponent<CellScript>().highlightedHover = false;
            else if (color == "green")
                cell.GetComponent<CellScript>().highlightedMove = false;
        }
    }
    
}
