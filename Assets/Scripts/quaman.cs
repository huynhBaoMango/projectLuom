using UnityEngine;
using UnityEngine.SceneManagement;

public class quaman : MonoBehaviour
{
    [SerializeField]
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (thu.itemCount == 0)
            {
                SceneManager.LoadScene("Level 2");
            }
            else
            {
                // Người chơi chưa nhặt được đủ 3 key
            }
        }
    }
}
