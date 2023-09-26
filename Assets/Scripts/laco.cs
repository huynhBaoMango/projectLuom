using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class laco : MonoBehaviour
{
    Vector3 scale = new Vector3(0.025f, 0.025f, 0.025f);
    float speed = 2;
    private Transform playerPos;
    private float disapearTime = 10;

    void Awake()
    {
        transform.localScale = scale;
    }

    void Update()
    {
        disapearTime -= 1 * Time.deltaTime;
        if(transform.localScale.x < 0.2)
        {
            transform.localScale += Vector3.Lerp(scale, transform.localScale, Time.deltaTime * 0.5f);
        }
        if(disapearTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private bool ispicked = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            
            GameObject.FindWithTag("player").SendMessage("boxcountUp");
            Destroy(gameObject);
        }
    }
}
