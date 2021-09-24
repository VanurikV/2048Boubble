using System.Collections.Generic;
using DG.Tweening;
using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public struct MoveData
    {
        public Vector2Int From;
        public Vector2Int To;
        public GameObject Obj;
    }

    sealed class MoveSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly GlobalData _global = null;

        private EcsFilter<MoveComponent> _filter;

        List<MoveData> MoveList;

        void IEcsRunSystem.Run()
        {
            if (_filter.IsEmpty()) return;
            MoveList = new List<MoveData>();
            Vector2Int dir = _filter.Get1(0).dir;
            
            if(dir.x==1)MoveLeft();
            if(dir.x==-1)MoveRight();
            if(dir.y==1)MoveUp();
            if(dir.y==-1)MoveDown();
           
            DOTMove();
            
            ClearFilter();
            
            EcsEntity ent1 = _world.NewEntity();
            ent1.Get<WaitMoveComponent>().dir=dir;
            ent1.Get<WaitMoveComponent>().ElapseTime = 0.5f;
        }

        private void MoveLeft()
        {
            List<List<Cell>> Cels = _global.CurField.Cells;
            int dy = _global.CurField.Dy;
            int dx = _global.CurField.Dx;

            int xx = 0;

            for (int y = 0; y < dy; y++)
            {
                for (int x = dx - 1; x >= 0; x--)
                {
                    if (Cels[x][y].Type != CellType.Value) continue;
                    //нашли не пустую клетку

                    //если  следущая пустое место (есть куда здвинуть)
                    if ((x + 1) < dx && Cels[x + 1][y].Type == CellType.Empty)
                    {
                        for (xx = x; xx < dx - 1; xx++)
                        {
                            if (Cels[xx + 1][y].Type == CellType.Empty)
                            {
                                continue;
                            }
                            break;
                        }

                        MoveData moveData = new MoveData();
                        moveData.From = new Vector2Int(x, y);
                        moveData.To = new Vector2Int(xx, y);
                        moveData.Obj = Cels[x][y].GameObject;

                        MoveList.Add(moveData);
                        _global.MoveBoubble(moveData);
                    }
                }
            }
        }

        private void MoveRight()
        {
            List<List<Cell>> Cels = _global.CurField.Cells;
            int dy = _global.CurField.Dy;
            int dx = _global.CurField.Dx;

            int xx = 0;

            for (int y = 0; y < dy; y++)
            {
                for (int x = 0; x < dx; x++)
                {
                    if (Cels[x][y].Type != CellType.Value) continue;
                    //нашли не пустую клетку

                    //если  предыдущая пустое место (есть куда здвинуть)
                    if ((x - 1) >= 0 && Cels[x - 1][y].Type == CellType.Empty)
                    {
                        for (xx = x; xx > 0; xx--)
                        {
                            if (Cels[xx - 1][y].Type == CellType.Empty)
                            {
                                continue;
                            }
                            break;
                        }

                        MoveData moveData = new MoveData();
                        moveData.From = new Vector2Int(x, y);
                        moveData.To = new Vector2Int(xx, y);
                        moveData.Obj = Cels[x][y].GameObject;

                        MoveList.Add(moveData);
                        _global.MoveBoubble(moveData);
                    }
                }
            }
        }


        private void MoveUp()
        {
            List<List<Cell>> Cels = _global.CurField.Cells;
            int dy = _global.CurField.Dy;
            int dx = _global.CurField.Dx;

            int yy = 0;

            for (int x = 0; x < dx; x++)
            {
                for (int y = 0; y < dy; y++)
                {
                    if (Cels[x][y].Type != CellType.Value) continue;
                    //нашли не пустую клетку

                    //если  предыдущая пустое место (есть куда здвинуть)
                    if ((y - 1) >= 0 && Cels[x][y - 1].Type == CellType.Empty)
                    {
                        for (yy = y; yy > 0; yy--)
                        {
                            if (Cels[x][yy - 1].Type == CellType.Empty)
                            {
                                continue;
                            }
                            break;
                        }

                        MoveData moveData = new MoveData();
                        moveData.From = new Vector2Int(x, y);
                        moveData.To = new Vector2Int(x, yy);
                        moveData.Obj = Cels[x][y].GameObject;

                        MoveList.Add(moveData);
                        _global.MoveBoubble(moveData);
                    }
                }
            }
        }

        private void MoveDown()
        {
            List<List<Cell>> Cels = _global.CurField.Cells;
            int dy = _global.CurField.Dy;
            int dx = _global.CurField.Dx;

            int yy = 0;

            for (int x = 0; x < dx; x++)
            {
                for (int y = dy-1; y >=0 ; y--)
                {
                    if (Cels[x][y].Type != CellType.Value) continue;
                    //нашли не пустую клетку

                    //если  предыдущая пустое место (есть куда здвинуть)
                    if ((y + 1) <dy  && Cels[x][y + 1].Type == CellType.Empty)
                    {
                        for (yy = y; yy <dy-1 ; yy++)
                        {
                            if (Cels[x][yy + 1].Type == CellType.Empty)
                            {
                                continue;
                            }
                            break;
                        }

                        MoveData moveData = new MoveData();
                        moveData.From = new Vector2Int(x, y);
                        moveData.To = new Vector2Int(x, yy);
                        moveData.Obj = Cels[x][y].GameObject;

                        MoveList.Add(moveData);
                        _global.MoveBoubble(moveData);
                    }
                }
            }
        }

        private void DOTMove()
        {
            foreach (MoveData moveData in MoveList)
            {
                moveData.Obj.transform.DOLocalMove(new Vector3(moveData.To.x * Const.CellSize + Const.CellSize / 2,
                    -moveData.To.y * Const.CellSize - Const.CellSize / 2), 0.5f);
            }
        }
        
        private void ClearFilter()
        {
            foreach (int i in _filter)
            {
                _filter.GetEntity(i).Destroy();
            }
        }
        
    }
}