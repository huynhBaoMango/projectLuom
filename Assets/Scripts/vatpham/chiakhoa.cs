using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chiakhoa : MonoBehaviour
{
    public string itemName;
    public float pickupDistance = 2f; // Khoảng cách tối đa từ người chơi mà vật phẩm có thể được nhặt lên
    public Transform player;
    [SerializeField] private AudioClip pickup;
    public Image keyImage; // Đối tượng Image để hiển thị hình ảnh chìa khóa

    void Start()
    {
        keyImage.enabled = false; // Ẩn hình ảnh chìa khóa khi bắt đầu
    }

    void Update()
    {
        // Kiểm tra xem người chơi có trong khoảng cách pickupDistance của vật phẩm và có bất kỳ vật phẩm nào còn lại để nhặt lên không
        if (Vector3.Distance(transform.position, player.position) < pickupDistance)
        {
            keyImage.enabled = true; // Kích hoạt hình ảnh chìa khóa
            AudioSource.PlayClipAtPoint(pickup,transform.position);
            Destroy(gameObject); // Hủy đối tượng trò chơi mà mã nguồn này được gắn vào
        }  
    }
}
