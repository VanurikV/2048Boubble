using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Client
{
    sealed partial class InitAllSystem
    {
        private void LoadLevel()
        {
            _global.LevelField = new List<BattleField>();
            
            for (int i = 0; i < Const.MaxLevel; i++)
            {
                TextAsset levelJson = Resources.Load<TextAsset>("Levels/Level_" + i.ToString("D2"));
                _global.LevelField.Add(JsonConvert.DeserializeObject<BattleField>(levelJson.text));
                
            }
            
        }
    }
}