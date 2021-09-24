using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CollectScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DOTween.KillAll();
        Sequence to = DOTween.Sequence();
        to.Append(transform.DOScale(new Vector3(0.2f, 0.2f, 0.2f), 0.5f))
            .Join(transform.DORotate(new Vector3(0, 0, 361), 0.5f, RotateMode.FastBeyond360))
            .OnComplete(() => {to.Kill();DOTween.KillAll();} );

    }

    
}
