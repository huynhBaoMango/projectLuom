using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cucda2 : MonoBehaviour
{
    public GameObject pfminirock;
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
            speed -= 0.01f;
            transform.position = Vector2.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime);
        }
        else
        {
            GameObject rockObject = Instantiate(pfminirock, transform.position, Quaternion.identity);
            cucda3 throwingrock = rockObject.GetComponent<cucda3>();
            Destroy(gameObject);
        }
    }


}
