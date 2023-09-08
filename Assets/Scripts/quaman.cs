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
        UnlockNewLevel();
    }
    void UnlockNewLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex >=PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex",SceneManager.GetActiveScene().buildIndex +1);
            PlayerPrefs.SetInt("UnlockdLevel",PlayerPrefs.GetInt("UnlockdLevel",1)+1);
            PlayerPrefs.Save();
        }
    }
}
