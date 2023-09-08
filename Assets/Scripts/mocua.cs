using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mocua : MonoBehaviour
{
    public bool isLocked = true; // Biến để kiểm tra xem cánh cửa có bị khóa hay không
    
    void OnCollisionEnter2D(Collision2D other)
    {
        // Kiểm tra xem đối tượng va chạm có phải là người chơi hay không
        if (other.gameObject.CompareTag("Player"))
        {
            // Kiểm tra xem người chơi có chìa khóa cần thiết để mở cánh cửa hay không
            if (chiakhoa.itemCount == 0)
            {
                // Mở khóa cánh cửa và cho phép người chơi đi qua
                isLocked = false;
                gameObject.SetActive(false); // Ẩn cánh cửa
            }
            else
            {
                // Người chơi chưa nhặt được đủ 1 key
            }
        }
    }
}
