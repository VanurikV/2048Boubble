using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine.SceneManagement;

namespace Client
{
    sealed class CheckFinishSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly GlobalData _global = null;

        private EcsFilter<CheckFinishComponent> _filter;

        void IEcsRunSystem.Run()
        {
            if (_filter.IsEmpty()) return;

            ClearFilter();

            if (isFinish())
            {
                SceneManager.LoadScene(3);
            }

            EcsEntity ent1 = _world.NewEntity();
            ent1.Get<SpawnBoubleComponent>();


            
        }

        private bool isFinish()
        {
            List<List<Cell>> Cels = _global.CurField.Cells;
            int dy = _global.CurField.Dy;
            int dx = _global.CurField.Dx;
            int win = _global.CurField.FinishScore;

            for (int y = 0; y < dy; y++)
            {
                for (int x = 0; x < dx; x++)
                {
                    if (Cels[x][y].Type != CellType.Value) continue;
                    if (Cels[x][y].Value.Value >=win) return true;
                }
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