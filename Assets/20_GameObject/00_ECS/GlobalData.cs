using System.Collections;
using System.Collections.Generic;
using Client;
using GameSound;
using UnityEngine;


public partial class GlobalData
{
    /// <summary>Контейнер для клеток поля </summary>
    public GameObject GameFieldContainer = GameObject.Find("GameField");

    /// <summary> Префабы шаров </summary>
    public GameObject[] Bubbles;

    /// <summary>Префаб слетки поля </summary>
    public GameObject CellPrefab;
    
    public GameObject BlockPrefab;

    /// <summary>Система управления</summary>
    public GameControls Controls;

    /// <summary>Начальная карта всех уровней </summary>
    public List<BattleField> LevelField;

    /// <summary>Текущий уровень</summary>
    public int CurrentLevel;

    /// <summary>Карта текущего уровня</summary>
    public BattleField CurField;


    public void CloneBattleField()
    {
        CurField = new BattleField();
        CurField.Dx = LevelField[CurrentLevel].Dx;
        CurField.Dy = LevelField[CurrentLevel].Dy;
        CurField.FinishScore = LevelField[CurrentLevel].FinishScore;

        CurField.Cells = new List<List<Cell>>();

        for (int x = 0; x < CurField.Dx; x++)
        {
            CurField.Cells.Add(new List<Cell>());
            for (int y = 0; y < CurField.Dy; y++)
            {
                Cell c = new Cell();
                c.Type = LevelField[CurrentLevel].Cells[x][y].Type;
                c.Value = LevelField[CurrentLevel].Cells[x][y].Value;
                c.GameObject = LevelField[CurrentLevel].Cells[x][y].GameObject;

                CurField.Cells[x].Add(c);
            }
        }
    }

    public GameObject GetPrefab(int val)
    {
        return Bubbles[((int)Mathf.Log(val, 2) - 1)];
    }


    public void MoveBoubble(MoveData move)
    {
        List<List<Cell>> Cels = CurField.Cells;
        Cels[move.To.x][move.To.y].Type = Cels[move.From.x][move.From.y].Type;
        Cels[move.To.x][move.To.y].Value = Cels[move.From.x][move.From.y].Value;
        Cels[move.To.x][move.To.y].GameObject = Cels[move.From.x][move.From.y].GameObject;

        Cels[move.From.x][move.From.y].Type = CellType.Empty;
        Cels[move.From.x][move.From.y].Value = null;
        Cels[move.From.x][move.From.y].GameObject = null;
    }

    public void ClearCell(Vector2Int pos)
    {
        List<List<Cell>> Cels = CurField.Cells;
        Cels[pos.x][pos.y].Type = CellType.Empty;
        Cels[pos.x][pos.y].Value = null;
        
        if (Cels[pos.x][pos.y].GameObject is null) return;
        GameObject.Destroy(Cels[pos.x][pos.y].GameObject);
    }
    
    public void BornNew(BlowData blow)
    {
        int val = CurField.Cells[blow.To.x][blow.To.y].Value.Value;
        val = val + val;

        ClearCell(blow.From);
        ClearCell(blow.To);

        int x = blow.To.x;
        int y=blow.To.y;
            
        CurField.Cells[x][y].Type = CellType.Value;
        
        GameObject o = GameObject.Instantiate(GetPrefab(val), GameFieldContainer.transform);
        o.transform.localPosition = new Vector3(x * Const.CellSize + Const.CellSize / 2,
            -y * Const.CellSize - Const.CellSize / 2);
        
        Sound.Manager.PlaySfx((int)SfxClip.BubbleNew);
        
        CurField.Cells[x][y].Value = val;
        CurField.Cells[x][y].GameObject = o;
    }

    public void SpawnNew(Vector2Int pos)
    {
        int val = Random.value > 0.8f ? 4 : 2;
        
        GameObject o = GameObject.Instantiate(GetPrefab(val), GameFieldContainer.transform);
        o.transform.localPosition = new Vector3(pos.x * Const.CellSize + Const.CellSize / 2,
            -pos.y * Const.CellSize - Const.CellSize / 2);
        
        Sound.Manager.PlaySfx((int)SfxClip.BubbleSpawn);
        
        
        CurField.Cells[pos.x][pos.y].Value = val;
        CurField.Cells[pos.x][pos.y].Type = CellType.Value;
        CurField.Cells[pos.x][pos.y].GameObject = o;
        
    }
    
}