using UnityEngine;
using UnityEngine.SceneManagement;

public class quaman : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (thu.itemCount == 0)
            {
                int nextlevel = SceneManager.GetActiveScene().buildIndex + 1;
                SceneManager.LoadScene(nextlevel);
            }
            else
            {
                // Người chơi chưa nhặt được đủ 3 key
            }
        }
    }
}
