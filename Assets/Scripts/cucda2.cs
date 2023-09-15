using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cucda2 : MonoBehaviour
{
    public GameObject pfminirock;
    private Vector3 mousePosition;
    private float throwSpeed = 8f; // Tốc độ ném đá
    private Rigidbody2D rb;
    private bool isMoving = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // Lấy vị trí ban đầu của mousePosition
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void Update()
    {


        if (isMoving)
        {
            if (throwSpeed > 0)
            {
                throwSpeed -= 0.01f;
                // Tính toán hướng từ nhân vật đến chuột
                Vector2 direction = (mousePosition - transform.position).normalized;
                // Đặt vận tốc cho đá
                rb.velocity = direction * throwSpeed;
            }
            else
            {
                isMoving = false;
                // Tạo một đối tượng mới từ prefab pfminirock
                // Thêm một offset vào vị trí khởi tạo của đá
                Vector3 rockPosition = transform.position;
                GameObject rockObject = Instantiate(pfminirock, rockPosition, Quaternion.identity);
                Rigidbody2D rockRigidbody = rockObject.GetComponent<Rigidbody2D>();

                // Hủy GameObject hiện tại
                Destroy(gameObject);
            }
        }
    }
}