using UnityEngine;

namespace Client
{
    sealed partial class InitAllSystem
    {
        private void GenerateField()
        {
            
            
            GameObject Cells = new GameObject();
            Cells.name = "Cells";
           
            
            
            int dx = _global.CurField.Dx;
            int dy = _global.CurField.Dy;
            
            
            for (int y = 0; y < dy; y++)
            {
                for (int x = 0; x < dx; x++)
                {
                    GameObject o = GameObject.Instantiate(_global.CellPrefab, Cells.transform);
                    o.name=$"Cell x:={x} y:={y}";
                    o.transform.position = new Vector2(x * Const.CellSize, -y * Const.CellSize);
                }
            }
            
            Cells.transform.SetParent(_global.GameFieldContainer.transform);
            Cells.transform.localPosition=Vector3.zero;

            for (int y = 0; y < dy; y++)
            {
                for (int x = 0; x < dx; x++)
                {
                    if (_global.CurField.Cells[x][y].Type == CellType.Value)
                    {
                        GameObject o=GameObject.Instantiate(_global.GetPrefab(_global.CurField.Cells[x][y].Value.Value),_global.GameFieldContainer.transform);
                        o.transform.localPosition = new Vector3(x * Const.CellSize +Const.CellSize/2, -y * Const.CellSize-Const.CellSize/2);
                        _global.CurField.Cells[x][y].GameObject = o;
                    }
                    
                    if (_global.CurField.Cells[x][y].Type == CellType.BLock)
                    {
                        GameObject o=GameObject.Instantiate(_global.BlockPrefab,_global.GameFieldContainer.transform);
                        o.transform.localPosition = new Vector3(x * Const.CellSize +Const.CellSize/2, -y * Const.CellSize-Const.CellSize/2);
                        _global.CurField.Cells[x][y].GameObject = o;
                    }
                    
                    
                }
            }


        }
    }
}