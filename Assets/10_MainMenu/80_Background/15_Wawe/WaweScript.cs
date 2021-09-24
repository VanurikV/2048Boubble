using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaweScript : MonoBehaviour
{

    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + Speed * Time.deltaTime, transform.position.y);

        if (transform.position.x < -300) GameObject.Destroy(gameObject);
    }
}
