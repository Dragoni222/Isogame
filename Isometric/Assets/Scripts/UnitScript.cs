using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class UnitScript : MonoBehaviour
{
    public Vector2 boardPosition;
    public string charClass;
    
    //basic stats
    public int hp;
    public int damage;
    public int speed;
    public int maxHP;
    public int HP;
    public int range;

    //unique stats
    public bool hitsSelf;
    public int aoeRadius;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public bool CanMoveToTile(BoardScript board, int x, int y)
    {
        if(board.allCells[x, y].GetComponent<CellScript>().occupiedBy == null)
        {
            if(Mathf.Abs( boardPosition.x - x) <= 1 && Mathf.Abs(boardPosition.y - y) <= 1) 
                return true;
        }
        return false;
    }

    public void MoveToTile(BoardScript board, int x, int y)
    {
        if(CanMoveToTile(board, x, y))
        {
            transform.DOMove(new Vector3(BoardToRealPos(x), 5, BoardToRealPos(y)), 1).OnComplete(SetValuesAfterMove) ;
            
        }
    }

    private void SetValuesAfterMove()
    {

    }

    public static int BoardToRealPos(int num)
    {
        return (num * 10) + 5;
    }
}
