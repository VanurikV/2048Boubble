using DG.Tweening;
using GameSound;
using Leopotam.Ecs;

namespace Client
{
    sealed class MoveFailSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly GlobalData _global = null;

        private EcsFilter<MoveFailComponent> _filter;


        void IEcsRunSystem.Run()
        {
            if(_filter.IsEmpty())return;
            
            Sound.Manager.PlaySfx((int)SfxClip.MoveFail);

            if (_filter.Get1(0).dir.x < 0)
            {
                _global.GameFieldContainer.transform.DOMoveX(64-55, 0.1f).SetLoops(5, LoopType.Yoyo);
                _global.GameFieldContainer.transform.DOMoveX(64, 0.5f).onComplete += CheckMove;
            }
            else if (_filter.Get1(0).dir.x > 0)
            {
                _global.GameFieldContainer.transform.DOMoveX(64+55, 0.1f).SetLoops(5, LoopType.Yoyo);
                _global.GameFieldContainer.transform.DOMoveX(64, 0.5f).onComplete += CheckMove;
            }
            else if (_filter.Get1(0).dir.y > 0)
            {
                _global.GameFieldContainer.transform.DOMoveY(-256+55, 0.1f).SetLoops(5, LoopType.Yoyo);
                _global.GameFieldContainer.transform.DOMoveY(-256, 0.5f).onComplete += CheckMove;
            }
            else
            {
                _global.GameFieldContainer.transform.DOMoveY(-256-55, 0.1f).SetLoops(5, LoopType.Yoyo);
                _global.GameFieldContainer.transform.DOMoveY(-256, 0.5f).onComplete += CheckMove;
            }

        }


        private void CheckMove()
        {
            EcsEntity ent1 = _world.NewEntity();
            ent1.Get<CheckMoveComponent>();
        }
        
    }
}