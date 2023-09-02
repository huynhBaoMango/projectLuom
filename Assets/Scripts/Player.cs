using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;
    private bool isAlive = true; // Biến kiểm tra trạng thái sống/chết
    public bool isDead = false; // Đặt isDead thành public
    float tocdo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tocdo = 2;
        isAlive = true; // Đảm bảo rằng người chơi ban đầu còn sống
        animator = GetComponent<Animator>();
        animator.SetInteger("isWalking", 0);
    }

    void Update()
    {
        if (isAlive && !isDead) // Kiểm tra trạng thái sống/chết
        {
            animator.SetInteger("isWalking", 0);

            if (Input.GetKey(KeyCode.RightArrow)){
                // Xử lý di chuyển bên phải
                Move(Vector2.right, 270);
            }
            if (Input.GetKey(KeyCode.LeftArrow)){
                // Xử lý di chuyển bên trái
                Move(Vector2.left, 90);
            }
            if (Input.GetKey(KeyCode.UpArrow)){
                // Xử lý di chuyển lên trên
                Move(Vector2.up, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow)){
                // Xử lý di chuyển xuống dưới
                Move(Vector2.down, 180);
            }
            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
            {
                // Xử lý góc chuyển động khi di chuyển cùng lúc 2 phím
                transform.rotation = Quaternion.Euler(0, 0, 315);
            }
            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
            {
                // Xử lý góc chuyển động khi di chuyển cùng lúc 2 phím
                transform.rotation = Quaternion.Euler(0, 0, 225);
            }
            if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
            {
                // Xử lý góc chuyển động khi di chuyển cùng lúc 2 phím
                transform.rotation = Quaternion.Euler(0, 0, 135);
            }
            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
            {
                // Xử lý góc chuyển động khi di chuyển cùng lúc 2 phím
                transform.rotation = Quaternion.Euler(0, 0, 45);
            }
        }

        
    }

    void Move(Vector2 direction, float rotationZ)
    {
        // Kiểm tra trạng thái sống/chết
        if (isAlive && !isDead)
        {
            transform.Translate(direction.normalized * tocdo * Time.deltaTime, Space.World);
            transform.rotation = Quaternion.Euler(0, 0, rotationZ);
            animator.SetInteger("isWalking", 1);
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void dead()
    {
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("DeadTrigger");
        isAlive = false; // Đặt trạng thái sống/chết thành false khi người chơi chết
        isDead = true;
    }

    public void restartmenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menuketthuc");
    }
}
