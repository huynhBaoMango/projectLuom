using UnityEngine;

public class PlayerCon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("VatTheTag"))
        {
            // Xử lý khi người chơi va chạm với vật thể có tag "VatTheTag"
        }
    }
}
