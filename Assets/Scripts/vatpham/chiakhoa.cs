using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chiakhoa : MonoBehaviour
{

    public float pickupDistance = 2f; // Khoảng cách tối đa từ người chơi mà vật phẩm có thể được nhặt lên
    public Transform player;
    [SerializeField] private AudioClip pickup;
    public Image itemImage; // Hình ảnh sẽ hiển thị khi vật phẩm được nhặt lên


    // Biến tĩnh để theo dõi số lượng vật phẩm còn lại để nhặt lên
    public static int itemCount = 0;

    void Awake()
    {
        itemImage.enabled = false;
    }

    void Update()
    {
        // Kiểm tra xem người chơi có trong khoảng cách pickupDistance của vật phẩm và có bất kỳ vật phẩm nào còn lại để nhặt lên không
        if (Vector3.Distance(transform.position, player.position) < pickupDistance && itemCount > 0)
        {

            itemCount++;
            itemImage.enabled = true; // Kích hoạt hình ảnh của vật phẩm
            AudioSource.PlayClipAtPoint(pickup, transform.position);
            Destroy(gameObject); // Hủy đối tượng trò chơi mà mã nguồn này được gắn vào

        }
    }
}