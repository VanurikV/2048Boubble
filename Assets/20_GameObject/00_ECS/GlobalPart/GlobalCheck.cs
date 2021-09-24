using System.Collections.Generic;
using UnityEngine;

public partial class GlobalData
{

    public bool CheckSwipe(Vector2Int dir)
    {
        if (dir.x == 1) return CheckSwipeLeft();
        if (dir.x == -1) return CheckSwipeRight();
        
        if (dir.y == 1) return CheckSwipeUp();
        if (dir.y == -1) return CheckSwipeDown();

        return false;
    }
    
    public bool CheckMove(Vector2Int dir)
    {
        if (dir.x == 1) return CheckMoveLeft();
        if (dir.x == -1) return CheckMoveRight();
        
        if (dir.y == 1) return CheckMoveUp();
        if (dir.y == -1) return CheckMoveDown();

        return false;
    }
    
    
    public bool CheckBlow(Vector2Int dir)
    {
        if (dir.x == 1) return CheckBlowLeft();
        if (dir.x == -1) return CheckBlowRight();
        
        if (dir.y == 1) return CheckBlowUp();
        if (dir.y == -1) return CheckBlowDown();

        return false;
    }
    
    
    
    /// <summary>Можем ли мы сдвинуть шары </summary>
    public bool CheckMoveLeft()
    {
        List<List<Cell>> Cels = CurField.Cells;
        int dy = CurField.Dy;
        int dx = CurField.Dx;

        for (int y = 0; y < dy; y++)
        {
            for (int x = 0; x < dx; x++)
            {
                if (Cels[x][y].Type != CellType.Value) continue;
                //нашли не пустую клетку

                //если  следом пустое место (есть куда здвинуть)
                if ((x + 1) < dx && Cels[x + 1][y].Type == CellType.Empty) return true;
            }
        }

        return false;
    }

    /// <summary>Можем ли мы сложить шары </summary>
    public bool CheckBlowLeft()
    {
        List<List<Cell>> Cels = CurField.Cells;
        int dy = CurField.Dy;
        int dx = CurField.Dx;

        for (int y = 0; y < dy; y++)
        {
            for (int x = 0; x < dx; x++)
            {
                if (Cels[x][y].Type != CellType.Value) continue;
                //нашли не пустую клетку

                //если рядо токая же цифра (есть с чем сложить)
                if ((x + 1) < dx && Cels[x][y].Value.Value == Cels[x + 1][y].Value.Value) return true;
            }
        }

        return false;
    }

    /// <summary>Можем ли мы сделать ход в эту сторону</summary>
    public bool CheckSwipeLeft()
    {
        return CheckMoveLeft() || CheckBlowLeft();
    }

    public bool CheckMoveRight()
    {
        List<List<Cell>> Cels = CurField.Cells;
        int dy = CurField.Dy;
        int dx = CurField.Dx;

        for (int y = 0; y < dy; y++)
        {
            for (int x = 0; x < dx; x++)
            {
                if (Cels[x][y].Type != CellType.Value) continue;
                //нашли не пустую клетку

                //если  следом пустое место (есть куда здвинуть)
                if ((x - 1) >= 0 && Cels[x - 1][y].Type == CellType.Empty) return true;
            }
        }

        return false;
    }

    public bool CheckBlowRight()
    {
        List<List<Cell>> Cels = CurField.Cells;
        int dy = CurField.Dy;
        int dx = CurField.Dx;

        for (int y = 0; y < dy; y++)
        {
            for (int x = 0; x < dx; x++)
            {
                if (Cels[x][y].Type != CellType.Value) continue;
                //нашли не пустую клетку

                //если рядо токая же цифра (есть с чем сложить)
                if ((x - 1) >= 0 && Cels[x][y].Value.Value == Cels[x - 1][y].Value.Value) return true;
            }
        }

        return false;
    }

    public bool CheckSwipeRight()
    {
        return CheckMoveRight() || CheckBlowRight();
    }


    public bool CheckMoveDown()
    {
        List<List<Cell>> Cels = CurField.Cells;
        int dy = CurField.Dy;
        int dx = CurField.Dx;

        for (int y = 0; y < dy; y++)
        {
            for (int x = 0; x < dx; x++)
            {
                if (Cels[x][y].Type != CellType.Value) continue;
                //нашли не пустую клетку

                //если  следом пустое место (есть куда здвинуть)
                if ((y + 1) < dy && Cels[x][y + 1].Type == CellType.Empty) return true;
            }
        }

        return false;
    }

    public bool CheckBlowDown()
    {
        List<List<Cell>> Cels = CurField.Cells;
        int dy = CurField.Dy;
        int dx = CurField.Dx;

        for (int y = 0; y < dy; y++)
        {
            for (int x = 0; x < dx; x++)
            {
                if (Cels[x][y].Type != CellType.Value) continue;
                //нашли не пустую клетку

                //если рядо токая же цифра (есть с чем сложить)
                if ((y + 1) < dy && Cels[x][y + 1].Type==CellType.Value && Cels[x][y].Value.Value == Cels[x][y + 1].Value.Value) return true;
            }
        }
        
        return false;
    }

    public bool CheckSwipeDown()
    {
        return CheckMoveDown() || CheckBlowDown();
    }

    
    public bool CheckMoveUp()
    {
        List<List<Cell>> Cels = CurField.Cells;
        int dy = CurField.Dy;
        int dx = CurField.Dx;

        for (int y = 0; y < dy; y++)
        {
            for (int x = 0; x < dx; x++)
            {
                if (Cels[x][y].Type != CellType.Value) continue;
                
                //нашли не пустую клетку

                //если  следом пустое место (есть куда здвинуть)
                if ((y - 1) >= 0 && Cels[x][y - 1].Type == CellType.Empty) return true;

               
            }
        }
        return false;
    }

    public bool CheckBlowUp()
    {
        
        List<List<Cell>> Cels = CurField.Cells;
        int dy = CurField.Dy;
        int dx = CurField.Dx;

        for (int y = 0; y < dy; y++)
        {
            for (int x = 0; x < dx; x++)
            {
                if (Cels[x][y].Type != CellType.Value) continue;
                
                
                //нашли не пустую клетку

               //если рядо токая же цифра (есть с чем сложить)
                if ((y - 1) >= 0 && Cels[x][y].Value.Value == Cels[x][y - 1].Value.Value) return true;
            }
        }
        
        return false;
    }
    public bool CheckSwipeUp()
    {
        return CheckMoveUp() || CheckBlowUp();
    }
}