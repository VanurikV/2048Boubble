using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CellType
{
    Empty,
    BLock,
    Value,
}   

[Serializable]
public class Cell
{
    public CellType Type;
    public int? Value;
    public GameObject GameObject;

    public Cell()
    {
        Type = CellType.Empty;
        Value = null;
        GameObject = null;
    }
    
}

[Serializable]
public class BattleField
{
    public int Dx;
    public int Dy;
    public int FinishScore;
    public List<List<Cell>> Cells;
}