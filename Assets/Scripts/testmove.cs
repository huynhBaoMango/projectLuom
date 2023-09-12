using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testmove : MonoBehaviour
{
    public const float speed = 2f;

    [SerializeField] private List<Vector3> waypointList;
    [SerializeField] private List<float> waitTimeList;
    private int waypointIndex;

    public GameObject bulletPrefab;
    [SerializeField] private Vector3 aimDirection;
    [SerializeField] private Transform pfFieldOfView;
    [SerializeField] private float fov;
    [SerializeField] private float viewDistance;
    [SerializeField] private Player player;
    [SerializeField] private AudioSource shooting;
    private fieldofview Fieldofview;



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
                FindNearRock();
                break;
            case State.Busy:
                comeToRock();
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
                waitTimer -= Time.deltaTime;
                if (waitTimer <= 0f)
                {
                    state = State.Moving;
                }
                break;
            case State.Moving:

                Vector3 waypoint = waypointList[waypointIndex];
                Vector3 waypointDir = (waypoint - transform.position).normalized;
                lastMoveDir = waypointDir;



                float distanceBefore = Vector3.Distance(transform.position, waypoint);
                if(state != State.Busy)
                {
                    transform.position = transform.position + waypointDir * speed * Time.deltaTime;
                }
                
                float distanceAfter = Vector3.Distance(transform.position, waypoint);

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
                        // Khởi tạo đối tượng đạn và bắn
                        if (player.isDead)
                        {
                            state = State.Moving;
                        }
                        else
                        {
                            GameObject bulletObject = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                            Bullet bullet = bulletObject.GetComponent<Bullet>();
                            bullet.Setup(dirToPlayer);
                            player.dead();
                            if (!shooting.isPlaying)
                            {
                                shooting.Play();
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


    private void FindNearRock()
    {
        if(GameObject.FindWithTag("minirock") != null)
        {
            if (Vector3.Distance(GetPosition(), GameObject.FindWithTag("minirock").transform.position) < viewDistance)
            {
                state = State.Busy;
            }
            
        }
        
    }

    private void comeToRock()
    {
        Vector3 rockPoint = GameObject.FindWithTag("minirock").transform.position;
        if (Vector3.Distance(GetPosition(), rockPoint) < viewDistance)
        {

            Vector3 dirToRock = (rockPoint - GetPosition()).normalized;
            lastMoveDir = dirToRock;
            transform.position = transform.position + dirToRock * speed*2 * Time.deltaTime;
            float angle1 = Mathf.Atan2(dirToRock.y, dirToRock.x);
            transform.rotation = Quaternion.Euler(0f, 0f, angle1 * Mathf.Rad2Deg - 90f);
            if (Vector3.Distance(GetPosition(), rockPoint) < 0.1f)
            {
                Destroy(GameObject.FindWithTag("minirock"));
                //thêm hàm xoá biểu tượng trên camera vào đây
                waitTimer = 3;
                state = State.Waiting;
            }
        }
    }
    private bool rainbool = false;
    public void RainEV(bool active)
    {
        
        if (active && !rainbool)
        {
            this.viewDistance /= 2;
            Fieldofview.SetViewDistance(this.viewDistance);
            rainbool= true;
        }
        if(!active && rainbool)
        {
            this.viewDistance *= 2;
            Fieldofview.SetViewDistance(this.viewDistance);
            rainbool= false;    
        }
    }


    private bool ligtbool = false;
    public void LightningEV(bool active)
    {
        if (active && !ligtbool)
        {
            this.viewDistance *= 2;
            Fieldofview.SetViewDistance(this.viewDistance);
            ligtbool= true;
        }
        if(!active && ligtbool)
        {
            this.viewDistance /= 2;
            Fieldofview.SetViewDistance(this.viewDistance);
            ligtbool= false;
        }
    }

}
