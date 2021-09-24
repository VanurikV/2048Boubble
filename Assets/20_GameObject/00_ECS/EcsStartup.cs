using System;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

namespace Client {
    sealed class EcsStartup : MonoBehaviour
    {

        public GameObject[] Bubbles;
        public GameObject CellPrefab;
        public GameObject BlockPrefab;
        
        
        public GameObject GameFieldContainer;
        
        private GlobalData _global;
        private EcsWorld _world;
        private EcsSystems _systems;    

        private GameControls _controls;

        private void Awake()
        {
            _controls = new GameControls();
        }

        void Start () {
            // void can be switched to IEnumerator for support coroutines.
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);

           
            
            _global = new GlobalData();
            _global.Bubbles = Bubbles;
            _global.Controls = _controls;
            _global.CellPrefab = CellPrefab;
            _global.BlockPrefab = BlockPrefab;
            
                
            
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems
                // register your systems here, for example:
                // .Add (new TestSystem1 ())
                // .Add (new TestSystem2 ())
                .Add (new InitAllSystem ())
                
                
                
                .Add (new CheckMoveSystem ())
                .Add (new  MoveFailSystem ())
                .Add (new  MoveSystem ())
                .Add (new  WaitMoveSystem ())
                .Add (new  BlowSystem ())
                .Add (new  WaitBlowSystem ())
                
                .Add (new  CheckFinishSystem ())
                .Add (new  SpawnBoubleSystem ())
                .Add (new  CheckGameOverSystem ())
                
                
                
                // register one-frame components (order is important), for example:
                // .OneFrame<TestComponent1> ()
                // .OneFrame<TestComponent2> ()
                .OneFrame<MoveFailComponent> ()
                //.OneFrame<CheckFinishComponent> ()
                
                // inject service instances here (order doesn't important), for example:
                // .Inject (new CameraService ())
                 .Inject (_global)
                .Init ();
        }

        void Update () {
            _systems?.Run ();
            
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }

        private void OnEnable()
        {
            _controls.Enable();
            TouchSimulation.Enable();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }
    }
}