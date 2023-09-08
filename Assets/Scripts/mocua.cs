using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mocua : MonoBehaviour
{
    public bool isLocked = true; // Biến để kiểm tra xem cánh cửa có bị khóa hay không
    public Image keyImage; // Đối tượng Image để hiển thị hình ảnh chìa khóa
    
    void Start()
    {
        keyImage.enabled = false; // Ẩn hình ảnh chìa khóa khi bắt đầu
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Kiểm tra xem đối tượng va chạm có phải là người chơi hay không
        if (other.gameObject.CompareTag("Player"))
        {
            // Kiểm tra xem người chơi có chìa khóa cần thiết để mở cánh cửa hay không
            if (keyImage.enabled)
            {
                // Mở khóa cánh cửa và cho phép người chơi đi qua
                isLocked = false;
                gameObject.SetActive(false); // Ẩn cánh cửa
                keyImage.enabled = false; // Ẩn hình ảnh chìa khóa
            }
            else
            {
                // Người chơi chưa nhặt được đủ 1 key
            }
        }
    }
}
