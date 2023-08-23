using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float tocdo;
    float huongdichuyen;
    // Start is called before the first frame update
    void Start()
    {
        tocdo = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)){
            transform.Translate(Vector3.right * tocdo * Time.deltaTime);
        }   
        if (Input.GetKey(KeyCode.LeftArrow)){
            transform.Translate(Vector3.left * tocdo * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow)){
            transform.Translate(Vector3.up * tocdo * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow)){
            transform.Translate(Vector3.down * tocdo * Time.deltaTime);
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
