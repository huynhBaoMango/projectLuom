using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AI_Nhanvatphu : MonoBehaviour
{
    public Transform[] patrolPoint;
    public int targetPoint;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        targetPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //
        if (transform.position == patrolPoint[targetPoint].position)
        {
            increaseTargetPoint();
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoint[targetPoint].position, speed * Time.deltaTime);
    }
    void increaseTargetPoint()
    {
        targetPoint++;
        if (targetPoint >= patrolPoint.Length)
        {
            targetPoint = 0;
        }
    }
}
