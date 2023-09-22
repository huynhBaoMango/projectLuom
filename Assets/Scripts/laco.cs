using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class laco : MonoBehaviour
{

    Vector3 scale = new Vector3(0.025f, 0.025f, 0.025f);
    float speed = 2;

    void Awake()
    {
        transform.localScale = scale;
    }

    void Update()
    {
        if(transform.localScale.x < 1)
        {
            transform.localScale += Vector3.Lerp(scale, transform.localScale, Time.deltaTime * 0.5f);
            Debug.Log(transform.localScale);
        }
    }
}
