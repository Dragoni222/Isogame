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

    //Hidden stats
    public Ease smoothMoveEase;
    bool canMoveAgain = true;
    private BoardScript board;
    public GameObject missile;
    private void Start()
    {
        board = GameObject.FindGameObjectWithTag("Board").GetComponent<BoardScript>();

        Pathfind(board.allCells, new Vector2(0,1), new Vector2(5,6));

    }

    private void Update()
    {
        if(hp<= 0)
        {
            board.allCells[(int)boardPosition.x, (int)boardPosition.y].GetComponent<CellScript>().occupiedBy = null;
            dead = true;
            gameObject.SetActive(false);
        }
    }


    //Moving
    public bool CanMoveToTile(BoardScript board, int x, int y)
    {
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
            if (CanMoveToTile(board, (int)cell.x, (int)cell.y))
            {
                
                board.allCells[(int)boardPosition.x, (int)boardPosition.y].GetComponent<CellScript>().occupiedBy = null;
                transform.DOMove(new Vector3(BoardToRealPos((int)cell.x), 5, BoardToRealPos((int)cell.y)), 0.25f).SetEase(smoothMoveEase).OnComplete(() => { SetValuesAfterMove(board, (int)cell.x, (int)cell.y); });
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

    //Attacking
    public void Attack(BoardScript board, int x, int y)
    {
        if (!dead)
        {
            bool includeCenter;
            if (charClass == "Warrior" && aoeRadius > 0)
            {
                includeCenter = false;
                x = (int)boardPosition.x;
                y = (int)boardPosition.y;
            }

            else
            {
                includeCenter = true;
            }
            List<CellScript> affectedCells = PlayerScript.AllCellsInRadius(board, x, y, aoeRadius, includeCenter);

            Instantiate(missile, transform.position, Quaternion.identity).GetComponent<ProjectileScript>().SetSpawnValues(new Vector3(x,y,5), affectedCells, gameObject.GetComponent<UnitScript>());

            
        }
       
    }

    //Spawning
    public bool SpawnBasic(Vector2 BoardPos, BoardScript board, string CharClass,int Hp, int Damage, int Speed, int MaxHP, int Range, bool HitsSelf, int AoeRadius, bool Lob, int Team)
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
        team = Team;
        lob = Lob;
        return true;
    }

    public void SpawnByClass(Vector2 BoardPos, BoardScript board, string CharClass, int Team)
    {
        if(CharClass == "Warrior")
        {
            SpawnBasic(BoardPos, board, CharClass, 9, 2, 6, 9, 1, false, 0,false, Team);
        }
        if (CharClass == "Lobber")
        {
            SpawnBasic(BoardPos, board, CharClass, 7, 2, 1, 7, 2, true, 1, true, Team);
            
        }
        if (CharClass == "Ranger")
        {
            SpawnBasic(BoardPos, board, CharClass, 5, 3, 1, 5, 4, false, 0,false, Team);
        }
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
    private static List<string> MapMaker(GameObject[,] allCells, Vector2 initial, Vector2 final)
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
            else if(script.occupiedBy != null)
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
                .Where(tile => map[tile.Y][tile.X] == ' ' || map[tile.Y][tile.X] == 'B')
                .ToList();




    }

    public static List<Vector2> Pathfind(GameObject[,] allCells, Vector2 initial, Vector2 final)
    {
        List<Vector2> result = new List<Vector2>();

        List<string> map = MapMaker(allCells, initial, final);

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
