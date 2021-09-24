using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WaweSpawnerScript : MonoBehaviour
{

    public GameObject WawePrefab;

    public float Min;
    public float Max;
  
    public float Elap;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Elap -= Time.deltaTime;
        if (Elap > 0)return;

        Elap = Random.Range(Min, Max);

        GameObject o = GameObject.Instantiate(WawePrefab, transform);
        o.transform.localPosition = new Vector3(300, Random.Range(0,-7f));
        float scale = Random.Range(0.8f, 1.2f);
        o.transform.localScale = new Vector3(scale, scale, scale);
    }
}
