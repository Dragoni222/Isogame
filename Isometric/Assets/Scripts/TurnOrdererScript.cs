using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TurnOrdererScript : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] int whosTurn;
    public bool spawnPhase;
    public bool shopPhase;
    public bool attackPhase;
    public PlayerScript Player1;
    public bool hasMoved;
    public bool hasAttacked;
    public bool hasPlaced;
    public PlayerScript Player2;
    public GameObject unitPrefab;
    public BoardScript board;
    GameObject unit;
    public bool player1UnitAlive;
    public bool player2UnitAlive;
    public bool player1UnitAliveTemp;
    public bool player2UnitAliveTemp;
    public int player1Score;
    public int player2Score;
    public bool endTurn;
    public GameObject endTurnButton;
    void Start()
    {
        board = GameObject.FindGameObjectWithTag("Board").GetComponent<BoardScript>();
        unit = Instantiate(unitPrefab, new Vector3(1000, 1000, 1000), Quaternion.identity);
        unit.GetComponent<UnitScript>().SpawnByClass(new Vector2(0, 0), board, "Lobber", 1);
        unit.GetComponent<UnitScript>().dead = true;
        unit = Instantiate(unitPrefab, new Vector3(1000, 1000, 1000), Quaternion.identity);
        unit.GetComponent<UnitScript>().SpawnByClass(new Vector2(0, 0), board, "Lobber", 2);
        unit.GetComponent<UnitScript>().dead = true;

        unit = Instantiate(unitPrefab, new Vector3(1000, 1000, 1000), Quaternion.identity);
        unit.GetComponent<UnitScript>().SpawnByClass(new Vector2(0, 0), board, "Ranger", 1);
        unit.GetComponent<UnitScript>().dead = true;
        unit = Instantiate(unitPrefab, new Vector3(1000, 1000, 1000), Quaternion.identity);
        unit.GetComponent<UnitScript>().SpawnByClass(new Vector2(0, 0), board, "Ranger", 2);
        unit.GetComponent<UnitScript>().dead = true;

        endTurnButton.GetComponent<Button>().onClick.AddListener(TaskOnClick);
        SpawnPhaseStart(1);
    }

    // Update is called once per frame
    void Update()
    {
     

        if (spawnPhase)
        {
            endTurnButton.SetActive(false);
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
            
            if(Player1.unitsToDrop.Count == 0 && Player2.unitsToDrop.Count == 0)
            {
                if(whosTurn == 1)
                    AttackPhaseStart(2);
                else
                    AttackPhaseStart(1);
                spawnPhase = false;

            }
            else if(Player1.unitsToDrop.Count == 0)
            {
                whosTurn = 2;
                hasPlaced = false;
                Player2.myTurn = true;
                Player1.myTurn = false;
                Player2.selectedUnitID = 0;
            }
            else if (Player2.unitsToDrop.Count == 0)
            {
                whosTurn = 1;
                hasPlaced = false;
                Player1.myTurn = true;
                Player2.myTurn = false;
                Player1.selectedUnitID = 0;
            }
            
        }
        else if (attackPhase)
        {
            endTurnButton.SetActive(true);
            if (endTurn)
            {
                if(whosTurn == 1)
                {
                    whosTurn = 2;
                    hasAttacked = false;
                    hasMoved = false;
                    Player2.myTurn = true;
                    Player1.myTurn = false;
                }
                else if (whosTurn == 2)
                {
                    whosTurn = 1;
                    hasAttacked = false;
                    hasMoved = false;
                    Player2.myTurn = false;
                    Player1.myTurn = true;
                }
                endTurn = false;
            }


            player1UnitAliveTemp = false;
            foreach (UnitScript Unit in Player1.units)
            {
                if(Unit != null)
                {
                    if (!Unit.dead)
                    {
                        player1UnitAliveTemp = true;
                        return;
                    }
                }
            }
            if (player1UnitAliveTemp)
            {
                player1UnitAlive = true;
            }
            else
            {
                player1UnitAlive = false;
            }


            player2UnitAliveTemp = false;
            foreach (UnitScript Unit in Player2.units)
            {
                if (Unit != null)
                {
                    if (!Unit.dead)
                    {
                        player2UnitAliveTemp = true;
                        return;
                    }
                }
            }
            if (player2UnitAliveTemp)
            {
                player2UnitAlive = true;
            }
            else
            {
                player2UnitAlive = false;
            }

            if(!player1UnitAlive)
            {
                player2Score++;
                //PUT SHOP PHASE START HERE
            }
            if (!player2UnitAlive)
            {
                player1Score++;
                //PUT SHOP PHASE START HERE
            }


        }
    }

    public void SpawnPhaseStart(int startPlayer)
    {
        spawnPhase = true;
        shopPhase = false;
        attackPhase = false;
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

    public void AttackPhaseStart(int startPlayer)
    {
        spawnPhase = false;
        shopPhase = false;
        attackPhase = true;
        whosTurn = startPlayer;
        player1UnitAlive = true;
        player2UnitAlive = true;
        player1UnitAliveTemp = true;
        player2UnitAliveTemp = true;
        if (whosTurn == 1)
        {
            whosTurn = 2;
            hasAttacked = false;
            hasMoved = false;
            Player2.myTurn = true;
            Player1.myTurn = false;
        }
        else if (whosTurn == 2)
        {
            whosTurn = 1;
            hasAttacked = false;
            hasMoved = false;
            Player2.myTurn = false;
            Player1.myTurn = true;
        }
    }

    void TaskOnClick()
    {

       endTurn = true;
    }


}
