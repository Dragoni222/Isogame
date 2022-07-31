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
    public BoardScript board;
    public GameObject hoveredTile;
    public GameObject hoverTileGeneral;
    public CellScript hoverTileGeneralScript;
    private void Start()
    {
        selectedObjectAttack = null;
        selectedObjectMove = null;
        selectedUnit = null;
        selectedCell = null;
        hoveredTile = null;
    }
    void Update()
    {
        hoverTileGeneral = ClickSelect(Camera.main, 0);
        if(hoverTileGeneral != null)
            hoverTileGeneralScript = hoverTileGeneral.GetComponent<CellScript>();
        //Hover over
        if(hoveredTile != hoverTileGeneral && selectedObjectMove == null)
        {
            if(hoveredTile != null)
                hoveredTile.GetComponent<CellScript>().highlightedHover = false;

            hoveredTile = hoverTileGeneral;
            if (hoveredTile != null)
            {
                Debug.Log("hover highlight");
                hoveredTile.GetComponent<CellScript>().highlightedHover = true;
            }
        }
        else if (selectedObjectMove && hoveredTile != null)
        {
            hoveredTile.GetComponent<CellScript>().highlightedHover = false;
        }
        

        //On click, find an object that the ray from the camera hits. If on the board, highlight tile. 
        if (Input.GetButtonDown("leftclick"))
        {
            if( selectedObjectMove != null)
            {
                if(hoverTileGeneral != null)
                {
                    if(board.allCells[(int)hoverTileGeneralScript.boardPos.x, (int)hoverTileGeneralScript.boardPos.y].GetComponent<CellScript>().occupiedBy != null)
                    {
                        
                        selectedUnit = board.allCells[(int)hoverTileGeneralScript.boardPos.x, (int)hoverTileGeneralScript.boardPos.y].GetComponent<CellScript>().occupiedBy.GetComponent<UnitScript>();
                    }
                    else if (selectedUnit != null && selectedUnit.CanMoveToTile(board, (int)hoverTileGeneralScript.boardPos.x, (int)hoverTileGeneralScript.boardPos.y))
                    {
                        board.allCells[(int)selectedUnit.boardPosition.x, (int)selectedUnit.boardPosition.y].GetComponent<CellScript>().highlightedMove = false;
                        selectedUnit.MoveToTile(board, (int)hoverTileGeneralScript.boardPos.x, (int)hoverTileGeneralScript.boardPos.y);
                    }
                    selectedObjectMove.GetComponent<CellScript>().highlightedMove = false;
                    selectedObjectMove = hoverTileGeneral;
                    selectedObjectMove.GetComponent<CellScript>().highlightedMove = true;
                }
                else
                {
                    selectedObjectMove.GetComponent<CellScript>().highlightedMove = false;
                    selectedObjectMove = null;
                }
 
            }
            else
            {
                if (hoverTileGeneral != null)
                {
                    selectedObjectMove = hoverTileGeneral;
                    if(hoverTileGeneralScript.occupiedBy != null)
                    {
                        selectedUnit = hoverTileGeneralScript.occupiedBy.GetComponent<UnitScript>();
                    }
                }
                selectedObjectMove.GetComponent<CellScript>().highlightedMove = true;


            }

        }
        if (Input.GetButtonDown("rightclick"))
        {
           
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(unit, new Vector3(0,0,0), Quaternion.identity).GetComponent<UnitScript>().SpawnByClass(hoverTileGeneral.GetComponent<CellScript>().boardPos, board, "Warrior");
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
            Debug.Log(hit.transform.position.x + " " + hit.transform.position.z);
            return hit.transform.gameObject;
        }
        return null;
      

    }
    
}
