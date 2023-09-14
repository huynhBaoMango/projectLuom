using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollider : MonoBehaviour {
    private Rigidbody2D playerRb;

    void Start() {
        playerRb = GetComponentInParent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Rock")) {
            // Xử lý va chạm với đá ở đây
            // Đặt Rigidbody của player ở chế độ Kinematic để ngăn không cho player bị đẩy đi
            playerRb.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Rock")) {
            // Khi va chạm kết thúc, đặt lại Rigidbody của player ở chế độ Dynamic
            playerRb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}

