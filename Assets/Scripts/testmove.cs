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
    [SerializeField] private float fov = 90f;
    [SerializeField] private float viewDistance = 50f;
    [SerializeField] private Player player;
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

        Fieldofview = Instantiate(pfFieldOfView, null).GetComponent<fieldofview>();
        Fieldofview.SetFoV(fov);
        Fieldofview.SetViewDistance(viewDistance);
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
                transform.position = transform.position + waypointDir * speed * Time.deltaTime;
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
                float angle = Mathf.Atan2(waypointDir.y, waypointDir.x);
                this.transform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg - 90f);

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
            // Người chơi trong Field of View
            RaycastHit2D raycastHit2D = Physics2D.Raycast(GetPosition(), dirToPlayer, viewDistance);
            if (raycastHit2D.collider != null)
            {
                // Đánh trúng cái gì đó
                if (raycastHit2D.collider.gameObject.GetComponent<Player>() != null)
                {
                    // Khởi tạo đối tượng đạn và bắn nó
                    GameObject bulletObject = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                    Bullet bullet = bulletObject.GetComponent<Bullet>();
                    bullet.Setup(dirToPlayer);
                }
            }
        }
    }
}
    public Vector3 GetPosition()
    {
        return transform.position;
    }

}
