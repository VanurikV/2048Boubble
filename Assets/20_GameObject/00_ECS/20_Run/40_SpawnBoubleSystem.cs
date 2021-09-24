using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;


namespace Client {
    sealed class SpawnBoubleSystem : IEcsRunSystem 
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly GlobalData _global = null;
        
        private EcsFilter<SpawnBoubleComponent> _filter;
        
        
        void IEcsRunSystem.Run () 
        {
            if (_filter.IsEmpty()) return;

            if (!_filter.Get1(0).isSpawn)
            {
                _filter.Get1(0).ElapseTime = 0.5f;
                _filter.Get1(0).isSpawn = true;
                SpawnBouble();
            }
            
            
            _filter.Get1(0).ElapseTime -= Time.deltaTime;
            if (_filter.Get1(0).ElapseTime > 0) return;
            
            ClearFilter();
                
            EcsEntity ent1 = _world.NewEntity();
            ent1.Get<CheckGameOverComponent>();    
        }

        private void SpawnBouble()
        {
            List<List<Cell>> Cels = _global.CurField.Cells;
            int dy = _global.CurField.Dy;
            int dx = _global.CurField.Dx;

            List<Vector2Int> EmptyCell = new List<Vector2Int>();
            
            for (int x = 0; x < dx; x++)
            {
                for (int y = 0; y < dy; y++)
                {
                    if(Cels[x][y].Type!=CellType.Empty) continue;
                    
                    EmptyCell.Add(new Vector2Int(x,y));
                }
            }
            _global.SpawnNew(EmptyCell[Random.Range(0,EmptyCell.Count)]);
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