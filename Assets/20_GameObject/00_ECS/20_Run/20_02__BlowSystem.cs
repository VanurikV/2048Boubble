using System.Collections.Generic;
using DG.Tweening;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace Client
{
    public struct BlowData
    {
        public Vector2Int From;
        public Vector2Int To;
    }

    sealed class BlowSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly GlobalData _global = null;

        private EcsFilter<BlowComponent> _filter;

        List<BlowData> BlowList;

        void IEcsRunSystem.Run()
        {
            if (_filter.IsEmpty()) return;

            BlowList = new List<BlowData>();
            Vector2Int dir = _filter.Get1(0).dir;

            ClearFilter();

            if (dir.x == 1)  BlowLeft();
            if (dir.x == -1) BlowRight();
            if (dir.y == 1) BlowUp();
            if (dir.y == -1) BlowDown();

            DOTBlow();
            
            EcsEntity ent = _world.NewEntity();
            ent.Get<WaitBlowComponent>().dir=dir;
            ent.Get<WaitBlowComponent>().ElapseTime = 1f;

        }

        // private bool BlowChekHor(Vector2Int dir,int x,int y)
        // {
        //     List<List<Cell>> Cels = _global.CurField.Cells;
        //
        //     if (dir.x > 0)
        //         return ((x + 1) < _global.CurField.Dx && Cels[x][y].Value == Cels[x + 1][y].Value);
        //     else
        //         return ((x - 1) >= 0 && Cels[x][y].Value == Cels[x - 1][y].Value) ;
        //
        // }
        //
        // private void BlowHor(Vector2Int dir)
        // {
        //     List<List<Cell>> Cels = _global.CurField.Cells;
        //     int dy = _global.CurField.Dy;
        //     int dx = _global.CurField.Dx;
        //
        //    for (int y = 0; y < dy; y++)
        //     {
        //         for (int x = 0; x < dx; x++)
        //         {
        //             if (Cels[x][y].Type != CellType.Value) continue;
        //             //нашли не пустую клетку
        //
        //             //если рядом токая же цифра (есть с чем сложить)
        //             if (BlowChekHor(dir,x,y))
        //             {
        //                 BlowData blow = new BlowData();
        //                 blow.From = new Vector2Int(x, y);
        //                 blow.To = new Vector2Int(x + dir.x, y);
        //                 if(BlowListCheckPair(blow)) continue;
        //                 BlowList.Add(blow);
        //             }
        //
        //             
        //         }
        //     }
        // }
        
        private void BlowLeft()
        {
            List<List<Cell>> Cels = _global.CurField.Cells;
            int dy = _global.CurField.Dy;
            int dx = _global.CurField.Dx;

            for (int y = 0; y < dy; y++)
            {
                for (int x = 0; x < dx; x++)
                {
                    if (Cels[x][y].Type != CellType.Value) continue;
                    //нашли не пустую клетку

                    //если рядом токая же цифра (есть с чем сложить)
                    if ((x + 1) < dx && Cels[x][y].Value == Cels[x + 1][y].Value)
                    {
                        BlowData blow = new BlowData();
                        blow.From = new Vector2Int(x, y);
                        blow.To = new Vector2Int(x + 1, y);
                        if(BlowListCheckPair(blow)) continue;
                        BlowList.Add(blow);
                    }

                    ;
                }
            }
        }

        private void BlowRight()
        {
            List<List<Cell>> Cels = _global.CurField.Cells;
            int dy = _global.CurField.Dy;
            int dx = _global.CurField.Dx;

            for (int y = 0; y < dy; y++)
            {
                for (int x = 0; x < dx; x++)
                {
                    if (Cels[x][y].Type != CellType.Value) continue;
                    //нашли не пустую клетку

                    //если рядо токая же цифра (есть с чем сложить)
                    if ((x - 1) >= 0 && Cels[x][y].Value == Cels[x - 1][y].Value)
                    {
                        BlowData blow = new BlowData();
                        blow.From = new Vector2Int(x, y);
                        blow.To = new Vector2Int(x - 1, y);
                        if(BlowListCheckPair(blow)) continue;
                        BlowList.Add(blow);
                    }

                    ;
                }
            }
        }

        private void BlowUp()
        {
            List<List<Cell>> Cels = _global.CurField.Cells;
            int dy = _global.CurField.Dy;
            int dx = _global.CurField.Dx;

            for (int y = 0; y < dy; y++)
            {
                for (int x = 0; x < dx; x++)
                {
                    if (Cels[x][y].Type != CellType.Value) continue;
                    //нашли не пустую клетку

                    //если  следом пустое место (есть куда здвинуть)
                    if ((y - 1) >= 0 && Cels[x][y].Value == Cels[x][y - 1].Value)
                    {
                        BlowData blow = new BlowData();
                        blow.From = new Vector2Int(x, y);
                        blow.To = new Vector2Int(x, y - 1);
                        if(BlowListCheckPair(blow)) continue;
                        BlowList.Add(blow);
                    }
                }
            }
        }


        private void BlowDown()
        {
            List<List<Cell>> Cels = _global.CurField.Cells;
            int dy = _global.CurField.Dy;
            int dx = _global.CurField.Dx;


            for (int y = 0; y < dy; y++)
            {
                for (int x = 0; x < dx; x++)
                {
                    if (Cels[x][y].Type != CellType.Value) continue;
                    //нашли не пустую клетку

                    //если рядо токая же цифра (есть с чем сложить)
                    if ((y + 1) < dy && Cels[x][y].Value == Cels[x][y + 1].Value)
                    {
                        BlowData blow = new BlowData();
                        blow.From = new Vector2Int(x, y);
                        blow.To = new Vector2Int(x, y + 1);
                        if(BlowListCheckPair(blow)) continue;
                        BlowList.Add(blow);
                    }
                }
            }
        }


        private void DOTBlow()
        {
            List<List<Cell>> Cels = _global.CurField.Cells;

            foreach (BlowData blowData in BlowList)
            {
                GameObject From = Cels[blowData.From.x][blowData.From.y].GameObject;
                GameObject To = Cels[blowData.To.x][blowData.To.y].GameObject;

                Sequence from = DOTween.Sequence();

                from.Append(From.transform.DOScale(new Vector3(1.3f, 1.3f, 1.3f), 0.1f).SetLoops(8, LoopType.Yoyo))
                    .Append(From.transform.DOScale(new Vector3(0f, 0f, 0f), 0.1f));


                Sequence to = DOTween.Sequence();
                to.Append(To.transform.DOScale(new Vector3(1.3f, 1.3f, 1.3f), 0.1f).SetLoops(8, LoopType.Yoyo))
                    .Append(To.transform.DOScale(new Vector3(0f, 0f, 0f), 0.1f))
                    .OnComplete(() =>_global.BornNew(blowData));


                
            }
        }

        /// <summary>есть ли уже такая пара чтоб не взрувальсь тройки </summary>
        private bool BlowListCheckPair(BlowData blow)
        {
            foreach (BlowData blowData in BlowList)
            {
                if (blowData.From == blow.From ) return true;
                if (blowData.To == blow.From ) return true;
                if (blowData.From == blow.To ) return true;
                if (blowData.To == blow.To ) return true;
            }

            return false;
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