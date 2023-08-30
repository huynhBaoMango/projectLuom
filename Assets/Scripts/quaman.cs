using UnityEngine;
using UnityEngine.SceneManagement;

public class quaman : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (chiakhoa.itemCount > 0)
            {
                SceneManager.LoadScene("Luom");
            }
            else
            {
                // Người chơi chưa nhặt được key
            }
        }
    }
}
