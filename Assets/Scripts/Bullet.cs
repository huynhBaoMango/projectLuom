using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 moveDirection;
    public float moveSpeed;
    public float upwardForce; // Thêm biến này để kiểm soát lực hướng lên
    public float downwardForce; // Thêm biến này để kiểm soát lực hướng xuống
    [SerializeField] testmove kedich;

    private void Start()
    {
        kedich = GetComponent<testmove>();
        // Đặt giá trị mặc định cho moveSpeed, upwardForce và downwardForce
    }

    private void Update()
    {
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x);
        this.transform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg);
        // Thêm một lực hướng lên vào moveDirection khi di chuyển lên
        if (moveDirection.y > 0)
        {
            moveDirection += Vector3.up * upwardForce * Time.deltaTime;
        }
        // Thêm một lực hướng xuống vào moveDirection khi di chuyển xuống
        else if (moveDirection.y < 0)
        {
            moveDirection += Vector3.down * downwardForce * Time.deltaTime;
        }
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void Setup(Vector3 moveDirection)
    {
        this.moveDirection = moveDirection;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                // Đánh trúng người chơi
                player.dead();
                
            }
    }
}
