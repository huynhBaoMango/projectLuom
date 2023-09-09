using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cucda2 : MonoBehaviour
{
    
    public GameObject pfminirock;
    Vector3 mousePosition;
    float speed = 5f;
    private Rigidbody2D rb;
    Vector3 lastVelocity;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        mousePosition = GameObject.Find("mousePos").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
        if (speed> 0)
        {
            speed -= 0.01f;
            transform.position = Vector2.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime);
        }
        else
        {
            GameObject rockObject = Instantiate(pfminirock, transform.position, Quaternion.identity);
            cucda3 minirock = rockObject.GetComponent<cucda3>();
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, coll.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(speed, 0f);
    }

}
