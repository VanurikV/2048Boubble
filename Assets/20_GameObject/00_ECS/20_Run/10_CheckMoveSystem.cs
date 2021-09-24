using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Client
{
    sealed class CheckMoveSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly GlobalData _global = null;

        private EcsFilter<CheckMoveComponent> _checkMoveFilter;

        private Vector2 _moveVectorKey;
        private Vector2 _moveVectorTouch;

        private Vector2Int dir;

        void IEcsRunSystem.Run()
        {
            if (_checkMoveFilter.IsEmpty()) return;

            _moveVectorKey = _global.Controls.Player.Keyb.ReadValue<Vector2>();
            _moveVectorTouch = _global.Controls.Player.Touch.ReadValue<Vector2>();


            if (_moveVectorTouch.sqrMagnitude < 200)
            {
                _moveVectorTouch = _moveVectorKey;
            }

            if (_moveVectorTouch == Vector2.zero) return;

            //Debug.Log(_moveVectorTouch + " " + _moveVectorTouch.sqrMagnitude);

            ClearFilter();

            dir = new Vector2Int();

            if (Mathf.Abs(_moveVectorTouch.x) > Mathf.Abs(_moveVectorTouch.y))
            {
                if (_moveVectorTouch.x > 0) dir.x = 1;
                if (_moveVectorTouch.x < 0) dir.x = -1;
            }
            else
            {
                if (_moveVectorTouch.y > 0) dir.y = 1;
                if (_moveVectorTouch.y < 0) dir.y = -1;
            }

            //если хлда в эту сторону нет 
            if (!_global.CheckSwipe(dir))
            {
                EcsEntity ent = _world.NewEntity();
                ent.Get<MoveFailComponent>().dir = dir;
                return;
            }

            //если можем сдвинуть то сдвигием
            if (_global.CheckMove(dir))
            {
                EcsEntity ent = _world.NewEntity();
                ent.Get<MoveComponent>().dir = dir;
                return;
            }

            //иначе лопаем шары
            EcsEntity ent2 = _world.NewEntity();
            ent2.Get<BlowComponent>().dir = dir;
        }


        private void ClearFilter()
        {
            foreach (int i in _checkMoveFilter)
            {
                _checkMoveFilter.GetEntity(i).Destroy();
            }
        }
    }
}