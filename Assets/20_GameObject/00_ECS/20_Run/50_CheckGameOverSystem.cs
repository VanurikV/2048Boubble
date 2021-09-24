using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Client
{
    sealed class CheckGameOverSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly GlobalData _global = null;

        private EcsFilter<CheckGameOverComponent> _filter;

        void IEcsRunSystem.Run()
        {
            if (_filter.IsEmpty()) return;

            ClearFilter();

            if (isGameOver())
            {
                SceneManager.LoadScene(4);
            }

            EcsEntity ent1 = _world.NewEntity();
            ent1.Get<CheckMoveComponent>();


            
        }

        private bool isGameOver()
        {
            if (_global.CheckSwipe(new Vector2Int(1, 0))) return false;
            if (_global.CheckSwipe(new Vector2Int(-1, 0))) return false;
            if (_global.CheckSwipe(new Vector2Int(0, 1))) return false;
            if (_global.CheckSwipe(new Vector2Int(0, -1))) return false;

            return true;
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