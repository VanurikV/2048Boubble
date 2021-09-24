using System.Collections;
using DG.Tweening;
using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed partial class InitAllSystem : IEcsInitSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly GlobalData _global = null;

        public void Init()
        {

            LoadLevel();

            _global.CurrentLevel = Settings.GetLevel();
            _global.CloneBattleField();
            
            SetupCamera();
            
            GenerateField();

            CreateCollect();
            
            EcsEntity ent1 = _world.NewEntity();
            ent1.Get<SpawnBoubleComponent>();

        }

        private void CreateCollect()
        {
            GameObject BoubbleContainer=GameObject.Find("BoubbleCollectContainer");
            
            GameObject o = GameObject.Instantiate(_global.GetPrefab(_global.CurField.FinishScore),BoubbleContainer.transform);
            o.transform.localPosition=Vector3.zero;
            
            //GameObject o=GameObject.Instantiate(BoublePrefab[((int)Mathf.Log(battleField.FinishScore, 2) - 1)],transform);
            //o.transform.localPosition=Vector3.zero;
        }
    }
}