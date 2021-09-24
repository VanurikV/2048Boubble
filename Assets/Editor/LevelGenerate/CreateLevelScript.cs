using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

public class CreateLevelScript 
{
    [MenuItem("My Tools/Level/Create level ALL")]
    public static void CreateLevelAll()
    {
        CreateLevel00();
        CreateLevel01();
        CreateLevel02();
        
        CreateLevel03();
        CreateLevel04();
        CreateLevel05();
        
        CreateLevel06();
        CreateLevel07();
        CreateLevel08();
        
        CreateLevel09();
        CreateLevel10();
        CreateLevel11();
    }

    #region Row0 00-02

    [MenuItem("My Tools/Level/Create level 00")]
    public static void CreateLevel00()
    {
        string path = ".//Assets//Resources//Levels//Level_00.txt";

        BattleField Level = new BattleField();

        Level.Dx = 8;
        Level.Dy = 8;
        Level.FinishScore = 512;
        Level.Cells = new List<List<Cell>>();

        CreateBattleField(Level);

        string jsonString = JsonConvert.SerializeObject(Level);
        TextWriter t = File.CreateText(path);
        t.WriteLine(jsonString);
        t.Close();

    }
    
    [MenuItem("My Tools/Level/Create level 01")]
    public static void CreateLevel01()
    {
        string path = ".//Assets//Resources//Levels//Level_01.txt";

        BattleField Level = new BattleField();

        Level.Dx = 6;
        Level.Dy = 6;
        Level.FinishScore = 512;
        Level.Cells = new List<List<Cell>>();

        CreateBattleField(Level);

        string jsonString = JsonConvert.SerializeObject(Level);
        TextWriter t = File.CreateText(path);
        t.WriteLine(jsonString);
        t.Close();
    }
    
    [MenuItem("My Tools/Level/Create level 02")]
    public static void CreateLevel02()
    {
        string path = ".//Assets//Resources//Levels//Level_02.txt";
        
        BattleField Level = new BattleField();

        Level.Dx = 4;
        Level.Dy = 4;
        Level.FinishScore = 512;
        Level.Cells = new List<List<Cell>>();

        CreateBattleField(Level);

        string jsonString = JsonConvert.SerializeObject(Level);
        TextWriter t = File.CreateText(path);
        t.WriteLine(jsonString);
        t.Close();

    }
    #endregion

    #region Row1 03-05
    [MenuItem("My Tools/Level/Create level 03")]
    public static void CreateLevel03()
    {
        string path = ".//Assets//Resources//Levels//Level_03.txt";

        BattleField Level = new BattleField();

        Level.Dx = 8;
        Level.Dy = 8;
        Level.FinishScore = 1024;
        Level.Cells = new List<List<Cell>>();

        CreateBattleField(Level);

        string jsonString = JsonConvert.SerializeObject(Level);
        TextWriter t = File.CreateText(path);
        t.WriteLine(jsonString);
        t.Close();

    }
    
    
    [MenuItem("My Tools/Level/Create level 04")]
    public static void CreateLevel04()
    {
        string path = ".//Assets//Resources//Levels//Level_04.txt";

        BattleField Level = new BattleField();

        Level.Dx = 6;
        Level.Dy = 6;
        Level.FinishScore = 1024;
        Level.Cells = new List<List<Cell>>();

        CreateBattleField(Level);

        string jsonString = JsonConvert.SerializeObject(Level);
        TextWriter t = File.CreateText(path);
        t.WriteLine(jsonString);
        t.Close();

    }

    [MenuItem("My Tools/Level/Create level 05")]
    public static void CreateLevel05()
    {
        string path = ".//Assets//Resources//Levels//Level_05.txt";

        BattleField Level = new BattleField();

        Level.Dx = 4;
        Level.Dy = 4;
        Level.FinishScore = 1024;
        Level.Cells = new List<List<Cell>>();

        CreateBattleField(Level);

        string jsonString = JsonConvert.SerializeObject(Level);
        TextWriter t = File.CreateText(path);
        t.WriteLine(jsonString);
        t.Close();

    }
    
    #endregion
    
    
    
    #region Row2 06-08
    [MenuItem("My Tools/Level/Create level 06")]
    public static void CreateLevel06()
    {
        string path = ".//Assets//Resources//Levels//Level_06.txt";

        BattleField Level = new BattleField();

        Level.Dx = 8;
        Level.Dy = 8;
        Level.FinishScore = 2048;
        Level.Cells = new List<List<Cell>>();

        CreateBattleField(Level);

        string jsonString = JsonConvert.SerializeObject(Level);
        TextWriter t = File.CreateText(path);
        t.WriteLine(jsonString);
        t.Close();

    }
    
    
    [MenuItem("My Tools/Level/Create level 07")]
    public static void CreateLevel07()
    {
        string path = ".//Assets//Resources//Levels//Level_07.txt";

        BattleField Level = new BattleField();

        Level.Dx = 6;
        Level.Dy = 6;
        Level.FinishScore = 2048;
        Level.Cells = new List<List<Cell>>();

        CreateBattleField(Level);

        string jsonString = JsonConvert.SerializeObject(Level);
        TextWriter t = File.CreateText(path);
        t.WriteLine(jsonString);
        t.Close();

    }

    [MenuItem("My Tools/Level/Create level 08")]
    public static void CreateLevel08()
    {
        string path = ".//Assets//Resources//Levels//Level_08.txt";

        BattleField Level = new BattleField();

        Level.Dx = 4;
        Level.Dy = 4;
        Level.FinishScore = 2048;
        Level.Cells = new List<List<Cell>>();

        CreateBattleField(Level);

        string jsonString = JsonConvert.SerializeObject(Level);
        TextWriter t = File.CreateText(path);
        t.WriteLine(jsonString);
        t.Close();

    }
    
    #endregion
    
    
    
    
    #region Row3 09-11
    [MenuItem("My Tools/Level/Create level 09")]
    public static void CreateLevel09()
    {
        string path = ".//Assets//Resources//Levels//Level_09.txt";

        BattleField Level = new BattleField();

        Level.Dx = 8;
        Level.Dy = 8;
        Level.FinishScore = 2048;
        Level.Cells = new List<List<Cell>>();

        CreateBattleField(Level);

        Level.Cells[0][0].Type = CellType.BLock;
        Level.Cells[0][0].Value = 0;
        
        Level.Cells[0][7].Type = CellType.BLock;
        Level.Cells[0][7].Value = 0;
        
        Level.Cells[7][0].Type = CellType.BLock;
        Level.Cells[7][0].Value = 0;
        
        Level.Cells[7][7].Type = CellType.BLock;
        Level.Cells[7][7].Value = 0;
        
        string jsonString = JsonConvert.SerializeObject(Level);
        TextWriter t = File.CreateText(path);
        t.WriteLine(jsonString);
        t.Close();

    }
    
    
    [MenuItem("My Tools/Level/Create level 10")]
    public static void CreateLevel10()
    {
        string path = ".//Assets//Resources//Levels//Level_10.txt";

        BattleField Level = new BattleField();

        Level.Dx = 8;
        Level.Dy = 8;
        Level.FinishScore = 2048;
        Level.Cells = new List<List<Cell>>();

        CreateBattleField(Level);
        
        
        Level.Cells[3][3].Type = CellType.BLock;
        Level.Cells[3][3].Value = 0;
        
        Level.Cells[3][4].Type = CellType.BLock;
        Level.Cells[3][4].Value = 0;
        
        Level.Cells[4][3].Type = CellType.BLock;
        Level.Cells[4][3].Value = 0;
        
        Level.Cells[4][4].Type = CellType.BLock;
        Level.Cells[4][4].Value = 0;

        string jsonString = JsonConvert.SerializeObject(Level);
        TextWriter t = File.CreateText(path);
        t.WriteLine(jsonString);
        t.Close();

    }

    [MenuItem("My Tools/Level/Create level 11")]
    public static void CreateLevel11()
    {
        string path = ".//Assets//Resources//Levels//Level_11.txt";

        BattleField Level = new BattleField();

        Level.Dx = 8;
        Level.Dy = 8;
        Level.FinishScore = 2048;
        Level.Cells = new List<List<Cell>>();

        CreateBattleField(Level);

        Level.Cells[0][0].Type = CellType.BLock;
        Level.Cells[0][0].Value = 0;
        
        Level.Cells[0][7].Type = CellType.BLock;
        Level.Cells[0][7].Value = 0;
        
        Level.Cells[7][0].Type = CellType.BLock;
        Level.Cells[7][0].Value = 0;
        
        Level.Cells[7][7].Type = CellType.BLock;
        Level.Cells[7][7].Value = 0;
        
        Level.Cells[3][3].Type = CellType.BLock;
        Level.Cells[3][3].Value = 0;
        
        Level.Cells[3][4].Type = CellType.BLock;
        Level.Cells[3][4].Value = 0;
        
        Level.Cells[4][3].Type = CellType.BLock;
        Level.Cells[4][3].Value = 0;
        
        Level.Cells[4][4].Type = CellType.BLock;
        Level.Cells[4][4].Value = 0;
        
        string jsonString = JsonConvert.SerializeObject(Level);
        TextWriter t = File.CreateText(path);
        t.WriteLine(jsonString);
        t.Close();

    }
    
    #endregion
    
    
    private static BattleField  CreateBattleField(BattleField Level )
    {
        for (int x = 0; x < Level.Dx; x++)
        {
            Level.Cells.Add(new List<Cell>());
            for (int y = 0; y < Level.Dy; y++)
            {
                Cell c = new Cell();
                Level.Cells[x].Add(c);
            }
        }

        return Level;
    }
    
}

