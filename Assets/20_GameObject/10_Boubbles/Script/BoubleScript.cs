using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;


public class BoubleScript : MonoBehaviour
{
    public Sprite[] BorderSprite;
    public Sprite[] ColorSprite;

    public SpriteRenderer BorderRender;
    public SpriteRenderer ColorRender;


    private void Awake()
    {
        BorderRender.sprite = BorderSprite[Random.Range(0, BorderSprite.Length)];
        ColorRender.sprite = ColorSprite[Random.Range(0, ColorSprite.Length)];
    }

    private void OnEnable()
    {
        transform.DOScale(1, 1);
    }
}
