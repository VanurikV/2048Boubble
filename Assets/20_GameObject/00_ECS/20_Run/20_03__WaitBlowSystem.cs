using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class WaitBlowSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly GlobalData _global = null;
        
        private EcsFilter<WaitBlowComponent> _filter;

        void IEcsRunSystem.Run()
        {
            if (_filter.IsEmpty()) return;

            _filter.Get1(0).ElapseTime -= Time.deltaTime;

            if (_filter.Get1(0).ElapseTime > 0) return;

            Vector2Int dir = _filter.Get1(0).dir;

            ClearFilter();
            
            if (_global.CheckMove(dir))
            {
                EcsEntity ent = _world.NewEntity();
                ent.Get<MoveComponent>().dir=dir;
                
            }
            else
            {
                //Go to New turn
                EcsEntity ent1 = _world.NewEntity();
                ent1.Get<CheckFinishComponent>();    
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