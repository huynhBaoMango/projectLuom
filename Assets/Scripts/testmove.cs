using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testmove : MonoBehaviour
{
    private const float speed = 25f;

    [SerializeField] private List<Vector3> waypointList;
    [SerializeField] private List<float> waitTimeList;
    private int waypointIndex;


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
                break;
                

        }
        
        
    }
    private void FindTargetPlayer()
    {
        
        if (Vector3.Distance(GetPosition(), player.GetPosition()) < viewDistance)
        {
            // Player inside viewDistance
            Vector3 dirToPlayer = (player.GetPosition() - GetPosition()).normalized;
            if (Vector3.Angle(GetAimDir(), dirToPlayer) < fov / 2f)
            {
                // Player inside Field of View
                RaycastHit2D raycastHit2D = Physics2D.Raycast(GetPosition(), dirToPlayer, viewDistance);
                if (raycastHit2D.collider != null)
                {
                    // Hit something
                    if (raycastHit2D.collider.gameObject.GetComponent<Player>() != null)
                    {
                        // Hàm bắt sự kiện khi người chơi trong tầm nhìn (Chưa làm)
                        Debug.Log("Hitting");
                        
                    }
                    else
                    {
                        // Hit something else
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
