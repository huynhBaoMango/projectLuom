using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float tocdo;
    // Start is called before the first frame update
    void Start()
    {
        tocdo = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)){
            transform.Translate(Vector3.right.normalized * tocdo * Time.deltaTime, relativeTo:Space.World);
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            transform.Translate(Vector3.left.normalized * tocdo * Time.deltaTime, relativeTo: Space.World);
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (Input.GetKey(KeyCode.UpArrow)){
            transform.Translate(Vector3.up.normalized * tocdo * Time.deltaTime, relativeTo: Space.World);
            transform.rotation = Quaternion.Euler(0, 0, 360);
        }
        if (Input.GetKey(KeyCode.DownArrow)){
            transform.Translate(Vector3.down.normalized * tocdo * Time.deltaTime, relativeTo: Space.World);
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 315);
        }
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 225);
        }
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 135);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 425);
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
