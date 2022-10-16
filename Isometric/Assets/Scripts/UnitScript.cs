using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;
using System.Text;


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
    public int team;
    public bool dead;
    public bool lob;
    public bool flight;

    //Hidden stats
    public Ease smoothMoveEase;
    bool canMoveAgain = true;
    public BoardScript board;
    public GameObject missile;
    [SerializeField] GameObject fireFromRanger;
    [SerializeField] GameObject fireFromLobber;
    public Sprite splashArt;
    public Sprite WarriorSplash1;
    public Sprite LobberSplash1;
    public Sprite RangerSplash1;
    public Sprite WarriorSplash2;
    public Sprite LobberSplash2;
    public Sprite RangerSplash2;
    public Sprite WarriorSplash3;
    public Sprite LobberSplash3;
    public Sprite RangerSplash3;
    //Upgrades
    public Upgrade upgrade1;
    public Upgrade upgrade2;
    //PARTICLES BABEYYYYYY
    public GameObject dropParticles;
    public TurnOrdererScript turnOrder;
    public GameObject jetParticles;

    public int deltaHealth;
    public bool hasMoved;
    public bool hasAttacked;

    public HealthbarScript healthbar;

    private void Start()
    {
        turnOrder = GameObject.Find("TurnOrderer").GetComponent<TurnOrdererScript>();
        board = turnOrder.board;
        

    }

    private void Update()
    {
        board = turnOrder.board;

        

        if (hp <= 0&& !dead)
        {
            if(board != null && board.allCells[(int)boardPosition.x, (int)boardPosition.y]!= null)
            {
                board.allCells[(int)boardPosition.x, (int)boardPosition.y].GetComponent<CellScript>().occupiedBy = null;
            }

            dead = true;
            transform.position = new Vector3(0,300,0);
        }
        if (board.allCells[(int)boardPosition.x, (int)boardPosition.y].GetComponent<CellScript>().highlightedAttack)
        {
            if(turnOrder.whosTurn == 1 && turnOrder.Player1.selectedUnit!= null)
            {
                deltaHealth = -turnOrder.Player1.selectedUnit.GetComponent<UnitScript>().damage;
            }
            else if(turnOrder.whosTurn == 2 && turnOrder.Player2.selectedUnit != null)
            {
                deltaHealth = -turnOrder.Player2.selectedUnit.GetComponent<UnitScript>().damage;
            }
        }
        else
        {
            deltaHealth = 0;
        }

    }


    //Moving
    public bool CanMoveToTile(BoardScript board, int x, int y, bool flight)
    {
        if (flight)
            return true;
        if(board.allCells[x, y].GetComponent<CellScript>().occupiedBy == null && !dead)
        {
            if(Mathf.Abs( boardPosition.x - x ) + Mathf.Abs( boardPosition.y - y) <= 1) 
                return true;
        }
        return false;
    }

 
    public IEnumerator MoveToTile(List<Vector2> path)
    {
        foreach(Vector2 cell in path)
        {
            while (!canMoveAgain)
            {
                yield return new WaitUntil(() => canMoveAgain);
            }

            if (CanMoveToTile(board, (int)cell.x, (int)cell.y, flight))
            {
                
                board.allCells[(int)boardPosition.x, (int)boardPosition.y].GetComponent<CellScript>().occupiedBy = null;

                RotateTowardsTile(new Vector3(BoardToRealPos((int)cell.x), transform.position.y, BoardToRealPos((int)cell.y)));
                canMoveAgain = false;
                while (!canMoveAgain)
                {
                    yield return new WaitUntil(() => canMoveAgain);
                }
                if(!flight)
                    transform.DOMove(new Vector3(BoardToRealPos((int)cell.x), 5, BoardToRealPos((int)cell.y)), 0.25f).SetEase(smoothMoveEase).OnComplete(() => { SetValuesAfterMove(board, (int)cell.x, (int)cell.y); });
                else
                    transform.DOMove(new Vector3(BoardToRealPos((int)cell.x), 30, BoardToRealPos((int)cell.y)), 0.25f).SetEase(smoothMoveEase).OnComplete(() => { SetValuesAfterMove(board, (int)cell.x, (int)cell.y); });
                canMoveAgain = false;
            }
        }
    
    }
    private void SetValuesAfterMove(BoardScript board, int x, int y)
    {
        board.allCells[x, y].GetComponent<CellScript>().occupiedBy = gameObject;
        boardPosition = new Vector2(x, y);
        canMoveAgain = true;
    }

    private void RotateTowardsTile(Vector3 realPosCell)
    {
        transform.DOLookAt(realPosCell, 0.2f).OnComplete(() => { canMoveAgain = true; });
    }

    //Attacking
    public IEnumerator Attack(BoardScript board, int x, int y)
    {
        if (!dead)
        {
            bool includeCenter;

                includeCenter = true;
            
            List<CellScript> affectedCells = PlayerScript.AllCellsInRadius(board, x, y, aoeRadius, includeCenter);

            RotateTowardsTile(new Vector3(BoardToRealPos(x), transform.position.y, BoardToRealPos(y)));
            canMoveAgain = false;
            while (!canMoveAgain)
            {
                yield return new WaitUntil(() => canMoveAgain);
            }

            if(charClass == "Ranger" || charClass == "Warrior")
                Instantiate(missile, fireFromRanger.transform.position, Quaternion.LookRotation(new Vector3(BoardToRealPos(x), transform.position.y, BoardToRealPos(y)) - transform.position)).GetComponent<ProjectileScript>().SetSpawnValues(new Vector3(x,y,5), affectedCells, gameObject.GetComponent<UnitScript>());
            if (charClass == "Lobber")
                Instantiate(missile, fireFromLobber.transform.position, Quaternion.LookRotation(new Vector3(BoardToRealPos(x), transform.position.y, BoardToRealPos(y)) - transform.position)).GetComponent<ProjectileScript>().SetSpawnValues(new Vector3(x, y, 5), affectedCells, gameObject.GetComponent<UnitScript>());

        }
       
    }

    //Spawning
    public bool SpawnBasic(Vector2 BoardPos, BoardScript board, string CharClass,int Hp, int Damage, int Speed, int MaxHP, int Range, bool HitsSelf, int AoeRadius, bool Lob, int Team, bool Flight)
    {
        boardPosition = BoardPos;
        flight = Flight; 
        charClass = CharClass;
        hp = Hp;
        damage = Damage;
        speed = Speed;
        maxHP = MaxHP;
        range = Range;
        hitsSelf = HitsSelf;
        aoeRadius = AoeRadius;
        team = Team;
        lob = Lob;
        if(team == 1)
        {
            GameObject.Find("Player1").GetComponent<PlayerScript>().units.Add(gameObject.GetComponent<UnitScript>());
        }
        else if(team == 2)
        {
            GameObject.Find("Player2").GetComponent<PlayerScript>().units.Add(gameObject.GetComponent<UnitScript>());
        }
        return true;
    }

    public void SpawnByClass(Vector2 BoardPos, string CharClass, int Team)
    {
        if(CharClass == "Warrior")
        {
            SpawnBasic(BoardPos, board, CharClass, 9, 2, 2, 9, 1, false, 0,false, Team, false);
            if (Team == 1)
            {
                splashArt = WarriorSplash1;
            }
            else if (Team == 2)
            {
                splashArt = WarriorSplash2;
            }
            else
            {
                splashArt = WarriorSplash3;
            }
            foreach (MeshRenderer rendr in GetComponentsInChildren<MeshRenderer>())
            {
                if (rendr.gameObject.tag == "Warrior1" && team == 1)
                {
                    rendr.enabled = true;
                    return;
                }
                if (rendr.gameObject.tag == "Warrior2" && team == 2)
                {
                    rendr.enabled = true;
                    return;
                }
            }
        }
        else if (CharClass == "Lobber")
        {
            SpawnBasic(BoardPos, board, CharClass, 7, 2, 1, 7, 2, true, 1, true, Team, false);
            if(Team == 1)
            {
                splashArt = LobberSplash1;
            }
            else if(Team == 2)
            {
                splashArt = LobberSplash2;
            }
            else
            {
                splashArt = LobberSplash3;
            }
            foreach (MeshRenderer rendr in GetComponentsInChildren<MeshRenderer>() )
            {
                if(rendr.gameObject.tag == "Lobber1" && team == 1)
                {
                    rendr.enabled = true;
                    return;
                }
                if (rendr.gameObject.tag == "Lobber2" && team == 2)
                {
                    rendr.enabled = true;
                    return;
                }
            }
            
        }
        else if (CharClass == "Ranger")
        {
            SpawnBasic(BoardPos, board, CharClass, 5, 3, 1, 5, 4, false, 0,false, Team, false);
            if (Team == 1)
            {
                splashArt = RangerSplash1;
            }
            else if (Team == 2)
            {
                splashArt = RangerSplash2;
            }
            else
            {
                splashArt = RangerSplash3;
            }
            foreach (MeshRenderer rendr in GetComponentsInChildren<MeshRenderer>())
            {
                if (rendr.gameObject.tag == "Ranger1" && team == 1)
                {
                    rendr.enabled = true;
                    return;
                }
                if (rendr.gameObject.tag == "Ranger2" && team == 2)
                {
                    rendr.enabled = true;
                    return;
                }
            }
        }
        else
        {
            SpawnBasic(BoardPos, board, CharClass, 5, 0, 0, 5, 0, false, 0, false, -1, false);
        }

    }

    public bool Respawn(Vector2 BoardPos, BoardScript Board)
    {
        dead = false;
        if (Board.allCells[(int)BoardPos.x,(int)BoardPos.y].GetComponent<CellScript>().occupiedBy == null )
        {
            RebuildUnit(BoardPos);
            
            transform.position = new Vector3(BoardToRealPos((int)BoardPos.x), 150f, BoardToRealPos((int)BoardPos.y));
            Board.allCells[(int)BoardPos.x, (int)BoardPos.y].GetComponent<CellScript>().occupiedBy = gameObject;
            if(!flight)
                transform.DOMoveY(20f, 1.3f).SetEase(Ease.OutQuad).OnComplete(() => { transform.DOMoveY(9f, 0.25f).SetEase(Ease.InQuad).OnComplete(() => { Instantiate(dropParticles, transform.position, Quaternion.identity); }); } );
            else
                transform.DOMoveY(30f, 1.3f).SetEase(Ease.OutQuad);
            if (team == 1)
            {
                GameObject.Find("Player1").GetComponent<PlayerScript>().unitsToDrop.Remove(gameObject.GetComponent<UnitScript>());
            }
            else
            {
                GameObject.Find("Player2").GetComponent<PlayerScript>().unitsToDrop.Remove(gameObject.GetComponent<UnitScript>());
            }
            return true;
        }
        return false;
    }

    public void RebuildUnit(Vector2 BoardPos)
    {
        
        if(team == 1)
        {
            GameObject.Find("Player1").GetComponent<PlayerScript>().units.Remove(gameObject.GetComponent<UnitScript>());
        }
        if (team == 2)
        {
            GameObject.Find("Player2").GetComponent<PlayerScript>().units.Remove(gameObject.GetComponent<UnitScript>());
        }
        SpawnByClass(BoardPos,  charClass, team);
        if(upgrade1 != null)
        {
            upgrade1.ApplyUpgrade(gameObject.GetComponent<UnitScript>());
            
        }
            
        if (upgrade2 != null)
            upgrade2.ApplyUpgrade(gameObject.GetComponent<UnitScript>());


    }

    //math
    public static int BoardToRealPos(int num)
    {
        return (num * 10) + 5;
    }

    //Pathfind (kill me)

    class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Cost { get; set; }
        public int Distance { get; set; }
        public int CostDistance => Cost + Distance;
        public Tile Parent { get; set; }

        //The distance is essentially the estimated distance, ignoring walls to our target. 
        //So how many tiles left and right, up and down, ignoring walls, to get there. 
        public void SetDistance(int targetX, int targetY)
        {
            this.Distance = Mathf.Abs(targetX - X) + Mathf.Abs(targetY - Y);
        }
    }

    //create map for pathfinder (yes i know its ineffecient shut up)
    private static List<string> MapMaker(GameObject[,] allCells, Vector2 initial, Vector2 final, bool flight)
    {
        int finalPositions = 0;
        List<string> result = new List<string>()
        {
            "        ",
            "        ",
            "        ",
            "        ",
            "        ",
            "        ",
            "        ",
            "        "
        };


        foreach (GameObject cell in allCells)
        {
            CellScript script = cell.GetComponent<CellScript>();
            if (script.boardPos == initial)
            {
                StringBuilder stringB = new StringBuilder(result[(int)script.boardPos.x]);
                stringB[(int)script.boardPos.y] = 'A';
                result[(int)script.boardPos.x] = stringB.ToString();
            }
            else if(script.occupiedBy != null && !flight)
            {
                StringBuilder stringB = new StringBuilder(result[(int)script.boardPos.x]);
                stringB[(int)script.boardPos.y] = 'X';
                result[(int)script.boardPos.x] = stringB.ToString();
            }
            else if (script.boardPos == final)
            {
                StringBuilder stringB = new StringBuilder(result[(int)script.boardPos.x]);
                stringB[(int)script.boardPos.y] = 'B';
                result[(int)script.boardPos.x] = stringB.ToString();
                finalPositions++;
            }
        }


        if (finalPositions == 1)
            return result;
        else
        {
            return null;
        }
    }
    private static List<Tile> GetWalkableCells(List<string> map, Tile start, Tile finish)
    {



        var possibleTiles = new List<Tile>()
        {
        new Tile { X = start.X, Y = start.Y - 1, Parent = start, Cost = start.Cost + 1 },
        new Tile { X = start.X, Y = start.Y + 1, Parent = start, Cost = start.Cost + 1},
        new Tile { X = start.X - 1, Y = start.Y, Parent = start, Cost = start.Cost + 1 },
        new Tile { X = start.X + 1, Y = start.Y, Parent = start, Cost = start.Cost + 1 },
        };

        possibleTiles.ForEach(tile => tile.SetDistance(finish.X, finish.Y));

        var maxX = map.First().Length - 1;
        var maxY = map.Count - 1;

        

        return possibleTiles
                .Where(tile => tile.X >= 0 && tile.X <= maxX)
                .Where(tile => tile.Y >= 0 && tile.Y <= maxY)
                .Where(tile => map[tile.Y][tile.X] == ' ' || map[tile.Y][tile.X] == 'B' )
                .ToList();




    }

    public static List<Vector2> Pathfind(GameObject[,] allCells, Vector2 initial, Vector2 final, bool flight)
    {
        List<Vector2> result = new List<Vector2>();

        List<string> map = MapMaker(allCells, initial, final, flight);

        if(map == null)
        {
            return null;
        }

        var start = new Tile();
        start.Y = map.FindIndex(x => x.Contains("A"));
        start.X = map[start.Y].IndexOf("A");

        var finish = new Tile();
        finish.Y = map.FindIndex(x => x.Contains("B"));
        finish.X = map[finish.Y].IndexOf("B");

        var activeTiles = new List<Tile>();
        activeTiles.Add(start);
        var visitedTiles = new List<Tile>();

        while (activeTiles.Any())
        {
            var checkTile = activeTiles.OrderBy(x => x.CostDistance).First();

           
          
            

            visitedTiles.Add(checkTile);
            activeTiles.Remove(checkTile);

            var walkableTiles = GetWalkableCells(map, checkTile, finish);

            foreach (var walkableTile in walkableTiles)
            {
                //We have already visited this tile so we don't need to do so again!
                if (visitedTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
                    continue;

                //It's already in the active list, but that's OK, maybe this new tile has a better value (e.g. We might zigzag earlier but this is now straighter). 
                if (activeTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
                {
                    var existingTile = activeTiles.First(x => x.X == walkableTile.X && x.Y == walkableTile.Y);
                    if (existingTile.CostDistance > checkTile.CostDistance)
                    {
                        activeTiles.Remove(existingTile);
                        activeTiles.Add(walkableTile);
                    }
                }
                else
                {
                    //We've never seen this tile before so add it to the list. 
                    activeTiles.Add(walkableTile);
                }
            }

            if (checkTile.X == finish.X && checkTile.Y == finish.Y)
            {
                //We found the destination and we can be sure (Because the the OrderBy above)
                //That it's the most low cost option. 
                var tile = checkTile;
                while (true)
                {
                    result.Add(new Vector2(tile.Y, tile.X));

                    if (map[tile.Y][tile.X] == ' ')
                    {
                        var newMapRow = map[tile.Y].ToCharArray();
                        newMapRow[tile.X] = '*';
                        map[tile.Y] = new string(newMapRow);
                    }
                    tile = tile.Parent;
                    if (tile == null)
                    {
                        break;
                    }

                }
            }

            if (checkTile.X == finish.X && checkTile.Y == finish.Y)
            {

                //We can actually loop through the parents of each tile to find our exact path which we will show shortly. 
                break;
            }

        }
       
   
        return Enumerable.Reverse(result).ToList();
    }

   
    


}
