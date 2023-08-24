using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public float flspeed = 2f;
    public Transform target;
    public float yOffset = 5f;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x,target.position.y+yOffset,-10f);
        transform.position = Vector3.Slerp(transform.position, newPos, flspeed * Time.deltaTime);
    }
}
