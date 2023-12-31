﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chosan : MonoBehaviour
{
    public const float speed = 4f;

    [SerializeField] private List<Vector3> waypointList;
    [SerializeField] private List<float> waitTimeList;
    private int waypointIndex;
    public Animator animator;
    [SerializeField] private Vector3 aimDirection;
    [SerializeField] private Transform pfFieldOfView;
    [SerializeField] private float fov;
    [SerializeField] private float viewDistance;
    [SerializeField] private Player player;
    [SerializeField] private AudioSource bite;
    [SerializeField] private AudioSource lookplayer;

    private fieldofview Fieldofview;
    private Vector3 lastposplayer;


    private enum State
    {
        Waiting,
        Moving,
        AttackingPlayer,
        Busy,
    }

    private State state;
    private float waitTimer;
    private Vector3 lastMoveDir;
    // Start is called before the first frame update
    void Start()
    {
        state = State.Waiting;
        animator = GetComponent<Animator>();
        waitTimer = waitTimeList[0];
        lastMoveDir = aimDirection;

        fillFOV(); // khởi tạo fov

    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            default:
            case State.Waiting:
            case State.Moving:
                HandleMovement();
                FindTargetPlayer();
                break;
            case State.Busy:
                break;

        }

        if (Fieldofview != null)
        {
            Fieldofview.setOrigin(transform.position);
            Fieldofview.setAimDirection(GetAimDir());
        }

    }

    public void fillFOV()
    {
        Fieldofview = Instantiate(pfFieldOfView, null).GetComponent<fieldofview>();
        Fieldofview.SetFoV(fov);
        Fieldofview.SetViewDistance(viewDistance);
    }

    public Vector3 GetAimDir()
    {
        return lastMoveDir;
    }

    public void HandleMovement()
    {

        switch (state)
        {
            case State.Waiting:
                animator.SetBool("isRunning", false);
                waitTimer -= Time.deltaTime;
                if (waitTimer <= 0f)
                {
                    state = State.Moving;
                }
                break;
            case State.Moving:
                animator.SetBool("isRunning", true);
                Vector3 waypoint = waypointList[waypointIndex];
                Vector3 waypointDir = (waypoint - transform.position).normalized;
                lastMoveDir = waypointDir;



                float distanceBefore = Vector3.Distance(transform.position, waypoint);
                transform.position = transform.position + waypointDir * speed * Time.deltaTime;
                float distanceAfter = Vector3.Distance(transform.position, waypoint);

                //ngưng gầm gừ
                lookplayer.Stop();

                float arriveDistance = .1f;
                if (distanceAfter < arriveDistance || distanceBefore <= distanceAfter)
                {
                    // Đến điểm tiếp theo
                    waitTimer = waitTimeList[waypointIndex];
                    waypointIndex = (waypointIndex + 1) % waypointList.Count;
                    state = State.Waiting;
                }
                //xoay đối tượng theo hướng di chuyển
                float angle1 = Mathf.Atan2(waypointDir.y, waypointDir.x);
                transform.rotation = Quaternion.Euler(0f, 0f, angle1 * Mathf.Rad2Deg - 90f);


                break;


        }

    }
    private void FindTargetPlayer()
    {
        if (Vector3.Distance(GetPosition(), player.GetPosition()) < viewDistance)
        {
            
            // Người chơi trong viewDistance
            Vector3 dirToPlayer = (player.GetPosition() - GetPosition()).normalized;
            if (Vector3.Angle(GetAimDir(), dirToPlayer) < fov / 2f)
            {
                // phát hiện trong Field of View
                RaycastHit2D raycastHit2D = Physics2D.Raycast(GetPosition(), dirToPlayer, viewDistance);
                if (raycastHit2D.collider != null)
                {
                    // Xác định đó có phải người chơi
                    if (raycastHit2D.collider.gameObject.GetComponent<Player>() != null)
                    {
                        // gầm gừ khi đứng gần người chơi
                        if (!lookplayer.isPlaying && !player.isDead) lookplayer.Play();
                        if (player.isMoving)
                        {
                            //chạy đến người chơi
                            animator.SetBool("isRunning", true);
                            transform.position = transform.position + dirToPlayer * speed*4 * Time.deltaTime;
                            float angle1 = Mathf.Atan2(dirToPlayer.y, dirToPlayer.x);
                            transform.rotation = Quaternion.Euler(0f, 0f, angle1 * Mathf.Rad2Deg - 90f);
                            if (Vector3.Distance(GetPosition(), player.GetPosition()) < 0.5f)
                            {
                                player.dead();
                                lookplayer.Stop();
                                bite.Play();
                                state = State.Busy;
                            }
                        }

                    }

                }
            }
        }
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void ngungban()
    {
        state = State.Busy;
    }



}
