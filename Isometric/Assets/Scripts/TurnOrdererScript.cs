using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOrdererScript : MonoBehaviour
{
    // Start is called before the first frame update
    int whosTurn;
    public bool spawnPhase;
    public bool shopPhase;
    public bool playPhase;
    public PlayerScript Player1;
    public bool hasMoved;
    public bool hasAttacked;
    public bool hasPlaced;
    public PlayerScript Player2;
    public GameObject unitPrefab;
    public BoardScript board;
    GameObject unit;
    void Start()
    {
        board = GameObject.FindGameObjectWithTag("Board").GetComponent<BoardScript>();
        unit = Instantiate(unitPrefab, new Vector3(1000, 1000, 1000), Quaternion.identity);
        unit.GetComponent<UnitScript>().SpawnByClass(new Vector2(0, 0), board, "Warrior", 1);
        unit.GetComponent<UnitScript>().dead = true;
        unit = Instantiate(unitPrefab, new Vector3(1000, 1000, 1000), Quaternion.identity);
        unit.GetComponent<UnitScript>().SpawnByClass(new Vector2(0, 0), board, "Warrior", 2);
        unit.GetComponent<UnitScript>().dead = true;
        SpawnPhaseStart(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnPhase)
        {
            if (hasPlaced)
            {
                if(whosTurn == 1)
                {
                    whosTurn = 2;
                    hasPlaced = false;
                    Player2.myTurn = true;
                    Player1.myTurn = false;
                    Player2.selectedUnitID = 0;

                }
                else
                {
                    whosTurn = 1;
                    hasPlaced = false;
                    Player1.myTurn = true;
                    Player2.myTurn = false;
                    Player1.selectedUnitID = 0;
                }
            }
                   
            
        }
    }

    public void SpawnPhaseStart(int startPlayer)
    {
        spawnPhase = true;
        shopPhase = false;
        playPhase = false;
        whosTurn = startPlayer;
        Player1.unitsToDrop = new List<UnitScript>();
        Player2.unitsToDrop = new List<UnitScript>();
        foreach (UnitScript Unit in Player1.units)
        {
            Player1.unitsToDrop.Add(Unit);
        }
        foreach (UnitScript Unit in Player2.units)
        {
            Player2.unitsToDrop.Add(Unit);
        }
        if (whosTurn == 2)
        {
            whosTurn = 2;
            hasPlaced = false;
            Player2.myTurn = true;
            Player1.myTurn = false;
            Player2.selectedUnitID = 0;

        }
        else
        {
            whosTurn = 1;
            hasPlaced = false;
            Player1.myTurn = true;
            Player2.myTurn = false;
            Player1.selectedUnitID = 0;
        }
    }



}
