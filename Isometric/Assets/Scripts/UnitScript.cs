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
    public int range;

    //unique stats
    public bool hitsSelf;
    public int aoeRadius;

    //Hidden stats
    public Ease smoothMoveEase;
    bool canMoveAgain = true;

    //moving
    public bool CanMoveToTile(BoardScript board, int x, int y)
    {
        if(board.allCells[x, y].GetComponent<CellScript>().occupiedBy == null)
        {
            if(Mathf.Abs( (boardPosition.x - x) + (boardPosition.y - y)) <= 1) 
                return true;
        }
        return false;
    }
    public void MoveToTile(BoardScript board, int x, int y)
    {
        if(CanMoveToTile(board, x, y) && canMoveAgain)
        {
            board.allCells[(int)boardPosition.x, (int)boardPosition.y].GetComponent<CellScript>().occupiedBy = null;
            transform.DOMove(new Vector3(BoardToRealPos(x), 5, BoardToRealPos(y)), 1).SetEase(smoothMoveEase).OnComplete(() => { SetValuesAfterMove(board, x, y); });
            canMoveAgain = false;
        }
    }
    private void SetValuesAfterMove(BoardScript board, int x, int y)
    {
        board.allCells[x, y].GetComponent<CellScript>().occupiedBy = gameObject;
        boardPosition = new Vector2(x, y);
        canMoveAgain = true;
    }

    //Spawning
    public bool SpawnBasic(Vector2 BoardPos, BoardScript board, string CharClass,int Hp, int Damage, int Speed, int MaxHP, int Range, bool HitsSelf, int AoeRadius)
    {
        boardPosition = BoardPos;
        if(CanMoveToTile(board, (int)boardPosition.x, (int)boardPosition.y))
        {
            transform.position = new Vector3(BoardToRealPos((int)BoardPos.x), 5.5f, BoardToRealPos((int)BoardPos.y));
            board.allCells[(int)BoardPos.x, (int)BoardPos.y].GetComponent<CellScript>().occupiedBy = gameObject;
        }
       
        charClass = CharClass;
        hp = Hp;
        damage = Damage;
        speed = Speed;
        maxHP = MaxHP;
        range = Range;
        hitsSelf = HitsSelf;
        aoeRadius = AoeRadius;
        return true;
    }

    public void SpawnByClass(Vector2 BoardPos, BoardScript board, string CharClass)
    {
        if(CharClass == "Warrior")
        {
            SpawnBasic(BoardPos,board, charClass, 9, 2, 2, 9, 1, false, 0);
        }
        if (CharClass == "Lobber")
        {
            Debug.Log("boom");
            SpawnBasic(BoardPos, board, charClass, 7, 2, 1, 7, 2, true, 1);
        }
    }

    //math
    public static int BoardToRealPos(int num)
    {
        return (num * 10) + 5;
    }
}
