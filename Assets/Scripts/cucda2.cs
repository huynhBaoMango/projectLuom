using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cucda2 : MonoBehaviour
{
    Vector3 mousePosition;
    float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        mousePosition = GameObject.Find("mousePos").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(speed> 0)
        {
            speed -= 0.04f;
            transform.position = Vector2.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime);
        }
    }


}
