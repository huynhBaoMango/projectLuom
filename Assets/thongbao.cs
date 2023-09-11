using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Thêm dòng này để sử dụng TextMeshPro

public class thongbao : MonoBehaviour
{
    // Biến để lưu trữ thông báo
    public TextMeshProUGUI notification;

    // Sử dụng phương thức này để khởi tạo
    void Start()
    {
        // Khi game bắt đầu, hiển thị thông báo
        notification.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // Kiểm tra xem người dùng có nhấn phím Enter hay không
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Nếu người dùng nhấn Enter, ẩn thông báo
            notification.gameObject.SetActive(false);
        }
    }
}
