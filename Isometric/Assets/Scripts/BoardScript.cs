using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[,] allCells = new GameObject[8,8];
    public GameObject cellPrefab;
    void Start()
    {
        for( int x = 0; x < 8; x++)
        {
            for(int y = 0; y < 8; y++)
            {
                allCells[x, y] = Instantiate(cellPrefab, new Vector3(BoardToRealPos(x), 3f, BoardToRealPos(y)), Quaternion.identity);
                allCells[x, y].GetComponent<CellScript>().SetValues( new Vector2(x,y), null);
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
