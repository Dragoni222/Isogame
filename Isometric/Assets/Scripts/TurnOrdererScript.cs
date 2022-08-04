using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TurnOrdererScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int whosTurn;
    public bool spawnPhase;
    public bool shopPhase;
    public bool attackPhase;
    public PlayerScript Player1;
    public bool hasMoved;
    public bool hasAttacked;
    public bool hasPlaced;
    public bool hasBought;
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
    public Shop shop;
    [SerializeField] TurnChangeScript turnChanger;
    public List<GameObject> boardPrefabs;



    void Start()
    {
        int randomBoard = Random.Range(0, boardPrefabs.Count);
        board = Instantiate(boardPrefabs[randomBoard], new Vector3(40, -1.7f, 40), Quaternion.identity).GetComponent<BoardScript>();
        unit = Instantiate(unitPrefab, new Vector3(1000, 1000, 1000), Quaternion.identity);
        unit.GetComponent<UnitScript>().SpawnByClass(new Vector2(0, 0), "Lobber", 1);
        unit.GetComponent<UnitScript>().dead = true;
        unit = Instantiate(unitPrefab, new Vector3(1000, 1000, 1000), Quaternion.identity);
        unit.GetComponent<UnitScript>().SpawnByClass(new Vector2(0, 0), "Lobber", 2);
        unit.GetComponent<UnitScript>().dead = true;

        unit = Instantiate(unitPrefab, new Vector3(1000, 1000, 1000), Quaternion.identity);
        unit.GetComponent<UnitScript>().SpawnByClass(new Vector2(0, 0), "Ranger", 1);
        unit.GetComponent<UnitScript>().dead = true;
        unit = Instantiate(unitPrefab, new Vector3(1000, 1000, 1000), Quaternion.identity);
        unit.GetComponent<UnitScript>().SpawnByClass(new Vector2(0, 0), "Ranger", 2);
        unit.GetComponent<UnitScript>().dead = true;

        endTurnButton.GetComponent<Button>().onClick.AddListener(TaskOnClick);
        SpawnPhaseStart(1,true);
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
                    turnChanger.ChangeTurn(2);
                    whosTurn = 2;
                    hasPlaced = false;
                    Player2.myTurn = true;
                    Player1.myTurn = false;
                    Player2.selectedUnitID = 0;

                }
                else
                {
                    turnChanger.ChangeTurn(1);
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
                    AttackPhaseStart(1);
                else
                    AttackPhaseStart(2);
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
                    turnChanger.ChangeTurn(2);
                    whosTurn = 2;
                    hasAttacked = false;
                    hasMoved = false;
                    Player2.myTurn = true;
                    Player1.myTurn = false;
                }
                else if (whosTurn == 2)
                {
                    turnChanger.ChangeTurn(1);
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
            foreach (UnitScript Unit2 in Player2.units)
            {
                if (Unit2 != null)
                {
                    if (!Unit2.dead)
                    {
                        player2UnitAliveTemp = true;
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
                Player2.money += 3;
                Player1.money += 4;
                ShopPhaseStart(1);
            }
            if (!player2UnitAlive)
            {
                player1Score++;
                Player1.money += 3;
                Player2.money += 4;
                ShopPhaseStart(2);
            }


        }
        else if (shopPhase)
        {
            if((Player1.money <= 0||endTurn) && whosTurn == 1)
            {
                hasBought = true;
            }
            else if ((Player2.money <= 0||endTurn) && whosTurn == 2)
            {
                hasBought = true;
            }

            if ((Player1.money <= 0 && Player2.money <= 0) || ( (Player2.money <= 0 || endTurn) && whosTurn == 2 && Player1.money <= 0) || ((Player1.money <= 0 || endTurn) && whosTurn == 1 && Player2.money <= 0))
            {
                SpawnPhaseStart(whosTurn,false);
            }

            if (hasBought)
            {
                if (whosTurn == 1)
                {
                    turnChanger.ChangeTurn(2);
                    whosTurn = 2;
                    hasBought = false;
                    Player2.myTurn = true;
                    Player1.myTurn = false;
                    Player2.selectedUnitID = 0;

                }
                else
                {
                    turnChanger.ChangeTurn(1);
                    whosTurn = 1;
                    hasBought = false;
                    Player1.myTurn = true;
                    Player2.myTurn = false;
                    Player1.selectedUnitID = 0;
                }
            }
        }
    }


    public void SpawnPhaseStart(int startPlayer, bool firstBoard)
    {
        shop.DestroyShop();
        spawnPhase = true;
        shopPhase = false;
        attackPhase = false;
        whosTurn = startPlayer;
        Player1.unitsToDrop = new List<UnitScript>();
        Player2.unitsToDrop = new List<UnitScript>();

        if (!firstBoard)
        {
            Destroy(board);
            int randomBoard = Random.Range(0, boardPrefabs.Count);
            board = Instantiate(boardPrefabs[randomBoard], new Vector3(40, -1.7f, 40), Quaternion.identity).GetComponent<BoardScript>();
        }
        foreach (GameObject unit in GameObject.FindGameObjectsWithTag("Unit"))
        {
            unit.GetComponent<UnitScript>().hp = 0;
        }



        foreach (MeshRenderer rendr in board.GetComponentsInChildren<MeshRenderer>())
        {
            if (rendr.gameObject.name == "Wall1" || rendr.gameObject.name == "Wall2")
                rendr.enabled = true;
        }
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
        foreach (MeshRenderer rendr in board.gameObject.GetComponentsInChildren<MeshRenderer>())
        {
            if (rendr.gameObject.name == "Wall1" || rendr.gameObject.name == "Wall2")
                rendr.enabled = false;
        }
        if (whosTurn == 1)
        {
            hasAttacked = false;
            hasMoved = false;
            Player2.myTurn = false;
            Player1.myTurn = true;
        }
        else if (whosTurn == 2)
        {
            hasAttacked = false;
            hasMoved = false;
            Player2.myTurn = true;
            Player1.myTurn = false;
        }
    }

    public void ShopPhaseStart(int startPlayer)
    {
        endTurnButton.SetActive(true);
        spawnPhase = false;
        shopPhase = true;
        attackPhase = false;
        whosTurn = startPlayer;
        if (whosTurn == 1)
        {
            whosTurn = 2;
            Player2.myTurn = true;
            Player1.myTurn = false;
        }
        else if (whosTurn == 2)
        {
            whosTurn = 1;
            Player2.myTurn = false;
            Player1.myTurn = true;
        }

        shop.ResetShop();


    }

    void TaskOnClick()
    {

       endTurn = true;
    }


}
