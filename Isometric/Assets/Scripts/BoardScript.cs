using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BoardScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[,] allCells = new GameObject[8,8];
    public GameObject cellPrefab;
    [SerializeField] GameObject[] blockers;
    public GridMap map;

    void Start()
    {

        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                allCells[x, y] = Instantiate(cellPrefab, new Vector3(BoardToRealPos(x), 1f, BoardToRealPos(y)), Quaternion.identity);
                allCells[x, y].GetComponent<CellScript>().SetValues(new Vector2(x, y), null);
                allCells[x, y].transform.parent = gameObject.transform;



            }
        }
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {

                if (map.blockedCells[x].rowdata[y])
                {
                    int randomBlock = UnityEngine.Random.Range(0, blockers.Length);
                    Instantiate(blockers[randomBlock], new Vector3(BoardToRealPos(x), 5, BoardToRealPos(y)), Quaternion.identity).GetComponent<UnitScript>().Respawn(new Vector2(x, y), this);
                }

            }
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static int BoardToRealPos(int num)
    {
        return (num * 10) + 5;
    }



}
