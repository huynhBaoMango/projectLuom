using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float tocdo;
    // Start is called before the first frame update
    void Start()
    {
        tocdo = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)){
            transform.Translate(Vector3.right * tocdo * Time.deltaTime, relativeTo:Space.World);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            transform.Translate(Vector3.left.normalized * tocdo * Time.deltaTime, relativeTo: Space.World);
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (Input.GetKey(KeyCode.UpArrow)){
            transform.Translate(Vector3.up.normalized * tocdo * Time.deltaTime, relativeTo: Space.World);
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (Input.GetKey(KeyCode.DownArrow)){
            transform.Translate(Vector3.down.normalized * tocdo * Time.deltaTime, relativeTo: Space.World);
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }
        if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 45);
        }
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 335);
        }
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 225);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 135);
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
