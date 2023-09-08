using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public GameObject pfminirock;

    private Rigidbody2D rb;
    public Animator animator;
    private bool isAlive = true; // Biến kiểm tra trạng thái sống/chết
    public bool isDead = false; // Đặt isDead thành public
    float tocdo;
    public string sceneName;
    public bool isMoving;
    public bool hasRock = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tocdo = 2;
        isAlive = true; // Đảm bảo rằng người chơi ban đầu còn sống
        animator = GetComponent<Animator>();
        animator.SetInteger("isWalking", 0);
        PlayerPrefs.SetString("sceneName", SceneManager.GetActiveScene().name);

        PlayerPrefs.Save();
    }

    void Update()
    {
        isMoving= false;
        if (isAlive && !isDead) // Kiểm tra trạng thái sống/chết
        {
            animator.SetInteger("isWalking", 0);

            float moveX = 0f;
            float moveY = 0f;

            if (Input.GetKey(KeyCode.D))
            {
                moveX = +1f;
                transform.rotation = Quaternion.Euler(0, 0, 270);
                animator.SetInteger("isWalking", 1);
                isMoving= true;
            }
            if (Input.GetKey(KeyCode.A)){
                moveX = -1f;
                transform.rotation = Quaternion.Euler(0, 0, 90);
                animator.SetInteger("isWalking", 1);
                isMoving = true;
            }
            if (Input.GetKey(KeyCode.W)){
                moveY = +1f;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                animator.SetInteger("isWalking", 1);
                isMoving = true;
            }
            if (Input.GetKey(KeyCode.S)){
                moveY= -1f;
                transform.rotation = Quaternion.Euler(0, 0, 180);
                animator.SetInteger("isWalking", 1);
                isMoving = true;
            }
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (hasRock)
                {
                    hasRock= false;
                    throwrock();
                }
            }
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
            {
                // Xử lý góc chuyển động khi di chuyển cùng lúc 2 phím
                transform.rotation = Quaternion.Euler(0, 0, 315);
            }
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
            {
                // Xử lý góc chuyển động khi di chuyển cùng lúc 2 phím
                transform.rotation = Quaternion.Euler(0, 0, 225);
            }
            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            {
                // Xử lý góc chuyển động khi di chuyển cùng lúc 2 phím
                transform.rotation = Quaternion.Euler(0, 0, 135);
            }
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
            {
                // Xử lý góc chuyển động khi di chuyển cùng lúc 2 phím
                transform.rotation = Quaternion.Euler(0, 0, 45);
            }

            Vector3 moveDir = new Vector3(moveX, moveY).normalized;
            transform.position += moveDir * tocdo * Time.deltaTime;

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

    private void throwrock()
    {
        GameObject rockObject = Instantiate(pfminirock, transform.position, Quaternion.identity);
        cucda2 minirock = rockObject.GetComponent<cucda2>();
    }

    private void deleterock()
    {

    }

}
