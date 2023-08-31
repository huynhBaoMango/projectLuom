using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class thu : MonoBehaviour
{
    // Các biến công khai có thể được thiết lập trong Unity Inspector
    public string itemName; // Tên của vật phẩm
    public float pickupDistance = 2f; // Khoảng cách tối đa từ người chơi mà vật phẩm có thể được nhặt lên
    public Transform player; // Transform của người chơi
    public Image itemImage; // Hình ảnh sẽ hiển thị khi vật phẩm được nhặt lên
    public TextMeshProUGUI itemCountText; // Văn bản hiển thị số lượng vật phẩm còn lại để nhặt lên

    // Biến tĩnh để theo dõi số lượng vật phẩm còn lại để nhặt lên
    public static int itemCount = 3;

    void Update()
    {
        // Kiểm tra xem người chơi có trong khoảng cách pickupDistance của vật phẩm và có bất kỳ vật phẩm nào còn lại để nhặt lên không
        if (Vector3.Distance(transform.position, player.position) < pickupDistance && itemCount > 0)
        {
            itemCount--; // Giảm số lượng vật phẩm còn lại để nhặt lên
            itemImage.enabled = true; // Kích hoạt hình ảnh của vật phẩm
            itemCountText.text = itemCount.ToString(); // Cập nhật văn bản để hiển thị số lượng vật phẩm còn lại để nhặt lên
            Destroy(gameObject); // Hủy đối tượng trò chơi mà mã nguồn này được gắn vào
        }
    }
}
