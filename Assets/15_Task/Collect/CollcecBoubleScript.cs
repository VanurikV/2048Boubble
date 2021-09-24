using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Newtonsoft.Json;
using UnityEngine;

public class CollcecBoubleScript : MonoBehaviour
{

    public GameObject[] BoublePrefab;
    
    
    // Start is called before the first frame update
    void Start()
    {
        int level= Settings.GetLevel();
        TextAsset levelJson = Resources.Load<TextAsset>("Levels/Level_" + level.ToString("D2"));
        BattleField battleField = JsonConvert.DeserializeObject<BattleField>(levelJson.text);
       
       GameObject o=GameObject.Instantiate(BoublePrefab[((int)Mathf.Log(battleField.FinishScore, 2) - 1)],transform);
       o.transform.localPosition=Vector3.zero;
       
       Sequence to = DOTween.Sequence();
       to.Append(o.transform.DOScale(new Vector3(1.3f, 1.3f, 1.3f), 0.1f).SetLoops(8, LoopType.Yoyo));
       
    }

   

    
}
