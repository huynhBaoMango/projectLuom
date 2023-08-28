using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dichuyen : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 v = new Vector3(x, y, 0).normalized;
        transform.Translate(v * speed * Time.deltaTime);
    }
}
