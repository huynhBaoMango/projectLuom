using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AI_Nhanvatphu : MonoBehaviour
{
    public Transform[] patrolPoint;
    public int targetPoint;
    public float speed;
    [SerializeField] private fieldofview Fieldofview;
    public Vector3 lastMoveDir;
    // Start is called before the first frame update
    void Start()
    {
        targetPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Fieldofview.setOrigin(transform.position);
        Fieldofview.setAimDirection(GetAimDir());

        //bắt sự kiện khi nhân vật chạm vào điểm đến
        if (transform.position == patrolPoint[targetPoint].position)
        {
            IdleAndWatch();
            increaseTargetPoint();

        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoint[targetPoint].position, speed * Time.deltaTime);
    }

    //hàm để đến điểm tiếp theo
    void increaseTargetPoint()
    {
        targetPoint++;
        if (targetPoint >= patrolPoint.Length)
        {
            targetPoint = 0;
        }
    }

    //hàm để nhân vật dừng lại và nhìn xung quanh
    void IdleAndWatch()
    {
        System.Threading.Thread.Sleep(5000);

    }

    public Vector3 GetAimDir()
    {
        return lastMoveDir;
    }
}
