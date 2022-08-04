using UnityEngine;
using System;
public class GridMap : MonoBehaviour
{
    // ...
    public Row[] blockedCells;
    // ...

}
[Serializable]
public class Row
{
    public bool[] rowdata;
}
