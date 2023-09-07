using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{
    
    private bool isPaused = false;
    private string previousScene; // Biến lưu tên scene trước khi tạm dừng.
    public GameObject pauseMenuUI;
    public Button pauseButton; // Nút tạm dừng


    void Start()
{
    previousScene = SceneManager.GetActiveScene().name;
    pauseButton.onClick.AddListener(TogglePause); // Thêm sự kiện OnClick cho nút tạm dừng/tiếp tục
}

void TogglePause()
{
    if (isPaused)
    {
        ResumeGame();
    }
    else
    {
        PauseGame();
    }
}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("previousScene"); // Thay "Level 1" bằng tên scene game của bạn.
    }

     public void restart()
     {
         isPaused = false; // Đặt lại giá trị của biến isPaused
         SceneManager.LoadScene("previousScene");
     }

}
